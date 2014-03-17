using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_project.Attributes;

namespace Test_project.Classes
{
    [LoggingFrom]
    class Car
    {
        public void TakeARide(int speed)
        {
            Console.WriteLine("Wruum wruuum going {0} km/h", speed);
        }

    }
}
