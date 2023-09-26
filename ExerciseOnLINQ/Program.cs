using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseOnLINQ
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<Item> itemList = new List<Item>(); // new list
			// generate twelve items. some share colors. other share material and weight.
			itemList.Add(new Item(35,"plain","yellow"));
			itemList.Add(new Item(50,"gooey","orange"));
			itemList.Add(new Item(35,"soft","green"));
			itemList.Add(new Item(40,"metal","yellow"));
			itemList.Add(new Item(35,"soft","orange"));
			itemList.Add(new Item(50,"plain","green"));
			itemList.Add(new Item(35,"soft","pink"));
			itemList.Add(new Item(40,"metal","white"));
			itemList.Add(new Item(35,"gooey","black"));
			itemList.Add(new Item(35,"plain","white"));
			itemList.Add(new Item(50,"metal","black"));
			itemList.Add(new Item(40,"metal","green"));

			// list them all just because we can
			Console.WriteLine("Listing all items:");
			ListList(itemList);
			Console.WriteLine("");
			// now find all 50kg items and list those.
			Console.WriteLine("Finding all 50kg items:");
			// time for the magic
			var queryKG = from item in itemList where item.Weight == 50 select item;
			ListList(queryKG.ToList<Item>());
			Console.WriteLine("");
			// try the other method. for metal items this time
			Console.WriteLine("Finding all metal items:");
			var queryMT = itemList.Where(item => item.Material == "metal").Select()
			ListList(queryMT.ToList<Item>()); // ToArray CAN be done. but i do not have a function for it
			Console.WriteLine("");
			Console.WriteLine("Press any key to continue...");
			Console.ReadKey();
		}

		static void ListList(List<Item> list){
			Console.WriteLine("In the list there is...");
			foreach (Item item in list){
				WriteOut(item.Color,item.Material,item.Weight);
			}
		}

		static void WriteOut(string color,string material,int weight){
			Console.WriteLine("A "+color+" item that feels "+material+" and weighs "+weight.ToString()+"kg");
		}

		// i did students already. let's do a different thing
		struct Item{
			public Item(int newWT, string newMat, string newClr){
				Weight = newWT;
				Material = newMat;
				Color = newClr;
			}

			public int Weight;
			public string Material;
			public string Color;
		}
	}
}
