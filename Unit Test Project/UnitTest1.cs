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
        public void Test2()
        {
            int expected = 50;
            int actual = Methods.PriceSetter(9, "seATEd");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test3()
        {
            int expected = 110;
            int actual = Methods.PriceSetter(20, "sTandING");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test4()
        {
            int expected = 170;
            int actual = Methods.PriceSetter(50, "SeaTEd");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test5()
        {
            int expected = 60;
            int actual = Methods.PriceSetter(111, "StANDing");
            Assert.Equal(expected, actual);
        }

    }
}