using System;

namespace RentBike
{
    /// <summary>
    /// Helper class to manage console presentations and inputs from users
    /// </summary>
    public class RentBikeHelper
    {
        public static void ClearScreen()
        {
            Console.WriteLine("Please, enter a correct value :)");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
        }

        public static void SelectOption() {
            Console.WriteLine("Select the rent type that you want for your bike(s):\n" +
                                  "1 to select a hourly rent. We charge you $5 per hour.\n" +
                                  "2 to select a daily rent. We charge you $20 per day.\n" +
                                  "3 to select a weekly rent. We charge you $60 per week.");
        }

        public static void HowManyBikes()
        {
            Console.WriteLine("Welcome aboard! We are glad to rent you bikes\n" +
                              "to spend some good time traveling by yourself or in\n" +
                              "company of your family, and making you life healthier :)\n");
            Console.WriteLine("Tell us how many people you are. If you are a family group,\n" +
                              "you'll have a 30% discount! (only 3 to 5 family members allowed):");
        }

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

        public static void CheckIfFamilyGroup(int bikes_, RentBikeModel rentBikeModel)
        {
            rentBikeModel.setIsFamily(0);
            if (bikes_ >= 3 && bikes_ <= 5)
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

        public static void CheckRentType(int rentOptionSelected_, int d, RentBikeModel rentBikeModel)
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

        public static void CalculateTotals(RentBikeModel rentBikeModel) {
            rentBikeModel.setTotal(rentBikeModel.getChargeByRentType() * rentBikeModel.getD());
            rentBikeModel.MakeFamilyDiscount();

            Console.WriteLine(string.Format("Okay! We are finally done :) next we'll show you\n" +
                                            "the information of your rent:\n" +
                                            "Bikes: {0} Rent type choosen: {1} Total: {2}", 
                                            rentBikeModel.getBikes(), rentBikeModel.getRentType(), 
                                            rentBikeModel.getTotal()));
        }
    }
}
