using System.Drawing;
using ToyRobotSimulator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ToyRobotSimulator.Test
{
    [TestClass]
    public class RobotTableTests
    {
        [TestMethod]
        public void TestInValidBoardPosition()
        {
            RobotTable table = new RobotTable(10, 10);
            Point position = new Point(11, 11);
            var result = table.IsPositionExist(position);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestValidBoardPosition()
        {
            RobotTable table = new RobotTable(10, 10);
            Point position = new Point(1, 1);
            var result = table.IsPositionExist(position);
            Assert.IsTrue(result);
        }
    }
}
