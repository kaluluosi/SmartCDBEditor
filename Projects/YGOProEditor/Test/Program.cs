using System;
using Cfg;
using YGODevelop;
using Builder;
using System.Collections.Generic;
using System.IO;

namespace Test
{
	class MainClass
	{
		/// <summary>
		/// The entry point of the program, where the program control starts and ends.
		/// </summary>
		/// <param name="args">The command-line arguments.</param>
		public static void Main (string[] args)
		{
            string path = @"Data\Ot.xml";
            string fullPath = Path.GetFullPath(path);
            Console.WriteLine(fullPath);
		}


		public static void PrintVarItem(IEnumerable<VarItem> items){
			foreach (VarItem item in items) {
				Console.WriteLine (item.Description);
			}
		}

	}
}
