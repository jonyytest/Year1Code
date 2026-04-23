using System;
using System.Collections.Generic;

namespace DuplicateCode
{
    class TaskItem
    {
        public string description = "";
        public int importance;
        public string dueDate = "";
    } // The info for each task
    class TaskPlanner
    {
        public static string heading = "CATEGORIES"; // Default heading
        
        // Prints header for the task table
        public static void MakeHeading(Dictionary<string, List<TaskItem>> allTasks)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(new string(' ', 7) + TaskPlanner.heading);
            Console.WriteLine(new string('-', 7 + (allTasks.Count * 43)));
            Console.Write("{0,6}|", "item #");
            foreach (string category in allTasks.Keys)
            {
                Console.Write("{0,30}|{1,11}|", category.ToUpper(), "DUE DATE");
            }
            Console.WriteLine("");
            Console.WriteLine(new string('-', 7 + (allTasks.Count * 43))); 
        } // Builds the modular table

        // Builds the row of tasks and the categories using PrintRow
        public static void BuildRow(int i, Dictionary<string, List<TaskItem>> allTasks)
        {
            Console.Write("{0,6}|", i);
            foreach (var list in allTasks.Values)
            {
                PrintRow(i, list);
            }
            Console.WriteLine();
        }
        
        public static void PrintTable(Dictionary<string, List<TaskItem>> allTasks)
        {
            int max = 0;
            foreach (var list in allTasks.Values)
            {
                if (list.Count > max) max = list.Count;
            }
            MakeHeading(allTasks);

            for (int i = 0; i < max; i++)
            {
                BuildRow(i, allTasks);
            }
        } // Adds the info to the table combining MakeHeading and BuildRow

        // Eliminated duplication in printing rows
        public static void PrintRow(int i, List<TaskItem> taskList)
        {
            if (taskList.Count > i)
            {
                TaskItem currentTask = taskList[i];

                // Change color based on importance
                if (currentTask.importance == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red; // Urgent
                }
                else if (currentTask.importance == 2)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow; // Important
                }
                else 
                {
                    Console.ForegroundColor = ConsoleColor.Blue; // Neutral
                }

                // Print the formatted string and then reset the color back to default
                Console.Write("{0,30}|{1,11}|", currentTask.description, currentTask.dueDate);
                Console.ForegroundColor = ConsoleColor.Blue; 
            }
            else
            {
                Console.Write("{0,30}|{1,11}|", "N/A", "--/--/----");
            }
        } // New method takes current row index and the specific array to print input with color and due date

        public static void TaskSort(string listName, TaskItem newTask, Dictionary<string, List<TaskItem>> allTasks)
        {
            if (allTasks.ContainsKey(listName))
            {
                allTasks[listName].Add(newTask);
            }
        } // Sorts the task into the right category

        public static string GetValidCategory(Dictionary<string, List<TaskItem>> allTasks, string promptMessage)
        {
            while (true)
            {
                Console.Clear();
                PrintTable(allTasks);
                Console.WriteLine("\n" + promptMessage);
                Console.Write(">> ");
                
                string category = (Console.ReadLine() ?? "").ToLower();

                if (category == "") return ""; // I added this so if the user enters nothing it cancels
                if (allTasks.ContainsKey(category)) return category;

                Console.WriteLine("Invalid category. Please try again.");
                Console.ReadKey();
            }
        } // Helper method to get a valid category from the user

        public static int GetValidItemNumber(Dictionary<string, List<TaskItem>> allTasks, string listName, string promptMessage, int max)
        {
            while (true)
            {
                Console.Clear();
                PrintTable(allTasks);
                Console.WriteLine("\n" + promptMessage);
                Console.Write(">> ");
                
                string input = Console.ReadLine() ?? "";
                if (input == "") return -1; // -1 represents cancel since an index can't be negative

                if (int.TryParse(input, out int itemNum) && itemNum >= 0 && itemNum < max)
                {
                    return itemNum; // Success
                }

                Console.WriteLine("Invalid input. Please enter an item number between 0 and " + (max - 1));
                Console.ReadKey();
            }
        } // Helper method to get a valid item index from the user

        public static void AddTask(Dictionary<string, List<TaskItem>> allTasks)
        {
            
            string listName = GetValidCategory(allTasks, "Enter the name of the category you would like to add a task to");
            if (listName == "") return;

            // Takes user input for description
            Console.Clear();
            PrintTable(allTasks);            
            Console.WriteLine("\nDescribe your task below (max. 30 symbols)");
            Console.Write(">> ");
            string task = (Console.ReadLine() ?? "");
            if (task == "")
            {
                return;
            } 
            // Cuts input if too long
            if (task.Length > 30) task = task.Substring(0, 30);

            Console.Clear();
            PrintTable(allTasks);
            Console.WriteLine("\nRate the Importance of the task");
            Console.WriteLine("1. Urgent");
            Console.WriteLine("2. Important");
            Console.WriteLine("3. Neutral");
            Console.Write(">> ");
            int importance;
            while (!int.TryParse((Console.ReadLine() ?? ""), out importance) || importance < 1 || importance > 3)
            {
                Console.WriteLine("Invalid input. Please enter 1, 2 or 3.");
                Console.Write(">>");
            } // Rates task importance by number

            Console.Clear();
            PrintTable(allTasks);
            Console.WriteLine("\nEnter a due date for the task");
            Console.WriteLine("Year");
            Console.Write(">> ");
            int year;
            while (!int.TryParse((Console.ReadLine() ?? ""), out year) || year < 2026 || year > 9999)
            {
                Console.WriteLine("Invalid input. Please enter a year greater than 2026");
                Console.Write(">>");
            }
            Console.WriteLine("Month");
            Console.Write(">> ");
            int month;
            while (!int.TryParse((Console.ReadLine() ?? ""), out month) || month < 1 || month > 12)
            {
                Console.WriteLine("Invalid input. Please enter a month between 1 and 12");
                Console.Write(">>");
            }
            Console.WriteLine("Day");
            Console.Write(">> ");
            int day;
            while (!int.TryParse((Console.ReadLine() ?? ""), out day) || day < 1 || day > 31)
            {
                Console.WriteLine("Invalid input. Please enter a day between 1 and 31");
                Console.Write(">>");
            } // We get the due date from 2026 onward.

            TaskItem newTask = new TaskItem
            {
                description = task, importance = importance, dueDate = day + "/" + month + "/" + year
            };

            // Add the task
            TaskPlanner.TaskSort(listName, newTask, allTasks);
        }

        public static void RemoveTask(Dictionary<string, List<TaskItem>> allTasks)
        {
            string listName = GetValidCategory(allTasks, "Enter the name of the category you would like to remove a task from");
            if (listName == "") return;

            if (allTasks[listName].Count == 0) // Checks if theres any tasks to remove
            {
                Console.WriteLine("The category " + (listName).ToUpper() + " has no tasks");
                Console.ReadKey();
                return;
            }

            int itemNum = 0;
            if (allTasks[listName].Count > 1)
            {
                itemNum = GetValidItemNumber(allTasks, listName, "Enter the item number of the task you would like to remove", allTasks[listName].Count);
                if (itemNum == -1) return;
            }
            allTasks[listName].RemoveAt(itemNum);
        }

        public static void MoveTask(Dictionary<string, List<TaskItem>> allTasks)
        {
            string listName = GetValidCategory(allTasks, "Enter the name of the category you would like to move a task FROM");
            if (listName == "") return;

            if (allTasks[listName].Count == 0)
                {
                    Console.WriteLine("The category " + (listName).ToUpper() + " has no tasks");
                    Console.ReadKey();
                    return;
                }
            
            int itemNum = 0;
            if (allTasks[listName].Count > 1)
            {
                itemNum = GetValidItemNumber(allTasks, listName, "Enter the item number of the task you would like to move", allTasks[listName].Count);
                if (itemNum == -1) return; 
            } // If theres only 1 task it will automatically choose it

            string listName2 = GetValidCategory(allTasks, "Enter the name of the category you would like the move task TO");
            if (listName2 == "") return;

            int itemNum2 = 0;
            if (allTasks[listName2].Count > 0)
            {
                itemNum2 = GetValidItemNumber(allTasks, listName2, "Enter the item number you would line to move the task to", (allTasks[listName].Count + 1));
                if (itemNum2 == -1) return;
            }
            TaskItem taskToMove = allTasks[listName][itemNum];
            allTasks[listName].RemoveAt(itemNum);
            allTasks[listName2].Insert(itemNum2, taskToMove);
        }
        
        public static void AddCat(Dictionary<string, List<TaskItem>> allTasks)
        {
            bool valid = false;
            string category = "";
            while (!valid)
            {
            Console.Clear();
            PrintTable(allTasks);            
            Console.WriteLine("\nEnter new category name (max. 30 symbols)");
            Console.Write(">> ");
            category = (Console.ReadLine() ?? "").ToLower();
            if (category == "")
            {
                return;
            }
            else if (allTasks.ContainsKey(category))
            {
                Console.WriteLine("This category already exists");
                Console.ReadKey();
            }
            else valid = true;
            }
            // Cuts input if too long
            if (category.Length > 30) category = category.Substring(0, 30);

            allTasks.Add(category, new List<TaskItem>());
        }

        public static void RemoveCat(Dictionary<string, List<TaskItem>> allTasks)
        {
            string category = GetValidCategory(allTasks, "Enter the name of the category you would like to remove");
            if (category == "") return;
            allTasks.Remove(category);
        } // Removes chosen category

        public static int Menu(Dictionary<string, List<TaskItem>> allTasks)
        {
            Console.ResetColor();
            Console.WriteLine("1. Add a task");
            Console.WriteLine("2. Delete a task");
            Console.WriteLine("3. Move a task");
            Console.WriteLine("4. Add a category");
            Console.WriteLine("5. Delete a category");
            Console.WriteLine("6. Hide menu");
            Console.WriteLine("7. Change Heading");
            Console.WriteLine("8. Exit");
            Console.Write(">> ");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 8)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 8.");
                Console.ReadKey();
                Console.Clear();
                PrintTable(allTasks);
                Console.ResetColor();
                Console.WriteLine("1. Add a task");
                Console.WriteLine("2. Delete a task");
                Console.WriteLine("3. Move a task");
                Console.WriteLine("4. Add a category");
                Console.WriteLine("5. Delete a category");
                Console.WriteLine("6. Hide menu");
                Console.WriteLine("7. Change Heading");
                Console.WriteLine("8. Exit");
                Console.Write(">> ");
            }
            return choice;
        }

        public static void ChangeHeading(Dictionary<string, List<TaskItem>> allTasks)
        {
            string heading = "";
            bool valid = false;
            while (!valid)
            {
                Console.Clear();
                PrintTable(allTasks);            
                Console.WriteLine("\nEnter new Heading (max. 60 symbols)");
                Console.Write(">> ");
                heading = (Console.ReadLine() ?? "");
                if (heading == "")
                {
                    return;
                } 
                else valid = true;
            }
            // Cuts input if too long
            if (heading.Length > 60) heading = heading.Substring(0, 60);
            TaskPlanner.heading = heading;
        }
    }
    class DuplicateCode
    {
        static void Main(string[] args)
        {
            // Category list
            Dictionary<string, List<TaskItem>> categories = new Dictionary<string, List<TaskItem>>();

            // Adds default categories to the list
            categories.Add("personal", new List<TaskItem>());
            categories.Add("work", new List<TaskItem>());
            categories.Add("family", new List<TaskItem>());

            // Switches between menu options
            while (true)
            {
                Console.Clear();

                TaskPlanner.PrintTable(categories);
                
                switch (TaskPlanner.Menu(categories))
                {
                    case 1:
                        TaskPlanner.AddTask(categories);
                        break;
                    case 2:
                        TaskPlanner.RemoveTask(categories);
                        break;
                    case 3:
                        TaskPlanner.MoveTask(categories);
                        break;
                    case 4:
                        TaskPlanner.AddCat(categories);
                        break;
                    case 5:
                        TaskPlanner.RemoveCat(categories);
                        break;
                    case 6:
                        Console.Clear();
                        TaskPlanner.PrintTable(categories);
                        Console.ReadKey();
                        break;
                    case 7:
                        TaskPlanner.ChangeHeading(categories);
                        break;
                    case 8:
                        return;
                }
            }
        }
    }
}
