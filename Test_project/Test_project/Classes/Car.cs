using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_project.Attributes;

namespace Test_project.Classes
{
    [My]
    [LoggingAttribute]
    class Car
    {

        public Car() : this(5) { }

        public Car(int passengers)
        {
            this.Passengers = passengers;
        }


        [My]
        public int Passengers { get; set; }
        public void TakeARide(int speed)
        {
            Console.WriteLine("Wruum wruuum going {0} km/h", speed);
        }

    }
}
