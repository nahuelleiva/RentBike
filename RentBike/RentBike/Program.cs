using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RentBike
{
    class Program
    {

        static void Main(string[] args)
        {
            int rentOptionSelected = 0;
            int d = 0;

            // Variable to keep open the console in any case that the client wants to
            // rent more bikes or not.
            bool keepOpen = true;
            string pathToFile = @"..\..\..\rentLog.txt";

            // We try to create the file that handle all of our messages
            RentBikeHelper.CreateFile(pathToFile);

            // We'll try to keep the application open until the user hits the X button from the application
            while (keepOpen)
            {
                // Show a presentation
                RentBikeHelper.HowManyBikes();

                // Then we check if the client has a family to make discounts afterwards
                RentBikeHelper.CheckIfFamilyGroup();
                Console.Clear();

                // Show rent type options here
                rentOptionSelected = RentBikeHelper.SelectOption();

                // Depending on the option that the user has selected we calculate totals
                RentBikeHelper.CheckRentType(rentOptionSelected, d);

                // We get the result message
                var message = RentBikeHelper.CalculateTotals();

                // We send the message to a queue
                RentBikeHelper.SendMessage(message);

                // Then we write the messages from the queue
                RentBikeHelper.RecieveMessage(pathToFile);
                

                // Then we ask to the client if he wants to do some other operations
                // In any case the app will remain open for use to future clients
                RentBikeHelper.RentAgain();
            }
        }
    }
}
