using System;
using System.Collections.Generic;
using System.Text;

namespace RentBike
{
    public class RentBikeHelper
    {
        public static void ClearScreen()
        {
            Console.WriteLine("Please, enter a correct value :)");
            Console.ReadKey();
            Console.Clear();
        }

        public static void HowManyBikes()
        {
            Console.WriteLine("Welcome aboard! We are glad to rent you some bikes\n" +
                              "to spend some good time traveling by yourself or in\n" +
                              "company of your family, and making you life healthier :)\n");
            Console.WriteLine("Tell us how many people you are. If you are a family group,\n" +
                              "you'll have a 30% discount! (only 3 to 5 family members allowed):");
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
                    rentBikeModel.setChargeByRentType((int)RentType.Daily);
                    rentBikeModel.setRentType("Daily");
                    break;
                case 3:
                    Console.WriteLine("For how many hours you'll rent the bikes?");
                    while (!int.TryParse(Console.ReadLine(), out d))
                    {
                        ClearScreen();
                        Console.WriteLine("For how many ours you'll rent the bikes?");
                    }
                    rentBikeModel.setChargeByRentType((int)RentType.Weekly);
                    rentBikeModel.setRentType("Weekly");
                    break;
            }
        }

        public static void CheckIfFamilyGroup(int bikes_, RentBikeModel rentBikeModel)
        {
            if (bikes_ >= 3 && bikes_ <= 5)
            {
                Console.WriteLine("Are you a family group? Type Y or N:");
                var input = Console.ReadLine();
                while (input.ToUpper() != "Y" && input.ToUpper() != "N")
                {
                    ClearScreen();
                    Console.WriteLine("Let's do it again! This time, try to put Y or N to check if you are a family group :)");
                    CheckIfFamilyGroup(bikes_, rentBikeModel);
                }

                switch (input.ToUpper())
                {
                    case "Y":
                        rentBikeModel.setIsFamily(true);
                        break;
                    case "N":
                        rentBikeModel.setIsFamily(false);
                        break;
                }
            }
            else
            {
                rentBikeModel.setIsFamily(false);
            }
        }

        public static void CalculateTotals(RentBikeModel rentBikeModel) {
            var bikes = rentBikeModel.getBikes();
            var charByRentType = rentBikeModel.getChargeByRentType();
            var d = rentBikeModel.getD();
            var rentType = rentBikeModel.getRentType();
            var total = charByRentType * d;
            rentBikeModel.setTotal(total);
            rentBikeModel.MakeFamilyDiscount();

            Console.WriteLine(string.Format("Okay! We are finally done :) next we'll show you\n" +
                                            "the information of your rent:\n" +
                                            "Bikes: {0} Rent type choosen: {1} Total: {2}", bikes, rentType, total));
            Console.WriteLine("We hope you enjoy your day! :D see you next time!");
            Console.ReadLine();
        }
    }
}
