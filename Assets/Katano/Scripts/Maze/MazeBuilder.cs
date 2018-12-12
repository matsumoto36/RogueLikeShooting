using System;
using System.Collections.Generic;
using System.Linq;
using Reqweldzen.Extensions;
using UnityEngine;

namespace RogueLike.Katano.Maze
{
	/// <summary>
	///     迷路ビルダー
	/// </summary>
	public class MazeBuilder
	{
		/// <summary>
		/// 隣接マスアクセステーブル
		/// </summary>
		private static readonly Point[] Neighbors =
		{
			new Point(0, -1), 
			new Point(1, 0), 
			new Point(0, 1), 
			new Point(-1, 0)
		};
		
		/// <summary>
		/// ビルドオプション
		/// </summary>
		private MazeBuildOptions _buildOptions;
		
		/// <summary>
		/// 部屋リスト
		/// </summary>
		private Room[,] _roomList;
		
		/// <summary>
		/// 廊下リスト
		/// </summary>
		private HashSet<Aisle> _aisleList;
		
		private bool _builtAisle;
		private bool _builtRoom;
		private bool _cleanup = true;
		
		
		/// <summary>
		/// オプションを設定する
		/// </summary>
		/// <param name="options"></param>
		public void SetOptions(MazeBuildOptions options)
		{
			_buildOptions = options;
		}
		
		/// <summary>
		///     部屋を作成する
		/// </summary>
		/// <returns></returns>
		public void BuildRoom()
		{
			var width = _buildOptions.Width;
			var height = _buildOptions.Height;
			
			_roomList = new Room[width, height].Initialize(ConstructMethod);
			_builtRoom = true;
			
			Room ConstructMethod(int x, int y)
			{
				return new Room(height * y + x, new Point(x,y));
			}
		}

		/// <summary>
		///     通路を作成する
		/// </summary>
		/// <returns></returns>
		public void BuildAisle()
		{
			// 重複する通路データを省く
			_aisleList = new HashSet<Aisle>();

			MakeAisle(ref _aisleList);

			

			_builtAisle = true;
		}

		/// <summary>
		///     部屋数を短縮する
		/// </summary>
		/// <param name="rate">レート (0-1)</param>
		/// <returns></returns>
		public void ShortenRoom(float rate)
		{
			rate = Mathf.Clamp01(rate);

			var get = Mathf.FloorToInt(_roomList.Length * rate);

			ShortenRoomInternal(get).CleanupIsolatedRoom();
		}

		/// <summary>
		///     部屋数を短縮する
		/// </summary>
		/// <param name="count"></param>
		/// <returns></returns>
		/// <exception cref="MazeException"></exception>
		private MazeBuilder ShortenRoomInternal(int count)
		{
			if (!_builtRoom)
				throw new MazeException("A room container has not been built yet.");
			if (!_builtAisle)
				throw new MazeException("Aisles has not been built yet.");

			foreach (var room in _roomList.Cast<Room>().TakeRandom(count)) room.IsEnable = false;

			_aisleList.RemoveWhere(x => !x.IsValid());
			
			_cleanup = false;

			return this;
		}

		/// <summary>
		///     通路無接続の部屋を無効化
		/// </summary>
		private void RemoveIsolatedRoom()
		{
			// ぼっちは生きられない
			foreach (var room in _roomList.GetIsolatedRoom(_aisleList)) room.IsEnable = false;
		}

		/// <summary>
		///     小さいクラスターを無効化
		/// </summary>
		private void RemoveSmallCluster()
		{
			var roomList = _roomList.Cast<Room>().Where(x => x.IsEnable).ToList();
			var cluster = new HashSet<Room>();
			var clusterList = new List<List<Room>>();

			// ランダムに部屋を一つ選択する
			var origin = roomList.RandomAt();

			// 部屋に接続しているすべての部屋を探索する
			CountChainRooms(origin, ref cluster);

			if (cluster.Count >= roomList.Count / 2)
			{
				// 大きいクラスター以外の部屋を無効化
				foreach (var room in roomList.Except(cluster)) room.IsEnable = false;
				return;
			}

			

			DiscoverAll();

			RemoveCluster();

			// 全探索する
			void DiscoverAll()
			{
				while (true)
				{
					clusterList.Add(cluster.ToList());
					roomList = roomList.Except(clusterList.SelectMany(x => x)).ToList();
					if (!roomList.Any()) return;

					// 部屋バッファを初期化
					cluster.Clear();
					origin = roomList.RandomAt();
					CountChainRooms(origin, ref cluster);
				}
			}

			// 小クラスタを削除
			void RemoveCluster()
			{
				var smallClusters = clusterList
					// 要素数で並べかえ(降順)
					.OrderByDescending(x => x.Count)
					// さらにID(昇順)で並べかえ(降順)
					.ThenByDescending(x => x.OrderBy(y => y.Id).ElementAt(0).Id)
					// 1つ目を飛ばして平坦化
					.Skip(1).SelectMany(x => x);
				
				foreach (var room in smallClusters)
				{
					room.IsEnable = false;
				}
			}
		}

		/// <summary>
		///     孤立した部屋を消す
		/// </summary>
		/// <returns></returns>
		private void CleanupIsolatedRoom()
		{
			// 単一の部屋を消す
			RemoveIsolatedRoom();

			// つながりが少ない部屋を消す
			RemoveSmallCluster();

			_aisleList.RemoveWhere(x => !x.Room0.IsEnable || !x.Room1.IsEnable);

			_cleanup = true;
		}

		/// <summary>
		///     再帰的に部屋が全通かチェックする
		/// </summary>
		/// <returns></returns>
		private void CountChainRooms(Room origin, ref HashSet<Room> checkedList)
		{
			// 部屋に接続しているすべての通路
			foreach (var aisle in _aisleList.GetConnectingAisle(origin))
			{
				// つながってる部屋を取得
				var counterSide = aisle.GetCounterSide(origin);

				if (checkedList.Contains(counterSide)) continue;
				
				// カウント済みリストに追加
				checkedList.Add(counterSide);

				CountChainRooms(counterSide, ref checkedList);
			}
		}

		/// <summary>
		///     迷路を作成
		/// </summary>
		/// <returns></returns>
		/// <exception cref="MazeException"></exception>
		public Maze Build()
		{
			if (!_builtRoom) throw new MazeException("A room container has not been built yet.");
			if (!_builtAisle) throw new MazeException("Aisles has not been built yet.");
			if (!_cleanup) throw new MazeException("Maze has not been cleaned yet.");

			return new Maze(_roomList, _aisleList.ToArray(), _buildOptions.Width, _buildOptions.Height);
		}

		/// <summary>
		///     部屋間に通路を敷く
		/// </summary>
		/// <param name="aisles"></param>
		private void MakeAisle(ref HashSet<Aisle> aisles)
		{
			for (var i = 0; i < _buildOptions.Width; i++)
			for (var j = 0; j < _buildOptions.Height; j++)
			{
				var origin = _roomList[i, j];
				for (var k = 0; k < Neighbors.Length; k++)
				{
					// 四方向相対座標テーブルから座標を得る
					var (x, y) = Neighbors[k];

					// 範囲外は除外
					if (i + x < 0 || i + x >= _buildOptions.Width) continue;
					if (j + y < 0 || j + y >= _buildOptions.Height) continue;

					// 隣接する部屋
					var neighbor = _roomList[i + x, j + y];
				
					// 新しい通路を作成
					var aisle = origin + neighbor;
//						.WithState(k % 2 == 0
//							? AisleChainState.Vertical
//							: AisleChainState.Horizontal);
					
					// 隣接する部屋の方向のビットフラグを立てる
					// origin.AdjacentSide |= (AdjacentSides) (1 << k);
					origin.ConnectingAisles.Add((AdjacentSides) k, aisle);

					
				
					// 通路リストに追加
					aisles.Add(aisle);
				}
			}
		}

		public void Decoration()
		{
			switch (_buildOptions.DecorationState)
			{
				case EnumDecorationState.None:
					break;
				case EnumDecorationState.Labyrinth:
					LabyrinthDecoration();
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
		
		private void LabyrinthDecoration()
		{
			// 再帰的に部屋が全通かチェックする
			void FillMark(Room origin)
			{
				// 部屋に接続しているすべての通路
				foreach (var aisle in _aisleList.GetConnectingAisle(origin))
				{
					if (!aisle.IsEnable) continue;
					
					var counterSide = aisle.GetCounterSide(origin);

					// マーク済みなら何もしない
					if (counterSide.IsCompleted) continue;

					counterSide.SetMarkAndComplete(origin);
					
					FillMark(counterSide);
				}
			}
			
			// 通路のチェック済みフラグを消す
			foreach (var aisle in _aisleList)
			{
				aisle.Reset();
			}
			
			// 有効な部屋のリスト
			var roomList = _roomList.OfType<Room>().Where(x => x.IsEnable).ToList();
			
			// マーキング
			var mark = 0;
			
			// 部屋をリマークする
			foreach (var room in roomList)
			{
				room.SetMark(mark);
			}
			
			// 通路の数だけループする
			for (var i = 0; i < _aisleList.Count ; i++)
			{
				// 未チェックかつ有効な通路を選択
				var aisle = _aisleList.RandomAt(x => !x.IsCompleted && x.IsEnable);
				
				// 通路を無効化
				aisle.IsEnable = false;

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
				if (roomList.Any(x => mark != x.Mark))
				{
					aisle.IsEnable = true;
				}

				// 処理済みとしてチェック
				aisle.IsCompleted = true;
			}
		}

		/// <summary>
		/// 属性を上書きする
		/// </summary>
		public void OverrideAttribute()
		{
			var enabledRooms = _roomList.Cast<Room>().Where(x => x.IsEnable).Shuffle().ToArray();

			for (var i = 0; i < enabledRooms.Length; ++i)
			{
				switch (i)
				{
					case 0:
						enabledRooms[i].RoomAttribute = Room.RoomAttributes.FloorStart;
						break;
					case 1:
						enabledRooms[i].RoomAttribute = Room.RoomAttributes.Stair;
						break;
					default:
						enabledRooms[i].RoomAttribute = Room.RoomAttributes.Others;
						break;
				}
			}
		}
	}
}