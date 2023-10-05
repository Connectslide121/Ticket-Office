using System.Reflection;
using Ticket_Office;

namespace Unit_Test_Project
{
    public class UnitTest1
    {

        [Fact]
        public void TaxFormula()
        {
            for (int i = 0; i < 5000; i++)
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
                TicketSalesManager.ticketSalesManager.tickets.Add(ticket);
            }

            decimal totalTax = 0;

            foreach (Ticket item in TicketSalesManager.ticketSalesManager.tickets)
            {
                totalTax += Convert.ToDecimal(item.Tax());
            }

            decimal totalSales = 0;

            foreach (Ticket item in TicketSalesManager.ticketSalesManager.tickets)
            {
                totalSales += Convert.ToDecimal(item.Price());
            }

            decimal multiplier = 1 - 1 / 1.06m;
            decimal taxMethod = Decimal.Multiply(multiplier, totalSales);

            decimal expected = totalTax;
            decimal actual = taxMethod;
            int precision = 5;
            Assert.Equal(expected, actual, precision);
        }

        [Fact] 
        public void ChildSeated()
        {
            Ticket ticket = new Ticket(5, PlaceOptions.CustomerPlacePreference.Seated);
            int expected = 50;
            int actual = ticket.Price();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ChildStanding()
        {
            Ticket ticket = new Ticket(3, PlaceOptions.CustomerPlacePreference.Standing);
            int expected = 25;
            int actual = ticket.Price();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RetiredSeated()
        {
            Ticket ticket = new Ticket(80, PlaceOptions.CustomerPlacePreference.Seated);
            int expected = 100;
            int actual = ticket.Price();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RetiredStanding()
        {
            Ticket ticket = new Ticket(68, PlaceOptions.CustomerPlacePreference.Standing);
            int expected = 60;
            int actual = ticket.Price();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void RestSeated()
        {
            Ticket ticket = new Ticket(36, PlaceOptions.CustomerPlacePreference.Seated);
            int expected = 170;
            int actual = ticket.Price();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RestStanding()
        {
            Ticket ticket = new Ticket(59, PlaceOptions.CustomerPlacePreference.Standing);
            int expected = 110;
            int actual = ticket.Price();
            Assert.Equal(expected, actual);
        }
    }
}