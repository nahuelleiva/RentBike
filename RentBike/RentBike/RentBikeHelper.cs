using System;
using System.Collections.Generic;
using System.IO;

namespace RentBike
{
    /// <summary>
    /// Helper class to manage console presentations and inputs from users
    /// </summary>
    public class RentBikeHelper
    {
        static bool isFileCreated = false;
        static Queue<string> messageQueue = new Queue<string>();
        static RentBikeModel rentBikeModel = new RentBikeModel();
        static DBConnector dBConnector = new DBConnector();

        /// <summary>
        /// Clears the screen and display a brief message if the input was incorrect
        /// </summary>
        public static void ClearScreen()
        {
            Console.Clear();
            Console.WriteLine("Please, enter a correct value :)");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
        }

        /// <summary>
        /// Displays the different types of bike rents that the user has to choose and returns the option selected
        /// </summary>
        /// <returns>int</returns>
        public static int SelectOption() {
            int rentOptionSelected = 0;
            Console.WriteLine("Select the rent type that you want for your bike(s):\n" +
                                  "1 to select a hourly rent. We charge you $5 per hour.\n" +
                                  "2 to select a daily rent. We charge you $20 per day.\n" +
                                  "3 to select a weekly rent. We charge you $60 per week.");
            while (!int.TryParse(Console.ReadLine(), out rentOptionSelected) || rentOptionSelected == 0 || rentOptionSelected > 3)
            {
                ClearScreen();
                Console.WriteLine("Let's try again! This time choose an option from 1 to 3, please :)");
                Console.WriteLine("Select the rent type that you want for your bike(s):\n" +
                                  "1 to select a hourly rent. We charge you $5 per hour.\n" +
                                  "2 to select a daily rent. We charge you $20 per day.\n" +
                                  "3 to select a weekly rent. We charge you $60 per week.");
            }
            return rentOptionSelected;
        }

        /// <summary>
        /// Shows a brief presentation to the application and ask for the amount of people that want to ride bikes
        /// </summary>
        public static void HowManyBikes()
        {
            var bikes = 0;
            Console.WriteLine("Welcome aboard! We are glad to rent you bikes\n" +
                              "to spend some good time traveling by yourself or in\n" +
                              "company of your family, and making you life healthier :)\n");
            Console.WriteLine("Tell us how many people you are. If you are a family group,\n" +
                              "you'll have a 30% discount! (only 3 to 5 family members allowed):");
            while (!int.TryParse(Console.ReadLine(), out bikes))
            {
                Console.Clear();
                Console.WriteLine("Let's try again!");
                Console.WriteLine("Tell us how many people you are. If you are a family group,\n" +
                                  "you'll have a 30% discount! (only 3 to 5 family members allowed):");
            }
            rentBikeModel.setBikes(bikes);

        }

        /// <summary>
        /// Shows a message in any case that the users wants to keep renting bikes or not
        /// </summary>
        public static void RentAgain() {
            Console.WriteLine("=======================================================");
            Console.WriteLine("Do you want to rent more bikes? Y or N for confirmation:");
            string answer = Console.ReadLine();
            while (answer.ToUpper() != "Y" && answer.ToUpper() != "N")
            {
                ClearScreen();
                Console.WriteLine("Let's do it again! This time, try to put Y or N if you want to rent more bikes :)");
                RentAgain();
            }
            Console.WriteLine("We hope you enjoy your day! :D see you next time!");
            System.Threading.Thread.Sleep(2000);
            Console.Clear();
            HowManyBikes();
        }

        /// <summary>
        /// Check if it is a familiar group
        /// </summary>
        public static void CheckIfFamilyGroup()
        {
            rentBikeModel.setIsFamily(0);
            if (rentBikeModel.getBikes() >= 3 && rentBikeModel.getBikes() <= 5)
            {
                Console.Clear();
                Console.WriteLine("Are you a family group? Type Y or N:");
                var input = Console.ReadLine();
                while (input.ToUpper() != "Y" && input.ToUpper() != "N")
                {
                    ClearScreen();
                    Console.WriteLine("Let's do it again! This time, try to put Y or N to check if you are a family group :)");
                    Console.WriteLine("Are you a family group? Type Y or N:");
                    input = Console.ReadLine();
                }
                switch (input.ToUpper())
                {
                    case "Y":
                        rentBikeModel.setIsFamily(1);
                        break;
                    case "N":
                        rentBikeModel.setIsFamily(0);
                        break;
                }
            }
        }

        /// <summary>
        /// Taking the type of rent selected sets the correspondent money charge
        /// </summary>
        /// <param name="rentOptionSelected_">Rent type option</param>
        /// <param name="d">Amount of days/hours/weeks that the bikes will be rented</param>
        public static void CheckRentType(int rentOptionSelected_, int d)
        {
            switch (rentOptionSelected_)
            {
                case 1:
                    Console.WriteLine("For how many hours you'll rent the bikes?");
                    while (!int.TryParse(Console.ReadLine(), out d))
                    {
                        ClearScreen();
                        Console.WriteLine("For how many hours you'll rent the bikes?");
                    }
                    rentBikeModel.setD(d);
                    rentBikeModel.setChargeByRentType((int)RentType.Hour);
                    rentBikeModel.setRentType("Hourly");
                    break;
                case 2:
                    Console.WriteLine("For how many days you'll rent the bikes?");
                    while (!int.TryParse(Console.ReadLine(), out d))
                    {
                        ClearScreen();
                        Console.WriteLine("For how many days you'll rent the bikes?");
                    }
                    rentBikeModel.setD(d);
                    rentBikeModel.setChargeByRentType((int)RentType.Daily);
                    rentBikeModel.setRentType("Daily");
                    break;
                case 3:
                    Console.WriteLine("For how many weeks you'll rent the bikes?");
                    while (!int.TryParse(Console.ReadLine(), out d))
                    {
                        ClearScreen();
                        Console.WriteLine("For how many weeks you'll rent the bikes?");
                    }
                    rentBikeModel.setD(d);
                    rentBikeModel.setChargeByRentType((int)RentType.Weekly);
                    rentBikeModel.setRentType("Weekly");
                    break;
            }


        }

        /// <summary>
        /// Calculates the total of the rent and returns a message to be written in a log file
        /// </summary>
        /// <returns></returns>
        public static string CalculateTotals() {
            rentBikeModel.setTotal(rentBikeModel.getChargeByRentType() * rentBikeModel.getD());
            rentBikeModel.MakeFamilyDiscount();

            Console.WriteLine(string.Format("Okay! We are finally done :) next we'll show you\n" +
                                            "the information of your rent:\n" +
                                            "Bikes: {0} Rent type choosen: {1} Total: {2}", 
                                            rentBikeModel.getBikes(), rentBikeModel.getRentType(), 
                                            rentBikeModel.getTotal()));
            string message = string.Format("Operation time: {0}, Bikes: {1}, Rent type: {2}, Quantity: {3}, Total: {4}",
                                           DateTime.Now.ToString(), rentBikeModel.getBikes(), rentBikeModel.getRentType(), 
                                           rentBikeModel.getD(), rentBikeModel.getTotal());

            // We create the database once and try to insert the new Rent
            try
            {
                dBConnector.CreateDB();
                dBConnector.InsertNewRent(rentBikeModel);
            }
            catch (Exception e)
            {
                throw;
            }

            return message;
        }

        /// <summary>
        /// Creates the log file
        /// </summary>
        /// <param name="pathToFile">Path to the log file to be created</param>
        public static void CreateFile(string pathToFile) {
            if (!File.Exists(Path.GetFullPath(pathToFile)))
            {
                try
                {
                    File.Create(Path.GetFullPath(pathToFile));
                    isFileCreated = true;
                }
                catch (Exception e)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Enqueue the message to be written in the log file
        /// </summary>
        /// <param name="message">Message to be written in log file</param>
        public static void SendMessage(string message) {
            messageQueue.Enqueue(message);
        }

        /// <summary>
        /// Writes the message in the log file
        /// </summary>
        /// <param name="pathToFile">Path to the log file</param>
        public static void RecieveMessage(string pathToFile) {
            foreach (var item in messageQueue)
            {
                File.AppendAllText(Path.GetFullPath(pathToFile), item + Environment.NewLine);
            }
        }
        
    }
}
