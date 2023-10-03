using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace Ticket_Office
{
    public class Ticket
    {
        public int Age { get; set; }
        public PlaceOptions.CustomerPlacePreference Place { get; set; }
        public int Number { get; set; }

        
        public Ticket(int age, PlaceOptions.CustomerPlacePreference place)
        {
            Age = age;
            Place = place;
            Number = Methods.TicketNumberGenerator();
        }


        public int Price()
        {
            int childSeated = 50;
            int childStanding = 25;
            int retiredSeated = 100;
            int retiredStanding = 60;
            int restSeated = 170;
            int restStanding = 110;

            if (Age <= 11 && Place == PlaceOptions.CustomerPlacePreference.Seated)
            {
                return childSeated;
            }

            else if (Age <= 11 && Place == PlaceOptions.CustomerPlacePreference.Standing)
            {
                return childStanding;
            }

            else if (Age >= 65 && Place == PlaceOptions.CustomerPlacePreference.Seated)
            {
                return retiredSeated;
            }

            else if (Age >= 65 && Place == PlaceOptions.CustomerPlacePreference.Standing)
            {
                return retiredStanding;
            }

            else if (Age > 11 && Age < 65 && Place == PlaceOptions.CustomerPlacePreference.Seated)
            {
                return restSeated;
            }
            else
            {
                return restStanding;
            }
        }

        public decimal Tax()
        {
            decimal tax = (decimal)((1 - 1 / 1.06) * Price());
            return tax;
        }
    }
}
