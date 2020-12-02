using System;
using System.Drawing;


namespace ToyRobotSimulator
{
	public class RobotSimulator
	{

		private RobotTable _robotTable;
		private Robot _robot;

		public Robot Robot { get => _robot; set => _robot = value; }
		public RobotTable RobotTable { get => _robotTable; set => _robotTable = value; }


		public RobotSimulator()
		{
			_robotTable = new RobotTable();
		}

		public string RunCommand(string command)
		{
			// remove any extra space in the command
			command = command.Trim();

			string[] commandParam = command.Split(' ');

			if (string.IsNullOrEmpty(command) || commandParam.Length <= 0)
				return string.Empty;

			//discard all commands in the sequence until a valid PLACE command has been executed
			if (_robot == null && !commandParam[0].ToUpper().Equals("PLACE"))
				return string.Empty;

			switch (commandParam[0].ToUpper())
			{
				case "PLACE":

					if (commandParam.Length <= 1) // invalid place command location parameters are missing
						return "Invalid place command – location and direction parameters are missing";

					string[] locationsDirectionParam = commandParam[1].Split(',');

					if (locationsDirectionParam.Length != 3) // invalid Location and Direction parameters
						return "Invalid place command – location and direction parameters are not valid";

					_robot = new Robot();

					Point position = new Point(int.Parse(locationsDirectionParam[0]), int.Parse(locationsDirectionParam[1]));

					if (_robotTable.IsTablePositionExist(position))
						_robot.Hop(position, GetDirection(locationsDirectionParam[2]));
					break;
				case "MOVE":
					var newPosition = _robot.GetNextPosition();
					if (_robotTable.IsTablePositionExist(newPosition))
						_robot.Move();
					break;
				case "LEFT":
					_robot.RotateLeft();
					break;
				case "RIGHT":
					_robot.RotateRight();
					break;
				case "REPORT":
					return GetReport();
				default:
					return "Invalid command – please try again";
			}

			return string.Empty;
		}

		private Direction GetDirection(string direction)
		{
			switch (direction.ToUpper())
			{
				case "SOUTH":
					return Direction.South;
				case "EAST":
					return Direction.East;
				case "NORTH":
					return Direction.North;
				case "WEST":
					return Direction.West;
				default:
					throw new ArgumentOutOfRangeException("Invalid Direction");
			}
		}
		public string GetReport()
		{
			if (_robot == null)
				return "Invalid report, Robot set to null";

			return string.Format("{0},{1},{2}", _robot.Position.X,
				_robot.Position.Y, _robot.Direction.ToString().ToUpper());
		}
	}
}
