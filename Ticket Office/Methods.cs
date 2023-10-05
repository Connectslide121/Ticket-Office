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

        public static PlaceOptions.CustomerPlacePreference GetCustomerPlacePreference()
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

            if (userPlace == "seated")
            {
                return PlaceOptions.CustomerPlacePreference.Seated;
            }
                    
            else
            {
                return PlaceOptions.CustomerPlacePreference.Standing;
            }
        }

        //************************************************************************************************************************************************************//



        //************************************************************************************************************************************************************//

    }
}
