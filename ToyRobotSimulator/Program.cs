using System;

namespace ToyRobotSimulator
{
	class Program
	{
		static void Main(string[] args)
		{
			Robot robot = new Robot();
			RobotTable table = new RobotTable(5, 5);
			Simulator simulator = new Simulator(robot, table);
			Console.WriteLine("Please enter command to continue or enter Exit to quit the program");
			while (true)
			{
				string input = Console.ReadLine();
				if (input.Trim().ToUpper().Equals("EXIT", StringComparison.InvariantCultureIgnoreCase))
					break;

				try
				{
					var output = simulator.RunCommand(input);
					if (!string.IsNullOrEmpty(output))
						Console.WriteLine(output);
				}
				catch (ArgumentOutOfRangeException ex)
				{
					// application related messages
					Console.WriteLine(ex.Message);
				}
				catch (Exception exception)
				{
					// log exception ILoger.logError(exception)
					Console.WriteLine("An error occurred while processing your request, Please try again or contact to support ");
				}
			}
		}
	}
}
