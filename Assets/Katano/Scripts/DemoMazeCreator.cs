using System.Collections.Generic;
using System.Linq;
using Reqweldzen.Extensions;
using UnityEngine;

namespace RougeLike.Katano.Maze
{
	public interface IMazeGenerator
	{
		Maze Generate(int width, int height);
		void CreateMap(Maze maze);
	}

	public class DemoMazeCreator : MonoBehaviour, IMazeGenerator
	{
		public Maze Generate(int width, int height)
		{
			foreach (Transform child in transform)
			{
				Destroy(child.gameObject);
			}
			
			var options = new MazeBuildOptions(width, height);
			var maze = new MazeBuilder(options)
				.BuildAll()
				.TakeDisableRoom(8)
				.CleanupIsolatedRoom()
				.Build();		

			return maze;
		}

		/// <summary>
		/// マップを作成する
		/// </summary>
		public void CreateMap(Maze maze)
		{
			// 再帰的に部屋が全通かチェックする
			void FillMark(Room current)
			{
				// 部屋に接続しているすべての通路
				foreach (var aisle in maze.Aisles.Where(x => x.Room0 == current || x.Room1 == current))
				{
					if (!aisle.IsEnable.Value) continue;
					
					var counterSide = aisle.GetCounterSide(current);

					// マーク済みなら何もしない
					if (counterSide.IsCompleted) continue;

					counterSide.SetMarkAndComplete(current);
					
					FillMark(counterSide);
				}
			}
			
			// 通路のチェック済みフラグを消す
			foreach (var aisle in maze.Aisles)
			{
				aisle.IsEnable.Value = true;
				aisle.IsCompleted = false;
			}
			
			// 有効な部屋のリスト
			var roomList = maze.RoomList.Where(x => x.IsEnable.Value).ToList();
			
			// マーキング
			var mark = 0;
			
			// 部屋をリマークする
			foreach (var room in roomList)
			{
				room.SetMark(mark);
			}
			
			// 通路の数だけループする
			for (var i = 0; i < maze.Aisles.Length ; i++)
			{
				// 未チェックかつ有効な通路を選択
				var aisle = maze.Aisles.RandomAt(x => !x.IsCompleted && x.IsEnable.Value);
				
				// 通路を無効化
				aisle.IsEnable.Value = false;

				// 部屋のチェックフラグを初期化
				foreach (var room in roomList) room.IsCompleted = false;

				// 適当な部屋を選ぶ
				var pickRoom = roomList.RandomAt();
				
				// マークを進める
				mark++;
				
				pickRoom.Mark.Value = mark;
				pickRoom.IsCompleted = true;
				
				// つながっている部屋に同じマークを付ける
				FillMark(pickRoom);

				// 新しいマークがついていない部屋があれば、通路を元に戻す
				if (roomList.Any(x => mark != x.Mark.Value))
				{
					aisle.IsEnable.Value = true;
				}

				// 処理済みとしてチェック
				aisle.IsCompleted = true;
			}
		}
	}
}