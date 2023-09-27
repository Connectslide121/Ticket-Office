using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket_Office
{
    internal class Methods
    {
        //************************************************************************************************************************************************************//

        public static int PriceSetter(int age, string place)
        {
            bool seated = place == "seated";

            int childSeated = 50;
            int childStanding = 25;
            int retiredSeated = 100;
            int retiredStanding = 60;
            int restSeated = 170;
            int restStanding = 110;

            if (age <= 11)
            {
                switch (seated)
                {
                    case true: return childSeated;
                    case false: return childStanding;
                }

            }
            
            else if (age >= 65)
            {
                switch (seated)
                {
                    case true: return retiredSeated;
                    case false: return retiredStanding;
                }
            }

            else
            {
                switch (seated)
                {
                    case true: return restSeated;
                    case false: return restStanding;
                }
            }
        }

        //************************************************************************************************************************************************************//

        public static decimal TaxCalculator(int price)
        {
            decimal tax = (decimal)((1 - 1 / 1.06) * price);
            return tax; 
        }

        //************************************************************************************************************************************************************//


        public static int TicketNumberGenerator()
        {
            Random random = new Random();
            return random.Next(1, 8001);
        }

        //************************************************************************************************************************************************************//

        public static int AskAge()
        {
            int userAge;

            do
            {
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out userAge))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please, I need your age to be a number :)");
                }

            }while (true);

            return userAge;
        }

        //************************************************************************************************************************************************************//


        public static string AskPlace()
        {
            string userPlace;

            do
            {
                userPlace = Console.ReadLine().ToLower();

                if (userPlace != "seated" && userPlace != "standing")
                {
                    Console.WriteLine("Sorry, I didn't understand. Do you want a standing or seated ticket?");
                }
                
            }

            while (userPlace != "seated" && userPlace != "standing");

            return userPlace;
            
        }

        //************************************************************************************************************************************************************//

    }
}
