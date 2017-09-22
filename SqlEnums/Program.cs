using System;

namespace Enums
{
	internal class Program
	{
		private static int Main(string[] args)
		{
			try
			{
			    new EnumerationsDll().Build();
			    return 1;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
                return 0;
            }
		}
	}
}