using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayManip
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] intArray = new int[0];
			NewInit: Console.Clear();
			Console.WriteLine("What is the array size?");
			
			var arraySize = 0;
			if (!int.TryParse(Console.ReadLine(),out arraySize)){
				goto NewInit;
			}
			if (arraySize <= 0) goto NewInit;
			// oh, both checks passed. good!
			Array.Resize(ref intArray,arraySize);

			Console.WriteLine("Fill the array with data.");
			for (var i = 0; i < arraySize; ++i){
				TestData: var arrayData = 0;
				if (!int.TryParse(Console.ReadLine(),out arrayData)){
					Console.WriteLine(" ... ERROR");
					goto TestData;
				}
				Console.WriteLine(" ... OK");
				intArray[i] = arrayData;
			}

			MainMenu: Console.Clear();
			var arrayStr = "";
			foreach (int arrayVal in intArray){
				arrayStr += arrayVal.ToString()+", ";
			}
			Console.WriteLine("[ "+arrayStr+" ]");

			Console.WriteLine("");
			Console.WriteLine("What do you want to do?");
			//Console.WriteLine("1. Add value at point");
			//Console.WriteLine("2. Remove value at point");
			// arrays are ANNOOOOOYING so i'm not going to do bonus this time
			Console.WriteLine("1. Get minimums and maximums");
			Console.WriteLine("2. Get the sum and average");
			Console.WriteLine("3. Reverse array");
			Console.WriteLine("4. Sort array");
			Console.WriteLine("5. Exit");

			var selection = 0;
			if (!int.TryParse(Console.ReadLine(),out selection)){
				goto MainMenu;
			}
			switch (selection){
				case 1:

					Console.WriteLine("Press any key to continue...");
					Console.ReadKey();
				break;
				case 2:
					Console.WriteLine("Sum: ");
					Console.WriteLine("Avg: ");

					Console.WriteLine("Press any key to continue...");
					Console.ReadKey();
				break;
				case 3:
					Array.Reverse(intArray);
				break;
				case 4:
					Array.Sort(intArray);
				break;
				case 5:
				return;
			}
			goto MainMenu;
		}
	}
}
