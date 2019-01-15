namespace DDD.Katano
{
	public static class MazeSignal
	{
		/// <summary>
		/// フロアが開始された
		/// </summary>
		public struct FloorStarted {}
		
		/// <summary>
		/// フロアを踏破した
		/// </summary>
		public struct FloorEnded {}
		
		/// <summary>
		/// プレイヤーは死んでしまった
		/// </summary>
		public struct PlayerKilled{}
		/// <summary>
		/// ダンジョンをクリアした
		/// </summary>
		public struct MazeCleared {}

		/// <summary>
		/// フロアを破壊する
		/// </summary>
		public struct FloorDestruct
		{
		}
	}
}