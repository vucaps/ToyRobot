using System;

namespace ToyRobotSimulator
{
	class Program
	{
		static void Main(string[] args)
		{
			
			RobotSimulator simulator = new RobotSimulator();
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
