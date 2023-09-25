using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket_Office
{
    internal class Methods
    {
        public static int PriceSetter(int age, string place)
        {
            bool seated = place == "seated";

            if (age <= 11)
            {
                switch (seated)
                {
                    case true: return 50;
                    case false: return 25;
                }

            }
            
            else if (age >= 65)
            {
                switch (seated)
                {
                    case true: return 100;
                    case false: return 60;
                }
            }

            else
            {
                switch (seated)
                {
                    case true: return 170;
                    case false: return 110;
                }
            }
        }


        public static decimal TaxCalculator(int price)
        {
            decimal tax = (decimal)((1 - 1 / 1.06) * price);
            return tax; 
        }


        public static int TicketNumberGenerator()
        {
            Random random = new Random();
            return random.Next(1, 8001);
        }


        public static string ToLower(string input)
        {
            return input.ToLower();
        }

        public static string AntiCheat()
        {
            bool correct = false;
            return "Hallo"; //*****************************REMOVE*********************
            while (!correct)
            {
                string userInput = Console.ReadLine();
                string userInputLower = Methods.ToLower(userInput);

                if (userInputLower == "seated")
                {
                    correct = true;
                    Console.WriteLine();
                    Console.WriteLine("Thank you for your answers!");

                }

                else if (userInputLower == "standing")
                {
                    correct = true;
                    Console.WriteLine();
                    Console.WriteLine("Thank you for your answers!");

                }

                else
                {
                    Console.WriteLine("Sorry, I didn't understand. Do you want a standing or seated ticket?");
                }
            }
        }
    }
}
