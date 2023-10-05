using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket_Office
{
    public class TicketSalesManager
    {
        public List<Ticket> tickets { get; set; }

        public TicketSalesManager()
        {
            tickets = new List<Ticket>();
        }

        public static TicketSalesManager ticketSalesManager = new TicketSalesManager();

        //************************************************************************************************************************************************************//

        public int NextTicketNumber()
        {
            bool exists;
            int number;

            do
            {
                Random random = new Random();
                number = random.Next(1, 8001);

                exists = tickets.Exists(item => item.Number == number);
            }
            while (exists==true);

            return number;
        }

        //************************************************************************************************************************************************************//

        public Ticket AddTicket (Ticket ticket)
        {
            ticketSalesManager.tickets.Add(ticket);
            return ticket;
        }

        //************************************************************************************************************************************************************//

        public bool RemoveTicket (Ticket ticket)
        {
            int number = ticket.Number;
            bool removed;

            if (tickets.Exists(item => item.Number == number))
            {
                ticketSalesManager.tickets.Remove(ticket);
                removed = true;
            }

            else
            {
                removed = false;
            }

            return removed;
        }

        //************************************************************************************************************************************************************//

        public decimal SalesTotal()
        {
            decimal total = 0;
            
            foreach (Ticket item in tickets) 
            {
                total += Convert.ToDecimal(item.Price());
            }
            return total;
        }

        //************************************************************************************************************************************************************//

        public decimal TaxTotal(decimal revenue)
        {
            decimal multiplier = 1 - 1 / 1.06m;
            decimal tax = Decimal.Multiply(multiplier, revenue);
            return tax;
        }

        //************************************************************************************************************************************************************//

        public int AmountOfTickets()
        {
            return tickets.Count;
        }

        //************************************************************************************************************************************************************//

        public int AmountOfTicketsSeated()
        {
            return tickets.Count(ticket => ticket.Place == PlaceOptions.CustomerPlacePreference.Seated);
        }

        //************************************************************************************************************************************************************//

        public int AmountOfTicketsStanding()
        {
            return tickets.Count(ticket => ticket.Place == PlaceOptions.CustomerPlacePreference.Standing);
        }

        //************************************************************************************************************************************************************//

        public static void RandomListGenerator(int howManyTickets)
        {
            for (int i = 0; i < howManyTickets; i++)
            {
                Random randomAge = new Random();
                int age = randomAge.Next(1, 106);


                PlaceOptions.CustomerPlacePreference place;
                Random randomPlace = new Random();
                int randomPlaceDefiner = randomPlace.Next(1, 3);
                if (randomPlaceDefiner == 1)
                {
                    place = PlaceOptions.CustomerPlacePreference.Seated;
                }
                else
                {
                    place = PlaceOptions.CustomerPlacePreference.Standing;
                }


                Ticket ticket = new Ticket(age, place);
                ticketSalesManager.tickets.Add(ticket);
            }
        }

        //************************************************************************************************************************************************************//




    }
}
