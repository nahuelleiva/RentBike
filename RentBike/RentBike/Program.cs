using System;
using System.Text.RegularExpressions;

namespace RentBike
{
    class Program
    {

        static void Main(string[] args)
        {
            int bikes = 0;
            bool isFamily = false;
            int rentOptionSelected = 0;
            int chargeByRentType = 0;
            string rentType = "";
            int d = 0;

            //DBConnector dBConnector = new DBConnector();

            RentBikeHelper.HowManyBikes();
            RentBikeModel rentBikeModel = new RentBikeModel(bikes, 0, isFamily, rentType, chargeByRentType);

            while (!int.TryParse(Console.ReadLine(), out bikes))
            {
                RentBikeHelper.ClearScreen();
                RentBikeHelper.HowManyBikes();
            }
            RentBikeHelper.CheckIfFamilyGroup(bikes, rentBikeModel);
            Console.WriteLine("Select the rent type that you want for your bike(s):\n" +
                              "1 to select a hourly rent. We charge you $5 per hour.\n" +
                              "2 to select a daily rent. We charge you $20 per day.\n" +
                              "3 to select a weekly rent. We charge you $60 per week.");
            while (!int.TryParse(Console.ReadLine(), out rentOptionSelected))
            {
                RentBikeHelper.ClearScreen();
                Console.WriteLine("Select the rent type that you want for your bike(s):\n" +
                              "1 to select a hourly rent. We charge you $5 per hour.\n" +
                              "2 to select a daily rent. We charge you $20 per day.\n" +
                              "3 to select a weekly rent. We charge you $60 per week.");
            }
            RentBikeHelper.CheckRentType(rentOptionSelected, d, rentBikeModel);
            RentBikeHelper.CalculateTotals(rentBikeModel);
        }
    }
}
