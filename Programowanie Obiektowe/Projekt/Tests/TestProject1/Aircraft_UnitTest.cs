using Microsoft.VisualStudio.TestTools.UnitTesting;
using Objects;
using System;

namespace TestProject1
{
    [TestClass]
    public class Aircraft_UnitTest
    {

        int id = 10;
        int x = 123;
        int y = 321;
        int route_x = 234;
        int route_y = 2123;
        int x_arrival = 21;
        int y_arrival = 1000;
        int departure_airport = 11;
        int arrival_airport = 433;
        int speed = 10;
        string name = "Test_Name";
        string country = "Test_Country";
        string city = "Test_City";
        string post_code = "Test_PostCode";
        string type = "Plane";
        DateTime departure_date = new DateTime(2021, 05, 02, 02, 12, 00);
        DateTime arrival_date = new DateTime(2021, 05, 01, 12, 10, 10);


        [TestMethod]
        public void Aircraft_GetTypet_ReturnString()
        {
            //Arrange


            var test_aircraft = new Aircraft(id, departure_airport, x, y, arrival_airport, x_arrival, y_arrival, departure_date, name, type);
            //Act

            var result = test_aircraft.Get_Type();

            //Assert

            Assert.AreEqual(result, type);


        }

        [TestMethod]
        public void Aircraft_ToString_ReturnString()
        {
            //Arrange

            var test_aircraft = new Aircraft(id, departure_airport, x, y, arrival_airport, x_arrival, y_arrival, departure_date, name, type);
            //Act

            var result = test_aircraft.Get_Type();

            //Assert

            Assert.IsInstanceOfType(result, typeof(string));
        }

    }
}