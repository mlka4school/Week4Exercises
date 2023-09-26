using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRecords
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<Student> studentList = new List<Student>(); // make the list
			MainMenu: Console.Clear();
			Console.WriteLine("There are "+studentList.Count+" students in the record. What would you like to do?");

			Console.WriteLine("");
			Console.WriteLine("1. Add new student");
			Console.WriteLine("2. Remove a student");
			Console.WriteLine("3. Update student info");
			Console.WriteLine("4. List/Search all students");
			Console.WriteLine("5. Exit program");

			var selection = 0;
			if (int.TryParse(Console.ReadLine(),out selection)){
				switch (selection){
					case 1:
						// ask for info
						var input = 0;
						var strinput = "";
						var stID = 0;
						var stNF = "";
						var stNL = "";
						var stNG = new int[3];
						InputID: Console.WriteLine("Please enter school ID");
						if (!int.TryParse(Console.ReadLine(),out input)) goto InputID;
						if (studentList.FindIndex(student => student.schoolID == input) != -1){
							Console.WriteLine("That ID already exists in the record");
							goto InputID;
						}
						stID = input;
						InputFirst: Console.WriteLine("Please enter first name");
						strinput = Console.ReadLine();
						stNF = strinput;
						InputLast: Console.WriteLine("Please enter last name");
						strinput = Console.ReadLine();
						stNL = strinput;
						InputAvg: Console.WriteLine("Please enter grades for three subjects");
						if (!int.TryParse(Console.ReadLine(),out input)) goto InputAvg;
						if (input < 0) input = 0; if (input > 100) input = 100;
						stNG[0] = input;
						if (!int.TryParse(Console.ReadLine(),out input)) goto InputAvg;
						if (input < 0) input = 0; if (input > 100) input = 100;
						stNG[1] = input;
						if (!int.TryParse(Console.ReadLine(),out input)) goto InputAvg;
						if (input < 0) input = 0; if (input > 100) input = 100;
						stNG[2] = input;

						// make a struct and toss it in the list
						studentList.Add(new Student(stID,stNF,stNL,stNG));
						Console.WriteLine("New student added! Press any key to continue...");
						Console.ReadKey();
					goto MainMenu;
					case 2:
						// ask for ID and remove based on that.
						Console.WriteLine("ID to remove?");
						if (int.TryParse(Console.ReadLine(),out selection)){
							var findRecord = studentList.FindIndex(student => student.schoolID == selection);
							if (findRecord == -1){
								Console.WriteLine("That ID wasn't found. Press any key to continue...");
								Console.ReadKey();
							}else{ // rapture the record
								studentList.RemoveAt(findRecord);
								Console.WriteLine("Removed ID "+selection.ToString()+" from records. Press any key to continue...");
								Console.ReadKey();
							}
						}
					goto MainMenu;
					case 3:
						Console.WriteLine("ID to update?");
						if (int.TryParse(Console.ReadLine(),out selection)){
							var findRecord = studentList.FindIndex(student => student.schoolID == selection);
							if (findRecord == -1){
								Console.WriteLine("That ID wasn't found. Press any key to continue...");
								Console.ReadKey();
							}else{ // update the record
								var strNF = "";
								var strNL = "";
								var strNG = new int[3];
								UpdateFirst: Console.WriteLine("Please enter first name");
								strinput = Console.ReadLine();
								strNF = strinput;
								UpdateLast: Console.WriteLine("Please enter last name");
								strinput = Console.ReadLine();
								strNL = strinput;
								UpdateAvg: Console.WriteLine("Please enter grades for three subjects");
								if (!int.TryParse(Console.ReadLine(),out input)) goto UpdateAvg;
								if (input < 0) input = 0; if (input > 100) input = 100;
								strNG[0] = input;
								if (!int.TryParse(Console.ReadLine(),out input)) goto UpdateAvg;
								if (input < 0) input = 0; if (input > 100) input = 100;
								strNG[1] = input;
								if (!int.TryParse(Console.ReadLine(),out input)) goto UpdateAvg;
								if (input < 0) input = 0; if (input > 100) input = 100;
								strNG[2] = input;

								studentList[findRecord] = new Student(studentList[findRecord].schoolID,strNF,strNL,strNG);
								Console.WriteLine("Records updated. Press any key to continue...");
								Console.ReadKey();
							}
						}
					goto MainMenu;
					case 4:
						// search array
						if (studentList.Count == 0){
							Console.WriteLine("No students on record. Press any key to continue...");
							Console.ReadKey();
						}else{
							var searchList = new List<Student>();
							Console.WriteLine("Search mode?");
							Console.WriteLine("1. No search");
							Console.WriteLine("2. Highest grade");
							if (int.TryParse(Console.ReadLine(),out selection)){
								switch (selection){
									case 1:
										Console.WriteLine("Listing in no order");
										searchList = studentList;
									break;
									case 2:
										Console.WriteLine("Finding highest grading student..");
										var studentID = -1;
										var highestGrade = -1;
										var currentGrade = -1;
										foreach (Student findStudent in studentList){ // this is likely not the way to do it. but it's my way :)
											// nab all grades and avg them.
											currentGrade = Convert.ToInt32(findStudent.avgGrade.Average());
											// if this is higher than highest, then record it!
											if (highestGrade < currentGrade){
												highestGrade = currentGrade;
												studentID = findStudent.schoolID;
											}
										}
										// oh, it's done. get the student who did the highest
										var highestRecord = studentList.FindIndex(student => student.schoolID == studentID);
										searchList.Add(studentList[highestRecord]);
									break;
									default:
										Console.WriteLine("That wasn't correct. Try again. Press any key to continue...");
										Console.ReadKey();
									goto MainMenu;
								}
								foreach (Student listedSt in searchList){
									Console.WriteLine(IntIDtoStringID(listedSt.schoolID)+" - "+listedSt.lastName+", "+listedSt.firstName+", - "+listedSt.avgGrade[0]+"%, "+listedSt.avgGrade[1]+"%, "+listedSt.avgGrade[2]+"%");
								}
								Console.WriteLine("Press any key to continue...");
								Console.ReadKey();
							}
						}
					goto MainMenu;
					case 5:
					return;
				}
			}else{
				goto MainMenu;
			}
		}

		public struct Student{
			public Student(int newID, string newFirst, string newLast, int[] newGrade){
				schoolID = newID;
				firstName = newFirst;
				lastName = newLast;
				avgGrade = newGrade;
			}
			public int schoolID {get; set;}
			public string firstName {get; set;}
			public string lastName {get; set;}
			public int[] avgGrade {get; set;}
		}

		static string IntIDtoStringID(int initID){ // this makes things look nicer.
			var stringify = initID.ToString();
			while (stringify.Length < 6) stringify = "0"+stringify;
			return stringify;
		}
	}
}
