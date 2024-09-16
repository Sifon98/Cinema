using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                Console.WriteLine("HUVUDMENY - Skriv en siffra nedan och tryck enter för att testa en funktion" +
                                  "\n1. Bio, en person" +
                                  "\n2. Bio, flera personer" +
                                  "\n3. Upprepa inmatad text 10 gånger" +
                                  "\n4. Hitta tredje ordet i en mening" +
                                  "\n0. Stäng programmet");
                string input = Console.ReadLine();

                // check if the user input is indeed a number
                bool menuSuccess = int.TryParse(input, out int menuNumber);
                if (menuSuccess == false)
                    menuNumber = -1;

                switch (menuNumber)
                {
                    // simply close the program
                    case 0:
                        openProgram = false;
                        break;
                    // check the age of one cinema-goer, return a string depending on the age
                    case 1:
                        Console.Write("\nSkriv din ålder: ");
                        bool ageSuccess = int.TryParse(Console.ReadLine(), out int age);
                        if (ageSuccess)
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

                        break;
                    // handle muliple cinema-goers, calculate the number of people and the total cost
                    case 2:
                        Console.Write("\nSkriv antalet besökare: ");
                        int.TryParse(Console.ReadLine(), out int visitorInput);

                        // make sure that the user input is a number that is not negative, otherwise break the program
                        bool multipleAgeSuccess = true;
                        for (int i = 0; i < visitorInput; i++)
                        {
                            Console.Write($"Skriv åldern för besökare nummer {i + 1}: ");
                            multipleAgeSuccess = int.TryParse(Console.ReadLine(), out age);

                            if (multipleAgeSuccess == false || age < 0)
                            {
                                Console.Write("\nFelaktik inmatning, prova igen." + "\n");
                                break;
                            }
                            // store the visitors and their age
                            visitor.AddVisitor(age);
                        }

                        if (multipleAgeSuccess == false)
                        {
                            break;
                        }
                        // call a function to get all the visitors ages
                        IEnumerable<Age> visitors = visitor.GetVisitors();

                        int people = 0;
                        int total = 0;

                        // calculate the cost of the group
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

                        Console.WriteLine($"\nAntal personer: {people} st" + $"\nTotal kostnad: {total}kr");
                        break;
                    // repeat a sentence 10 times
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
                    // take in a sentence and then find the thirs word via the .Split function
                    case 4:
                        Console.Write("\nSkriv en mening med minst tre ord: ");
                        var solidInput = Console.ReadLine();
                        // pattern that removes multiple spaces
                        string pattern = @"\s+";
                        var splitInput = Regex.Split(solidInput, pattern);

                        // check to see if the user input is correct
                        if (splitInput.Length < 3 || splitInput[0].Length < 1 || splitInput[1].Length < 1 || splitInput[2].Length < 1)
                        {
                            Console.Write("\nFelaktik inmatning, se till att meningen inehåller minst 3 ord." + "\n");
                            break;
                        }

                        Console.WriteLine($"Det tredje ordet i din mening är: {splitInput[2]}");

                        break;
                    default:
                        Console.WriteLine("\nFelaktik inmatning, prova igen.");
                        break;
                }
                // just some neet styling for the program
                Console.WriteLine("\n==========================" + "\n");
            }
        }
    }
}
