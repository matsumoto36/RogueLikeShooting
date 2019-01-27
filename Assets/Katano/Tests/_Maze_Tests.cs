using System.Collections;
using DDD.Katano.Maze;
using NUnit.Framework;
using DDD.Katano;
using UnityEngine.TestTools;

namespace DDD.Tests
{
	public class _Maze_Tests
	{
		private Maze _maze;

		[SetUp]
		public void SetUp()
		{
			var width = 4;
			var height = 4;
			
			var builder = new MazeBuilder();
			var options = new MazeBuildOptions(width, height, DecorationState.Labyrinth);
			var director = new MazeDirector(builder, options);

			_maze = director.Construct();
		}
		
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
			Assert.AreEqual(new Point(), room.Coordinate);
		}

		public void _Create_Rooms_Of_Grid_Are_Progression()
		{
			var rooms = new Room[5, 5].Initialize((x, y)=> new Room(0, new Point(x,y)));
		}

		[Test]
		public void _CreateRoom_Neighbors_Is_1()
		{
		}
	}
}