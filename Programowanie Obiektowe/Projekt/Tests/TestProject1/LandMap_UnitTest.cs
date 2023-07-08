using Microsoft.VisualStudio.TestTools.UnitTesting;

using Objects;

namespace TestProject1
{
    [TestClass]
    public class LandMap_UnitTest
    {

        int id = 10;
        int x = 123;
        int y = 321;
        string name = "Test_Name";
        string country = "Test_Country";
        string city = "Test_City";
        string post_code = "Test_PostCode";



        [TestMethod]
        public void LandMap_ToString_Return_String()
        {
            //Arrange

            var landmap = new LandMap();
            var test_airport = new Airport(id, x, y, name, country, city, post_code);

            //Act

            landmap.AddAirport(test_airport);

            var result = landmap.Get_Airports();

            //Assert
            foreach (var rec in result)
            {
                Assert.AreEqual(test_airport, rec);
            }

        }
    }
}