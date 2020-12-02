using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobotSimulator;
using System.Drawing;

namespace ToyRobotSimulator.Test
{
	[TestClass]
	public class RobotTests
	{
		[TestMethod]
		public void TestValidMove()
		{
			var robot = new Robot(new Point(3, 3), Direction.East);
			var nextPosition = robot.GetNextPosition();
			Assert.AreEqual(4, nextPosition.X);
			Assert.AreEqual(3, nextPosition.Y);
		}
		[TestMethod]
		public void TestInValidMove()
		{
			var robot = new Robot(new Point(3, 3), Direction.South);
			var nextPosition = robot.GetNextPosition();
			Assert.AreNotEqual(4, nextPosition.X);
			Assert.AreNotEqual(3, nextPosition.Y);
		}

		[TestMethod]
		public void TestValidRotate()
		{
			var robot = new Robot(new Point(3, 3), Direction.South);
			robot.RotateLeft();
			Assert.AreEqual(Direction.East, robot.Direction);
		}

		[TestMethod]
		public void TestInValidRotate()
		{
			var robot = new Robot(new Point(3, 3), Direction.South);
			robot.RotateLeft();
			Assert.AreNotEqual(Direction.West, robot.Direction);
		}
	}
}
