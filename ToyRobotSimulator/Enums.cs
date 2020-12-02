
namespace ToyRobotSimulator
{
	public enum Direction
	{
		South = 0,
		East = 90,
		North = 180,
		West = 270		
	}

	public enum MoveTo
	{
		Left = 90,
		Right = -90
	}

	public enum CommandType
	{
		Place,
		Left,
		Right,
		Move,
		Report
	}
}
