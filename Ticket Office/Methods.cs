using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ticket_Office
{
    public class Methods
    {
        //************************************************************************************************************************************************************//

        public static int PriceSetter(int age, string place)
        {
            bool seated = place.ToLower() == "seated";

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

        public static int GetCustomerAge()
        {
            string userInput;
            int customerAge;
            bool correctLength;
            bool isNumber;

            do
            {
                userInput = Console.ReadLine();
                isNumber = true;
                correctLength = true;

                if (userInput.Length < 1 || userInput.Length > 3)
                {
                    Console.WriteLine("Please, insert a number between 0 and 999.");
                }
                else
                {
                    foreach (char c in userInput)
                    {
                        if (char.IsDigit(c))
                        {
                            isNumber = false;
                            correctLength = false;
                        }
                        else
                        {
                            Console.WriteLine("Please, insert a valid number (no letters).");
                        }
                        break;
                    }
                }
            }
            while (correctLength == true && isNumber == true);

            customerAge = Convert.ToInt32(userInput);

            return customerAge;
        }

        //************************************************************************************************************************************************************//


        public static string GetCustomerPlacePreference()
        {
            string userPlace;

            do
            {
                userPlace = Console.ReadLine().ToLower();

                if (userPlace != "seated" && userPlace != "standing")
                {
                    Console.WriteLine("Please enter a valid answer. Do you want a standing or seated ticket?");
                }

            }
            while (userPlace != "seated" && userPlace != "standing");

            string userPlaceFirstLetter = userPlace.Remove(1);
            string userPlaceFirstLetterCapitalized = userPlaceFirstLetter.ToUpper();
            string userPlaceRest = userPlace.Remove(0, 1);
            string userPlaceFormatted = userPlaceFirstLetterCapitalized+userPlaceRest;

            return userPlaceFormatted;
        }

        //************************************************************************************************************************************************************//

        public static bool CheckPlaceAvailability(string placeList, int placeNumber)
        {
            string searchPattern = $",{placeNumber},";

            if (placeList.Contains(searchPattern))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //************************************************************************************************************************************************************//

        public static string AddPlace(string placeList, int placeNumber)
        {
            placeList = $"{placeList}{placeNumber.ToString()},"; 
            return placeList ;
        }

        //************************************************************************************************************************************************************//

        public static string RandomListGenerator(int howManyNumbers)
        {
            string placeList = ",";
            int randomNumber;
            bool available;

            for (int i = 0; i < howManyNumbers; i++)
            {
                do
                {
                    randomNumber = TicketNumberGenerator();
                    available = CheckPlaceAvailability(placeList, randomNumber);
                }
                while (available == false);

                placeList += $"{randomNumber},";
            }
            return placeList ;
        }

        //************************************************************************************************************************************************************//

    }
}
