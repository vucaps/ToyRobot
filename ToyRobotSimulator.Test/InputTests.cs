using ToyRobotSimulator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ToyRobotSimulator.Test
{
    [TestClass]
    public class InputTests
    {
        [TestMethod]
        public void IsValidInput()
        {
            var simulator = new Simulator();
            simulator.RunCommand("PLACE 0,0,EAST");     
            Assert.AreEqual(0, simulator.Robot.Position.X);
            Assert.AreEqual(0, simulator.Robot.Position.Y);
            Assert.AreEqual(Direction.East, simulator.Robot.Direction);
        }

        [TestMethod]
        public void IsInValidInput()
        {
            var simulator = new Simulator();
            simulator.RunCommand("PLACE 1,2,EAST");     
            Assert.AreNotEqual(3, simulator.Robot.Position.X);
            Assert.AreNotEqual(4, simulator.Robot.Position.Y);
            Assert.AreNotEqual(Direction.West, simulator.Robot.Direction);
        }
    }
}
