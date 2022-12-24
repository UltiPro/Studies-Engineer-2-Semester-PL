using System;

namespace TrafficControlSystem
{
    class IncorrectPosition : Exception
    {
        public IncorrectPosition() : base("Wrong Value for Position.") { }
    }
}