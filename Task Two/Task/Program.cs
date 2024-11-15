namespace Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            char c = '\0';
            bool isChar = false;
            do
            {
                Console.WriteLine("Menu Options");
                Console.WriteLine("P - Print numbers");
                Console.WriteLine("1 - sort the numbers");
                Console.WriteLine("A - Add a number");
                Console.WriteLine("M - Display mean of the numbers");
                Console.WriteLine("S - Display the smallest number");
                Console.WriteLine("L - Display the largest number");
                Console.WriteLine("F - Find a number");
                Console.WriteLine("C - Clear all numbers");
                Console.WriteLine("Q - Quit");

                Console.Write("Enter your choice: ");
                
                c = char.ToUpper(char.Parse(Console.ReadLine()));

                if (c == 'P')
                {
                    if (list.Count != 0)
                        Console.Write("[ ");

                    for (int i = 0; i < list.Count; i++)
                    {

                        Console.Write($"{list[i]} ");
                    }

                    if (list.Count == 0)
                        Console.WriteLine("[] - The list is empty.");
                    else
                        Console.Write("]\n");

                }else if (c == '1')
                {
                    if (list.Count == 0)
                        Console.WriteLine("[] - The list is empty.");
                    else
                    {
                        for (int i = 0; i < list.Count - 1; i++)
                        {
                            for (int j = 0; j < list.Count - 1 - i; j++)
                            {
                                if (list[j] > list[j + 1])
                                {                                   
                                    int temp = list[j];
                                    list[j] = list[j + 1];
                                    list[j + 1] = temp;
                                }
                            }
                        }
                        if (list.Count != 0)
                            Console.Write("[ ");
                        for (int i = 0; i < list.Count; i++)
                        {

                            Console.Write($"{list[i]} ");
                        }                      
                            Console.Write("]\n");
                        Console.WriteLine("The list is sorted");
                    }
                }
                else if (c == 'A')
                {
                    int entry = int.Parse(Console.ReadLine());
                    if (list.Contains(entry))
                    {
                        Console.WriteLine("Duplicate values are not allowed!");
                    }
                    else
                    {
                        list.Add(entry);
                        Console.WriteLine($"{list[^1]} added");
                    }
                    
                }
                else if (c == 'M')
                {
                    if (list.Count == 0)
                        Console.WriteLine("Unable to calculate the mean - no data");
                    else
                    {
                        int sum = 0;

                        for (int i = 0; i < list.Count; i++)
                        {
                            sum += list[i];
                        }
                        int avg = sum / list.Count;
                        Console.WriteLine($"The mean: {avg}");
                    }
                }
                else if (c == 'S')
                {
                    if (list.Count == 0)
                        Console.WriteLine("Unable to determine the smallest number - list is empty");
                    else
                    {
                        int smallest = list[0];
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i] < smallest)
                            {
                                smallest = list[i];
                            }
                        }

                        Console.WriteLine($"The smallest number is {smallest}");
                    }
                }
                else if (c == 'L')
                {
                    if (list.Count == 0)
                        Console.WriteLine("Unable to determine the largest number - list is empty");
                    else
                    {
                        int largest = list[0];
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i] > largest)
                            {
                                largest = list[i];
                            }
                        }

                        Console.WriteLine($"The largest number is {largest}");
                    }
                }
                else if (c == 'F')
                {
                    if (list.Count == 0)
                        Console.WriteLine("Can't find your number - list is empty");
                    else
                    {
                        int searchNum = int.Parse(Console.ReadLine());
                        bool found = false;

                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i] == searchNum)
                            {
                                Console.WriteLine($"Your number at the index: {i}");
                                found = true;
                                break;
                            }                               
                        }
                        if(!found)
                            Console.WriteLine("The number is not in the list.");
                    }
                }
                else if (c == 'C')
                {
                    if (list.Count == 0)
                        Console.WriteLine("No need! The list in empty");
                    else
                    {
                        list.Clear();
                        Console.WriteLine("You cleared the list!");
                    }
                }
                else if (c == 'Q')
                {
                    Console.WriteLine("Goodbye");
                }
                else
                    Console.WriteLine("Unvaild choice!");
                
            }
            while (c != 'Q');
        }
    }
}
