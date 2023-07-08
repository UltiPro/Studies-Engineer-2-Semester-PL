

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TrafficControlSystem;

[assembly: InternalsVisibleTo("TestProject1")]


namespace Objects
{
    abstract class Object
    {
        protected int id, x, y, z;
        protected string name;
        public Object(int id, int x, int y, string name)
        {
            this.id = id;
            this.x = x;
            this.y = y;
            z = 0;
            this.name = name;
        }
        public int Get_Id()
        {
            return id;
        }
        public int GetX
        {
            get
            {
                return x;
            }
            set
            {
                if (value < 0)
                {
                    throw new IncorrectPosition();
                }
                else
                {
                    x = value;
                }
            }
        }
        public int GetY
        {
            get
            {
                return y;
            }
            set
            {
                if (value < 0)
                {
                    throw new IncorrectPosition();
                }
                else
                {
                    y = value;
                }
            }
        }
        public int GetZ
        {
            get
            {
                return z;
            }
            set
            {
                z = value;
            }
        }
        public string Get_Name()
        {
            return name;
        }
    }
     class Airport : Object
    {
        private string country, city, post_code;
        public Airport(int id, int x, int y, string name, string country, string city, string post_code) : base(id, x, y, name)
        {
            this.country = country;
            this.city = city;
            this.post_code = post_code;
        }
        public string Get_City()
        {
            return city;
        }
        public string shortToString()
        {
            return $"Airport ID: {id} \nCountry: {country}\nCity: {city}";
        }
        public override string ToString()
        {
            return $"Airport ID: {id}\nName: {name}\nCountry: {country}\nCity: {city}\nPost code: {post_code}";
        }
    }
    class LandMap
    {
        private List<Airport> AirportList;
        public LandMap()
        {
            AirportList = new List<Airport>();
        }
        public void AddAirport(Airport a)
        {
            AirportList.Add(a);
        }
        public List<Airport> Get_Airports()
        {
            return AirportList;
        }
    }
    class Aircraft : Object
    {
        private string type;
        private int route_x, route_y, departure_airport, arrival_airport, speed;
        private DateTime departure_date, arrival_date;
        public Aircraft(int id, int departure_airport, int x, int y, int arrival_airport, int x_arrival, int y_arrival, DateTime time, string name, string type) : base(id, x, y, name)
        {
            z = 8000;
            this.type = type;
            route_x = x_arrival - x;
            route_y = y_arrival - y;
            switch (type)
            {
                case "Plane": speed = 3; break;
                case "Cargo": speed = 2; break;
                case "Glider": speed = 1; break;
                case "Fighter": speed = 5; break;
            }
            departure_date = time;
            CalculateDelay(route_x, route_y, time);
            this.departure_airport = departure_airport;
            this.arrival_airport = arrival_airport;
        }
        public void ChangeName(string name)
        {
            this.name = name;
        }
        public int Getroute_x
        {
            get
            {
                return route_x;
            }
            set
            {
                route_x = value;
            }
        }
        public int Getroute_y
        {
            get
            {
                return route_y;
            }
            set
            {
                route_y = value;
            }
        }
        public string Get_Type()
        {
            return type;
        }
        public void Flight_x()
        {
            if (route_x < 0)
            {
                if (Math.Abs(route_x) < speed)
                {
                    x -= Math.Abs(route_x);
                    route_x += Math.Abs(route_x);
                }
                else
                {
                    route_x += speed;
                    x -= speed;
                }
            }
            else if (route_x > 0)
            {
                if (route_x < speed)
                {
                    x += Math.Abs(route_x);
                    route_x -= Math.Abs(route_x);
                }
                else
                {
                    route_x -= speed;
                    x += speed;
                }
            }
        }
        public void Flight_y()
        {
            if (route_y < 0)
            {
                if (Math.Abs(route_y) < speed)
                {
                    y -= Math.Abs(route_y);
                    route_y += Math.Abs(route_y);
                }
                else
                {
                    route_y += speed;
                    y -= speed;
                }
            }
            else if (route_y > 0)
            {
                if (route_y < speed)
                {
                    y += Math.Abs(route_y);
                    route_y -= Math.Abs(route_y);
                }
                else
                {
                    route_y -= speed;
                    y += speed;
                }
            }
        }
        public void ChangeRouteFlight(int Airport_arrival, int x_arrival, int y_arrival, DateTime time)
        {
            route_x = x_arrival - x;
            route_y = y_arrival - y;
            departure_date = time;
            CalculateDelay(route_x, route_y, time);
        }
        public void CalculateDelay(int delay_x, int delay_y, DateTime time)
        {
            if (delay_x < 0) delay_x *= (-1);
            if (delay_y < 0) delay_y *= (-1);
            if (delay_x < delay_y) arrival_date = time.AddMinutes(((delay_x + (delay_y - delay_x)) / speed) + 1);
            else arrival_date = time.AddMinutes(((delay_y + (delay_x - delay_y)) / speed) + 1);
        }
        public string shortToString()
        {
            return $"Aircraft: {name}\nType of Aircraft: {type}\nHeight of Flight: {z} meters";
        }
        public override string ToString()
        {
            return $"Flight ID: {id}, Aircraft: {name}\nType of Aircraft: {type}\nFlight from Airport ID: {departure_airport}, to Airport ID: {arrival_airport}\nDeparture Date: {departure_date.ToShortTimeString()} {departure_date.ToShortDateString()}\nArrival Date: {arrival_date.ToShortTimeString()} {arrival_date.ToShortDateString()}";
        }
    }
    class Radar
    {
        private List<Aircraft> AircraftList;
        public Radar()
        {
            AircraftList = new List<Aircraft>();
        }
        public void AddFlight(Aircraft f)
        {
            AircraftList.Add(f);
        }
        public bool CheckCollision()
        {
            foreach (Aircraft f1 in AircraftList)
            {
                foreach (Aircraft f2 in AircraftList)
                {
                    if ((f1.Getroute_x != 0 && f2.Getroute_y != 0) && (f1.Get_Name() != f2.Get_Name()) && (f1.GetX + 3 >= f2.GetX && f1.GetX - 3 <= f2.GetX) && (f1.GetY + 3 >= f2.GetY && f1.GetY - 3 <= f2.GetY))
                    {
                        if (f1.GetZ >= 8000 && f1.GetZ < 11000) f1.GetZ += 1000;
                        else f1.GetZ -= 1000;
                        return true;
                    }
                }
            }
            return false;
        }
        public List<Aircraft> GetAircrafts()
        {
            return AircraftList;
        }
    }
}