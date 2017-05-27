using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication5
{
    class Program
    {
        private static int ncol;
        private static int[,] cities;
        private static int nrow;
        private static int[] shortestPath;
        private static int shortestPathLength;
        private static int citiesToVisit;

        public static void getDistance(int[] permutationHolders)
        {
            int tempSP = 0;
            for (int i = 0; i < permutationHolders.Length - 1; i++)
            {
                tempSP += cities[permutationHolders[i], permutationHolders[i + 1]];
            }
            tempSP += cities[permutationHolders[shortestPath.Length - 1], permutationHolders[0]];

            if (tempSP < shortestPathLength)
            {
                shortestPathLength = tempSP;
                for (int i = 0; i < shortestPath.Length; i++)
                {
                    shortestPath[i] = permutationHolders[i];
                }
            }
        }
        public static bool NextPermutation<T>(T[] elements) where T : IComparable<T>
        {

            var count = elements.Length;


            var done = true;


            for (var i = count - 1; i > 0; i--)
            {
                var curr = elements[i];


                if (curr.CompareTo(elements[i - 1]) < 0)
                {
                    continue;
                }


                done = false;


                var prev = elements[i - 1];


                var currIndex = i;


                for (var j = i + 1; j < count; j++)
                {

                    var tmp = elements[j];

                    if (tmp.CompareTo(curr) < 0 && tmp.CompareTo(prev) > 0)
                    {
                        curr = tmp;
                        currIndex = j;
                    }
                }


                elements[currIndex] = prev;
                elements[i - 1] = curr;


                for (var j = count - 1; j > i; j--, i++)
                {
                    var tmp = elements[j];
                    elements[j] = elements[i];
                    elements[i] = tmp;
                }


                break;
            }


            return done;
        }


        public static void printArray()
        {
            for (int i = 0; i < shortestPath.Length; i++)
            {
                Console.Write(shortestPath[i] + " ");
            }
            Console.Write(shortestPath[0]);
        }

        public static IEnumerable<int[]> Combinations(int m, int n)
        {
            int[] result = new int[m];
            Stack<int> stack = new Stack<int>();
            stack.Push(0);

            while (stack.Count > 0)
            {
                int index = stack.Count - 1;
                int value = stack.Pop();

                while (value < n)
                {
                    result[index++] = value++;
                    stack.Push(value);
                    if (index == m)
                    {
                        yield return result;
                        break;
                    }
                }
            }
        }

        static void Main()
        {
          
            Console.WriteLine("Please enter the total cities that nead to be visited ");
            citiesToVisit = int.Parse(Console.ReadLine());
            shortestPath = new int[citiesToVisit];
            Console.WriteLine("Please Enter Array filename");
            string text;
            string filename = Console.ReadLine();
            try
            {
                StreamReader tr = new StreamReader(filename);
                int arraySize = int.Parse(tr.ReadLine());
                //              arrayLengthG = arraySize;
                Console.WriteLine("Size of Array is " + arraySize);
                cities = new int[arraySize, arraySize];
                nrow = 0;
                do
                {
                    text = tr.ReadLine();
                    //                   Console.WriteLine(text);
                    if (text != null)
                    {
                        ncol = 0;
                        foreach (string substring in text.Split(' '))
                        {
                            if (substring.Length > 0)
                            {
                                cities[nrow, ncol] = Int32.Parse(substring);
                                ncol += 1;
                            }
                        }
                        nrow += 1;
                    }
                } while (text != null);
                tr.Close();
            }
            catch
            {
                Console.WriteLine("File Read Error");
            }
            shortestPathLength = 0;
            for (int i = 0; i < shortestPath.Length - 1; i++)
            {
                shortestPathLength += cities[i, i+1];
            }
            shortestPathLength += cities[shortestPath.Length-1,0];
            //            Console.WriteLine("Test Shortest Path is " + shortestPathLength);
            for (int i = 0; i < shortestPath.Length; i++)
            {
                shortestPath[i] = i;
            }  
            
            foreach (int[] c in Combinations(citiesToVisit,cities.GetLength(0)))
            {
                int[] x = new int[c.Length];
                Array.Copy(c, x, c.Length);
                while (!NextPermutation(x))
                {
                    getDistance(x);
                    /*
                    for (int i = 0; i < c.Length; i++)
                    {
                        Console.Write(c[i] + " ");
                    }
                    Console.WriteLine();
                     */
                }
            }
            Console.Write("The shortest tour is ");
            printArray();
            Console.WriteLine();
            Console.WriteLine("The length of this tour is " + shortestPathLength);
            string output = "";
            output = "The order of tour is ";
            foreach (int x in shortestPath)
            {
                switch (x)
                {
                    case 0:
                        output += "A ";
                        break;
                    case 1:
                        output += "B ";
                        break;
                    case 2:
                        output += "C ";
                        break;
                    case 3:
                        output += "D ";
                        break;
                    case 4:
                        output += "E ";
                        break;
                    case 5:
                        output += "F ";
                        break;
                    case 6:
                        output += "G ";
                        break;
                    case 7:
                        output += "H ";
                        break;
                    case 8:
                        output += "I ";
                        break;
                    case 9:
                        output += "J ";
                        break;
                    case 10:
                        output += "K ";
                        break;
                    case 11:
                        output += "L ";
                        break;
                    case 12:
                        output += "M ";
                        break;
                    case 13:
                        output += "N ";
                        break;
                    case 14:
                        output += "O ";
                        break;
                    case 15:
                        output += "P ";
                        break;
                    default:
                        break;
                }
            }
            switch (shortestPath[0])
            {
                case 0:
                    output += "A ";
                    break;
                case 1:
                    output += "B ";
                    break;
                case 2:
                    output += "C ";
                    break;
                case 3:
                    output += "D ";
                    break;
                case 4:
                    output += "E ";
                    break;
                case 5:
                    output += "F ";
                    break;
                case 6:
                    output += "G ";
                    break;
                case 7:
                    output += "H ";
                    break;
                case 8:
                    output += "I ";
                    break;
                case 9:
                    output += "J ";
                    break;
                case 10:
                    output += "K ";
                    break;
                case 11:
                    output += "L ";
                    break;
                case 12:
                    output += "M ";
                    break;
                case 13:
                    output += "N ";
                    break;
                case 14:
                    output += "O ";
                    break;
                case 15:
                    output += "P ";
                    break;
                default:
                    break;
            }
            output += "\r\n";
            output += "\r\n";

            foreach (int x in shortestPath)
            {
                switch (x)
                {
                    case 0:
                        output += "A ";
                        break;
                    case 1:
                        output += "B ";
                        break;
                    case 2:
                        output += "C ";
                        break;
                    case 3:
                        output += "D ";
                        break;
                    case 4:
                        output += "E ";
                        break;
                    case 5:
                        output += "F ";
                        break;
                    case 6:
                        output += "G ";
                        break;
                    case 7:
                        output += "H ";
                        break;
                    case 8:
                        output += "I ";
                        break;
                    case 9:
                        output += "J ";
                        break;
                    case 10:
                        output += "K ";
                        break;
                    case 11:
                        output += "L ";
                        break;
                    case 12:
                        output += "M ";
                        break;
                    case 13:
                        output += "N ";
                        break;
                    case 14:
                        output += "O ";
                        break;
                    case 15:
                        output += "P ";
                        break;
                    default:
                        break;
                }
                foreach (int y in shortestPath)
                {
                    output += cities[x, y] + " \t";
                }
                output += "\r\n";
            }

            StreamWriter w = new StreamWriter("Prob4Output.txt");
            w.Write(output);
            w.Close();
            Console.ReadKey();
            Console.ReadKey();
        }


    }
}
