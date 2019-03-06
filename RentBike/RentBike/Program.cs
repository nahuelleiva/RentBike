using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RentBike
{
    class Program
    {

        static void Main(string[] args)
        {
            int bikes = 0;
            int rentOptionSelected = 0;
            int d = 0;

            // Variable to keep open the console in any case that the client wants to
            // rent more bikes or not.
            bool keepOpen = true;
            DBConnector dBConnector = new DBConnector();
            string pathToFile = @"..\..\..\rentLog.txt";

            // We try to create the file that handle all of our messages
            RentBikeHelper.CreateFile(pathToFile);

            // Creating the database just once.
            try
            {
                dBConnector.CreateDB();
            }
            catch (Exception e)
            {
                throw;
            }

            // Show a presentation
            RentBikeHelper.HowManyBikes();

            // We'll try to keep the application open until the user hits the X button from the application
            while (keepOpen)
            {
                RentBikeModel rentBikeModel = new RentBikeModel();

                // We make sure that the input is a number
                // While is not a number, the app will continually ask for a valid input
                while (!int.TryParse(Console.ReadLine(), out bikes))
                {
                    RentBikeHelper.ClearScreen();
                    RentBikeHelper.HowManyBikes();
                }
                rentBikeModel.setBikes(bikes);

                // Then we check if the client has a family to make discounts afterwards
                RentBikeHelper.CheckIfFamilyGroup(rentBikeModel.getBikes(), rentBikeModel);
                Console.Clear();

                // Show rent type options here
                rentOptionSelected = RentBikeHelper.SelectOption();

                // Depending on the option that the user has selected we calculate totals
                RentBikeHelper.CheckRentType(rentOptionSelected, d, rentBikeModel);

                // We get the result message
                var message = RentBikeHelper.CalculateTotals(rentBikeModel);

                // We send the message to a queue
                RentBikeHelper.SendMessage(message);

                // We insert the new rent to our DB
                try
                {
                    dBConnector.InsertNewRent(rentBikeModel);
                }
                catch (Exception e)
                {
                    throw;
                }

                // Then we write the messages from the queue
                RentBikeHelper.RecieveMessage(pathToFile);
                

                // Then we ask to the client if he wants to do some other operations
                // In any case the app will remain open for use to future clients
                RentBikeHelper.RentAgain();
            }
        }
    }
}
