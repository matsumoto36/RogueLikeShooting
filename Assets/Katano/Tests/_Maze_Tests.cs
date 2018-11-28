using System.Collections;
using NUnit.Framework;
using RogueLike.Katano;
using RogueLike.Katano.Maze;
using UnityEngine.TestTools;

namespace RogueLike.Tests
{
	public class _Maze_Tests
	{
		[Test]
		public void _Maze_TestsSimplePasses()
		{
			// Use the Assert class to test conditions.
		}

		// A UnityTest behaves like a coroutine in PlayMode
		// and allows you to yield null to skip a frame in EditMode
		[UnityTest]
		public IEnumerator _Maze_TestsWithEnumeratorPasses()
		{
			// Use the Assert class to test conditions.
			// yield to skip a frame
			yield return null;
		}

		[Test]
		public void _Create_Room_With_Id_Zero()
		{
			var room = new Room(0, new Point());
			
			Assert.AreEqual(0, room.Id);
			Assert.AreEqual(new Point(), room.Coord);
		}

		[Test]
		public void _Create_Aisle_With_Id_Zero()
		{
			var room0 = new Room(0, new Point(0, 0));
			var room1 = new Room(1, new Point(1, 0));
			var aisle = new Aisle(room0, room1, AisleChainState.Horizontal);
			
			Assert.AreEqual(room0, aisle.Room0);
			Assert.AreEqual(room1, aisle.Room1);
			Assert.AreEqual(room0.Id ^ room1.Id, aisle.Id);
		}

		public void _Create_Rooms_Of_Grid_Are_Progression()
		{
			var rooms = new Room[5, 5].Initialize((x, y)=> new Room(0, new Point(x,y)));
		}
	}
}