using System;

namespace RentBike
{
    class Program
    {
        static void Main(string[] args)
        {
            int bikes = 0;
            double total = 0;
            bool isFamily = false;

            Console.WriteLine("Welcome aboard! We are glad to rent you some bikes\n" +
                              "to spend some good time traveling by yourself or in\n" +
                              "company of your family, and making you life healthier :)\n");
            Console.WriteLine("Tell us how many people you are. If you are a family group,\n" +
                              "you'll have a 30% discount! (only 3 to 5 family members allowed):");


            DBConnector dBConnector = new DBConnector();

        }
    }
}
