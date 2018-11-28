using RogueLike.Katano.Maze;
using UnityEngine;

namespace RogueLike.Katano.View
{
	/// <summary>
	/// 通路のViewオブジェクト
	/// </summary>
	public class AisleView : MonoBehaviour
	{
		public Aisle Aisle { get; private set; }

		public void Construct(Aisle aisle)
		{
			Aisle = aisle;
		}
	}
}