using System;
using System.Collections.Generic;
using Reqweldzen.Extensions;
using UnityEngine;

namespace RogueLike.Katano.Maze
{
	/// <summary>
	/// 迷宮を可視化するクラス
	/// </summary>
	public class MazeViewBuilder : MonoBehaviour
	{
		private readonly Dictionary<int, GameObject> _roomViews = new Dictionary<int, GameObject>();

		public int Interval = 5;
		
		public MazeDataAssetBase MazeDataAsset;

		public void BuildView(Maze maze)
		{
			_roomViews.Clear();
			
			// RoomViewの生成
			for (var i = 0; i < maze.Width; i++)
			{
				for (var j = 0; j < maze.Height; j++)
				{
					if (!maze.RoomList[i, j].IsEnable) continue;
				
					var view = Instantiate(MazeDataAsset.RoomPrefabList.RandomAt(), new Vector3(i + Interval * i, 0, j + Interval * j), Quaternion.identity, transform);
					_roomViews.Add(maze.RoomList[i,j].Id, view);
				}
			}

			// AisleViewの生成
			foreach (var aisle in maze.Aisles)
			{
				var spawn = Vector3.Lerp(_roomViews[aisle.Room0.Id].transform.position, _roomViews[aisle.Room1.Id].transform.position, 0.5f);
				var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

				switch (aisle.AisleChainState)
				{
					case AisleChainState.Horizontal:
					{
						cube.transform.localScale = new Vector3(10, 0.1f, 1);
						break;
					}
					case AisleChainState.Vertical:
					{
						cube.transform.localScale = new Vector3(1, 0.1f, 10);
						break;
					}
					default:
						throw new ArgumentOutOfRangeException();
				}
				cube.transform.localPosition = spawn;
				cube.transform.SetParent(transform);
			}
		}
	}
}