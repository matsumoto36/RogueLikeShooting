using System;
using System.Collections.Generic;
using Reqweldzen.Extensions;
using RogueLike.Katano.Maze.View;
using UnityEngine;

namespace RogueLike.Katano.Maze
{
	/// <summary>
	/// 迷宮を可視化するクラス
	/// </summary>
	public class MazeViewBuilder : MonoBehaviour
	{
		public int Interval = 5;
		
		public MazeDataAssetBase MazeDataAsset;

		public MazeViewer BuildView(Maze maze)
		{
			var rooms = new Dictionary<int, GameObject>();
			var aisles = new Dictionary<int, GameObject>();
			
			// RoomViewの生成
			for (var i = 0; i < maze.Width; i++)
			{
				for (var j = 0; j < maze.Height; j++)
				{
					if (!maze.RoomList[i, j].IsEnable) continue;
				
					var view = Instantiate(MazeDataAsset.RoomPrefabList.RandomAt(), new Vector3(i + Interval * i, 0, j + Interval * j), Quaternion.identity, transform);
					rooms.Add(maze.RoomList[i,j].Id, view);
				}
			}

			// AisleViewの生成
			foreach (var aisle in maze.Aisles)
			{
				var spawn = Vector3.Lerp(rooms[aisle.Room0.Id].transform.position, rooms[aisle.Room1.Id].transform.position, 0.5f);
				var view = GameObject.CreatePrimitive(PrimitiveType.Cube);

				switch (aisle.AisleChainState)
				{
					case AisleChainState.Horizontal:
					{
						view.transform.localScale = new Vector3(10, 0.1f, 1);
						break;
					}
					case AisleChainState.Vertical:
					{
						view.transform.localScale = new Vector3(1, 0.1f, 10);
						break;
					}
					default:
						throw new ArgumentOutOfRangeException();
				}
				view.transform.localPosition = spawn;
				view.transform.SetParent(transform);
				
				aisles.Add(aisle.Id, view);
			}
			
			return new MazeViewer(maze, rooms, aisles);
		}
	}
}