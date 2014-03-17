using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_project.Attributes;

namespace Test_project.Classes
{
    class SportCar :Car
    {
        [Overrided]
        public new void TakeARide(int speed)
        {
            if (speed > 200)
            {
                Console.WriteLine("Put on your cool hat!");
            }
            else
            {
                base.TakeARide(speed);
            }
        }
    }
}
