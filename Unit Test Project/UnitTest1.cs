using System.Reflection;
using Ticket_Office;

namespace Unit_Test_Project
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            string expected = ",1,2,3,50,100,";
            string actual = Methods.AddPlace(",1,2,3,50,", 100);
            Assert.Equal(expected, actual);
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