using Microsoft.VisualStudio.TestTools.UnitTesting;

using Objects;

namespace TestProject1
{
    [TestClass]
    public class Airport_UnitTest
    {
        int id = 10;
        int x = 123;
        int y = 321;
        string name = "Test_Name";
        string country = "Test_Country";
        string city = "Test_City";
        string post_code = "Test_PostCode";

        [TestMethod]
        public void Airport_GetCity_Return_String()
        {
            //Arrange

            var airport = new Airport(id, x, y, name, country, city, post_code);

            //Act

            var result = airport.Get_City();

            //Assert

            Assert.IsInstanceOfType(result, typeof(string));
            Assert.AreEqual(city, result);
        }
        [TestMethod]
        public void Airport_shortToString_Return_String()
        {
            //Arrange

            var airport = new Airport(id, x, y, name, country, city, post_code);

            //Act

            var result = airport.shortToString();

            //Assert

            Assert.IsInstanceOfType(result, typeof(string));
        }
        [TestMethod]
        public void Airport_ToString_Return_String()
        {
            //Arrange

            var airport = new Airport(id, x, y, name, country, city, post_code);

            //Act

            var result = airport.ToString();

            //Assert

            Assert.IsInstanceOfType(result, typeof(string));
        }


    }
}