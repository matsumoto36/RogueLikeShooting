using System.Linq;
using Reqweldzen.Extensions;

namespace RougeLike.Katano.Maze
{
	public class LabyrinthDecorator : IMazeDecorator
	{
		public Maze Decoration(Maze maze)
		{
			// 再帰的に部屋が全通かチェックする
			void FillMark(Room origin)
			{
				// 部屋に接続しているすべての通路
				foreach (var aisle in maze.GetConnectingAisle(origin))
				{
					if (!aisle.IsEnable.Value) continue;
					
					var counterSide = aisle.GetCounterSide(origin);

					// マーク済みなら何もしない
					if (counterSide.IsCompleted) continue;

					counterSide.SetMarkAndComplete(origin);
					
					FillMark(counterSide);
				}
			}
			
			// 通路のチェック済みフラグを消す
			foreach (var aisle in maze.Aisles)
			{
				aisle.Reset();
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
				
				pickRoom.SetMarkAndComplete(mark);
				
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

			return maze;
		}
	}
}