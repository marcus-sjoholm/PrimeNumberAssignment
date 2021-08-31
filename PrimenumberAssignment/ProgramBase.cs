using System;
using System.Collections.Generic;

/// <summary>
/// Marcus Sjöholm
/// </summary>
namespace PrimenumberAssignment
{
    internal static class PrimeProgram
    {
        /// <summary>
        /// List of all saved prime numbers
        /// </summary>
        public static List<int> savedPrimeNumbers = new List<int>();

        /// <summary>
        /// Asks user to input an integer,
        /// then sending the number to be evaluated -
        /// if it´s a prime or not
        /// </summary>
        public static void AddPotentialPrimeNumber()
        {
            bool valid = false;
            while (!valid)
            {
                Console.WriteLine("Enter a number: ");
                string num = Console.ReadLine();
                if (int.TryParse(num, out int number))
                {
                    bool isPrime = PrimeChecker(Convert.ToInt32(num));
                    IsNumberPrime(number, isPrime);
                    valid = true;
                }
                else
                {
                    WrongInputMustBeNumber();
                }
            }
        }

        /// <summary>
        /// Gives user the ability to clear the list of it´s content
        /// </summary>
        public static void ClearListOfContent()
        {
            try
            {
                switch (savedPrimeNumbers.Count)
                {
                    case 0:
                        {
                            Console.WriteLine("List is already empty");
                            NewLineInConsole();
                            break;
                        }

                    default:
                        {
                            savedPrimeNumbers.Clear();
                            Console.WriteLine("All saved prime numbers have been removed, the list is now empty");
                            NewLineInConsole();
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                ExceptionError(ex);
            }
        }

        /// <summary>
        /// Visual confirmation that the program is stopped
        /// </summary>
        public static void ClosingMessage()
        {
            Console.WriteLine("Program is closing");
        }

        /// <summary>
        /// Display saved prime numbers in console
        /// Will give an error if the list is empty
        /// </summary>
        /// <returns>Goes through and print prime numbers</returns>
        public static List<int>.Enumerator DisplaySavedPrimeNumbers()
        {
            if (savedPrimeNumbers.Count == 0)
            {
                ListIsEmpty();
            }

            var en = savedPrimeNumbers.GetEnumerator();

            while (en.MoveNext())
            {
                Console.WriteLine($"{en.Current}");
            }

            return en;
        }

        /// <summary>
        /// Show exception error from try-catch
        /// </summary>
        /// <param name="ex">Exception variable</param>
        public static void ExceptionError(Exception ex)
        {
            Console.WriteLine("Error: " + ex);
        }

        /// <summary>
        /// After checking if users input is prime or not,
        /// it will either save the number to the list
        /// or tell user it´s not a prime and enter another number
        /// </summary>
        /// <param name="num">Number input from user</param>
        /// <param name="isPrime">Is the number prime? True or False</param>
        public static void IsNumberPrime(int num, bool isPrime)
        {
            try
            {
                if (isPrime)
                {
                    if (num == 1)
                    {
                        Console.WriteLine($"{num} is not a prime number");
                        NewLineInConsole();
                    }
                    else
                    {
                        Console.WriteLine(num + " is a prime number");
                        SavePrimenumbers(num);
                        NewLineInConsole();
                    }
                }
                else if (!isPrime)
                {
                    Console.WriteLine($"{num} is not a prime number");
                    NewLineInConsole();
                }
            }
            catch (Exception ex)
            {
                ExceptionError(ex);
            }
        }

        /// <summary>
        /// Displays an error if list is empty
        /// </summary>
        public static void ListIsEmpty()
        {
            NewLineInConsole();
            Console.WriteLine("Error: The list is empty");
        }

        /// <summary>
        /// Checks if user input a number,
        /// will give an error message if user write anything else
        /// than what menu offers
        /// </summary>
        public static void LoopMenuOptions()
        {
            var userInput = MenuOptions();
            try
            {
                if (!int.TryParse(userInput, out _))
                {
                    WrongInput();
                }
                else
                {
                    RunProgramFromUserChoice(userInput);
                }
            }
            catch (Exception ex)
            {
                ExceptionError(ex);
            }
        }

        /// <summary>
        /// Loops the menu
        /// </summary>
        public static void MenuLoop()
        {
            while (true)
            {
                LoopMenuOptions();
            }
        }

        /// <summary>
        /// Shows menu options and let user input their choice
        /// </summary>
        /// <returns>Returns what user choose from menu</returns>
        public static string MenuOptions()
        {
            MenuOptionText();
            string userInput = Console.ReadLine();
            Console.Clear();
            return userInput;
        }

        /// <summary>
        /// The different options the user have to choose from
        /// </summary>
        public static void MenuOptionText()
        {
            Console.WriteLine("Enter '1' to check if a number is a prime number " +
                            "\nEnter '2' to see stored prime numbers " +
                            "\nEnter '3' Show next prime number " +
                            "\nEnter '4' to empty the list of saved prime numbers" +
                            "\nEnter '5' to exit program");
        }

        /// <summary>
        /// Adds a new line in console to make UI easier to read
        /// </summary>
        public static void NewLineInConsole()
        {
            Console.WriteLine("\n");
        }

        /// <summary>
        /// Adds one to highest known prime number and when the program finds next primenumber it
        /// stops and adds it to the list of saved prime numbers
        /// Will display an error if there is no prime numbers saved in list already
        /// </summary>
        public static void NextPrimeNumber()
        {
            switch (savedPrimeNumbers.Count)
            {
                case 0:
                    break;

                default:
                    {
                        var highest = savedPrimeNumbers[^1] + 1;

                        while (true)
                        {
                            try
                            {
                                if (PrimeChecker(highest))
                                {
                                    SavePrimenumbers(highest);
                                    return;
                                }
                                else
                                {
                                    highest++;
                                }
                            }
                            catch (Exception ex)
                            {
                                ExceptionError(ex);
                            }
                        }
                    }
            }
        }

        /// <summary>
        /// Checks if the input number is a prime or not
        /// </summary>
        /// <param name="num">Number input from user</param>
        /// <returns></returns>
        public static bool PrimeChecker(int num)
        {
            bool isPrime = true;
            try
            {
                for (var p = 2; p < num; p++)
                {
                    if (num % p == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError(ex);
            }

            return isPrime;
        }

        /// <summary>
        /// Checks users input and execute it
        /// </summary>
        /// <param name="userInput">Users input from menu</param>
        public static void RunProgramFromUserChoice(string userInput)
        {
            try
            {
                switch (userInput)
                {
                    case "1":
                        {
                            AddPotentialPrimeNumber();
                            break;
                        }

                    case "2":
                        {
                            Console.Clear();
                            Console.WriteLine("Saved prime numbers:");
                            DisplaySavedPrimeNumbers();
                            NewLineInConsole();
                            break;
                        }

                    case "3":
                        {
                            Console.WriteLine("Next prime is displayed incrementally");
                            NextPrimeNumber();
                            DisplaySavedPrimeNumbers();
                            NewLineInConsole();
                            break;
                        }
                    case "4":
                        {
                            ClearListOfContent();
                            break;
                        }
                    case "5":
                        {
                            ClosingMessage();
                            Environment.Exit(1);
                            break;
                        }

                    default:
                        {
                            WrongInput();
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                ExceptionError(ex);
            }
        }

        /// <summary>
        /// Saves prime numbers to list, if the number already exsists it will not be added again
        /// to remove redundancy, it will also sorts the prime numbers incrementally
        /// </summary>
        /// <param name="num">Number input from user</param>
        public static void SavePrimenumbers(int num)
        {
            try
            {
                if (!savedPrimeNumbers.Contains(num))
                {
                    savedPrimeNumbers.Add(num);
                    savedPrimeNumbers.Sort();
                }
            }
            catch (Exception ex)
            {
                ExceptionError(ex);
            }
        }

        /// <summary>
        /// Display in console that the user
        /// didn´t choose any of the available choices
        /// </summary>
        public static void WrongInput()
        {
            Console.WriteLine("Error: Wrong input, please choose a number between 1-5");
            NewLineInConsole();
        }

        /// <summary>
        /// Display in console that the user
        /// didn´t input a number
        /// </summary>
        public static void WrongInputMustBeNumber()
        {
            Console.Clear();
            Console.WriteLine("Error: Input is not a number");
            NewLineInConsole();
        }
    }
}