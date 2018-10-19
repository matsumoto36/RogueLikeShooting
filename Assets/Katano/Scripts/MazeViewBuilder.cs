using System;
using System.Collections.Generic;
using System.Linq;
using Reqweldzen.Extensions;
using UniRx;
using UnityEngine;
using UnityEngine.AI;

namespace RougeLike.Katano.Maze
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
			for (var i = 0; i < maze.RoomList.Horizontal; i++)
			{
				for (var j = 0; j < maze.RoomList.Vertical; j++)
				{
					if (!maze.RoomList[i, j].IsEnable.Value) continue;
				
					var view = Instantiate(MazeDataAsset.RoomPrefabList.RandomAt(), new Vector3(i + Interval * i, 0, j + Interval * j), Quaternion.identity, transform);
					_roomViews.Add(maze.RoomList[i,j].Id, view);
				}
			}

			// AisleViewの生成
			foreach (var aisle in maze.Aisles)
			{
				var spawn = Vector3.Lerp(_roomViews[aisle.Room0.Id].transform.position, _roomViews[aisle.Room1.Id].transform.position, 0.5f);
				var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

				switch (aisle.AisleType)
				{
					case AisleTypes.Horizontal:
					{
						cube.transform.localScale = new Vector3(10, 0.1f, 1);
						break;
					}
					case AisleTypes.Vertical:
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

			foreach (var surface in _roomViews.Values.Select(x => x.GetComponent<NavMeshSurface>()))
			{
				surface.BuildNavMesh();
			}
		}
	}
}