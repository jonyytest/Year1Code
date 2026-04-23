using System;
class Program
{
    static void Main(string[] args)
    {
        // double[] myArray = new double[10];
        // myArray[0] = 1.0;
        // myArray[1] = 1.1;
        // myArray[2] = 1.2;
        // myArray[3] = 1.3;
        // myArray[4] = 1.4;
        // myArray[5] = 1.5;
        // myArray[6] = 1.6;
        // myArray[7] = 1.7;
        // myArray[8] = 1.8;
        // myArray[9] = 1.9;
        // Console.WriteLine("The element at index 0 in the array is " + myArray[0]);
        // Console.WriteLine("The element at index 1 in the array is " + myArray[1]);
        // Console.WriteLine("The element at index 2 in the array is " + myArray[2]);
        // Console.WriteLine("The element at index 3 in the array is " + myArray[3]);
        // Console.WriteLine("The element at index 4 in the array is " + myArray[4]);
        // Console.WriteLine("The element at index 5 in the array is " + myArray[5]);
        // Console.WriteLine("The element at index 6 in the array is " + myArray[6]);
        // Console.WriteLine("The element at index 7 in the array is " + myArray[7]);
        // Console.WriteLine("The element at index 8 in the array is " + myArray[8]);
        // Console.WriteLine("The element at index 9 in the array is " + myArray[9]);

        // int[] myIntArray = new int[10];
        // for (int i = 0; i < 10; i++)
        // {
        //     myArray[i] = i;
        // }
        // for (int i = 0; i < 10; i++)
        // {
        //     Console.WriteLine("The element at index " + i + " in the array is " + myArray[i]);
        // }

        // int[] studentArray = {87, 68, 94, 100, 83, 78, 85, 91, 76, 87};
        // int total = 0;
        // for (int i = 0; i < studentArray.Length; i++)
        // {
        //     total += studentArray[i];
        // }
        // Console.WriteLine("The total marks for the studen is " + total);
        // Console.WriteLine("This consist of " + studentArray.Length + " marks");
        // Console.WriteLine("Therefore the average mark is " + (total / studentArray.Length));

        // string[] studentNames = new string[6];
        // for (int i = 0; i < studentNames.Length; i++)
        // {
        //     while (studentNames[i] == null || studentNames[i] == "")
        //     {
        //         Console.WriteLine("Please enter a valid name for student " + (i));
        //         studentNames[i] = Console.ReadLine() ?? "";
        //     }
        // }
        // for (int i = 0; i < studentNames.Length; i++)
        // {
        //     Console.WriteLine("The name of student " + (i) + " is " + studentNames[i]);
        // }

        // double[] myDoubleArray = new double[10];
        // int currentSize = 0;
        // double currentLargest, currentSmallest;
        // while (currentSize < 10)
        // {
        //     Console.WriteLine("Please enter a number for index " + currentSize);
        //     string input = Console.ReadLine() ?? "";
        //     if (double.TryParse(input, out double number))
        //     {
        //         myDoubleArray[currentSize] = number;
        //         currentSize++;
        //     }
        //     else
        //     {
        //         Console.WriteLine("Invalid input. Please enter a valid number.");
        //     }
        // }
        // currentLargest = myDoubleArray[0];
        // currentSmallest = myDoubleArray[9];
        // for (int i = 1; i < myDoubleArray.Length; i++)
        // {
        //     if (myDoubleArray[i] > currentLargest)
        //     {
        //         currentLargest = myDoubleArray[i];
        //     }
        // }
        // for (int i = 1; i < myDoubleArray.Length; i++)
        // {
        //     if (myDoubleArray[i] < currentSmallest)
        //     {
        //         currentSmallest = myDoubleArray[i];
        //     }
        // }
        // Console.WriteLine("The largest number in the array is " + currentLargest);
        // Console.WriteLine("The smallest number in the array is " + currentSmallest);

        // int[,] my2DArray = new int[3, 4] { { 1, 2, 3, 4 }, { 1, 1, 1, 1 }, { 2, 2, 2, 2 } };
        // for (int i = 0; i < my2DArray.GetLength(0); i++)
        // {
        //     for (int j = 0; j < my2DArray.GetLength(1); j++)
        //     {
        //         Console.Write(my2DArray[i, j] + "\t");
        //     }
        //     Console.WriteLine();
        // }

        // // .
        // List<String> myStudentList = new List<String>();
        // Random randomValue = new Random();
        // int randomNumber = randomValue.Next(1, 12);
        // Console.WriteLine("You now need to add" + randomNumber + " students to your class list");
        // for (int i = 0; i < randomNumber; i++)
        // {
        //     Console.WriteLine("Please enter the name of student " + (i) + ": ");
        //     myStudentList.Add(Console.ReadLine() ?? "");
        //     Console.WriteLine();
        // }
        // for (int i = 0; i < myStudentList.Count; i++)
        // {
        //     Console.WriteLine("The name of student " + (i) + " is " + myStudentList[i]);
        // }

        static bool Palindrome(int[] array)
        {
            if (array.Length < 1)
            {
                return false;
            }
            int n = array.Length;
            for (int i = 0; i < n / 2; i++)
            {
                if (array[i] != array[n - 1 - i])
                {
                    return false;
                }
            }
            return true;
        }
        int[] myPalArray = { 1, 2, 3, 8, 9, 8, 3, 2, 1 };
        if (Palindrome(myPalArray))
        {
            Console.WriteLine("The array is a palindrome.");
        }
        else
        {
            Console.WriteLine("The array is not a palindrome.");
        }

        static bool IsSorted(List<int> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i] > list[i + 1])
                {
                    return false;
                }
            }
            return true;
        }
        List<int> list_a = new List<int> { 1, 3, 5, 7, 9 };
        List<int> list_b = new List<int> { 1, 3, 6, 8, 9};
        List<int> mergedList = Merge(list_a, list_b);

        static List<int> Merge(List<int> list_a, List<int> list_b)
        {
            if (!IsSorted(list_a) || !IsSorted(list_b))
            {
                Console.WriteLine("Both lists must be sorted in ascending order.");
                return null;
            }

            List<int> mergedList = new List<int>();
            int i = 0, j = 0;

            while (i < list_a.Count && j < list_b.Count)
            {
                if (list_a[i] < list_b[j])
                {
                    mergedList.Add(list_a[i]);
                    i++;
                }
                else
                {
                    mergedList.Add(list_b[j]);
                    j++;
                }
            }

            while (i < list_a.Count)
            {
                mergedList.Add(list_a[i]);
                i++;
            }

            while (j < list_b.Count)
            {
                mergedList.Add(list_b[j]);
                j++;
            }

            return mergedList;
        }

        Console.WriteLine("Merged List:");
        for (int i = 0; i < mergedList.Count; i++)
        {
            Console.Write(mergedList[i] + ", ");
        }

        // int[,] grid = new int[,]
        // {
        //     { 0, 2, 4, 0, 9, 5 },
        //     { 7, 1, 3, 3, 2, 1 },
        //     { 1, 3, 9, 8, 5, 6 },
        //     { 4, 6, 7, 9, 1, 0 }
        // };

        // int[] result = ArrayConversion(grid);
        // Console.WriteLine("The converted array is:");
        // Console.WriteLine("{ " + string.Join(", ", result) + " }");

        // static int[] ArrayConversion(int[,] array)
        // {
        //     int rows = array.GetLength(0);
        //     int cols = array.GetLength(1);
        //     var odds = new List<int>();

        //     for (int c = 0; c < cols; c++)
        //     {
        //         for (int r = 0; r < rows; r++)
        //         {
        //             int value = array[r, c];
        //             if (value % 2 != 0)
        //             {
        //                 odds.Add(value);
        //             }
        //         }
        //     }

        //     return odds.ToArray();
        // }
    }

}