using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool openProgram = true;

            Visitors visitor = new Visitors();

            while (openProgram)
            {
                Console.WriteLine("HUVUDMENY BIO - Skriv en siffra nedan och tryck enter" +
                                  "\n1. En person" +
                                  "\n2. Flera personer" +
                                  "\n3. Loop" +
                                  "\n4. Split" +
                                  "\n5. Stäng programmet");
                string input = Console.ReadLine();

                int.TryParse(input, out int menuNumber);

                switch (menuNumber)
                {
                    case 1:
                        Console.Write("\nSkriv din ålder: ");
                        bool success = int.TryParse(Console.ReadLine(), out int age);
                        if (success)
                        {
                            if (age < 0)
                            {
                                Console.Write("\nFelaktik inmatning, prova igen." + "\n");
                            }
                            else if (age < 20)
                            {
                                Console.Write("\nUngdomspris: 80kr" + "\n");
                            }
                            else if (age > 64)
                            {
                                Console.Write("\nPensionärspris: 90kr" + "\n");
                            }
                            else
                            {
                                Console.Write("\nStandardpris: 120kr" + "\n");
                            }
                        }
                        else
                        {
                            Console.Write("\nFelaktik inmatning, prova igen." + "\n");
                        }

                        //payroll.AddEmployee(employeeName, employeSalary);
                        break;
                    case 2:
                        Console.Write("\nSkriv antalet besökare: ");
                        int.TryParse(Console.ReadLine(), out int visitorInput);

                        for (int i = 0; i < visitorInput; i++)
                        {
                            Console.Write($"Skriv åldern för besökare nummer {i + 1}: ");
                            int.TryParse(Console.ReadLine(), out age);
                            visitor.AddVisitor(age);
                        }
                        
                        IEnumerable<Age> visitors = visitor.GetVisitors();

                        int people = 0;
                        int total = 0;

                        foreach (var singleVisitor in visitors)
                        {
                            if (singleVisitor.VisitorAge < 20)
                            {
                                total += 80;
                            }
                            else if (singleVisitor.VisitorAge > 64)
                            {
                                total += 90;
                            }
                            else
                            {
                                total += 120;
                            }
                            people++;
                        }

                        Console.WriteLine($"\nAntal personer: {people}st" + $"\nTotal kostnad: {total}kr");
                        break;
                    case 3:
                        Console.Write("\nSkriv en mening som kommer upprepas: ");
                        string sentence = Console.ReadLine();

                        for (int i = 0; i < 10; i++)
                        {
                            if (i == 9)
                                Console.Write($"{sentence}\n");
                            else
                                Console.Write($"{sentence}, ");
                        }

                        break;
                    case 4:
                        Console.Write("\nSkriv en mening med minst tre ord: ");
                        var solidInput = Console.ReadLine();

                        string[] splitInput = solidInput.Split(' ');

                        if (splitInput.Length < 3)
                        {
                            Console.Write("\nFelaktik inmatning, prova igen." + "\n");
                            break;
                        }

                        Console.WriteLine($"Det tredje ordet i din mening är: {splitInput[2]}");

                        break;
                    case 5:
                        openProgram = false;
                        break;
                    default:
                        Console.WriteLine("\nFelaktik inmatning, prova igen.");
                        break;
                }

                Console.WriteLine("\n==========================" + "\n");
            }
        }
    }
}
