using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_project.Attributes;

namespace Test_project.Classes
{
    class MiniVan : Car
    {

        [Overrided]
        public  void TakeARide(int speedy , string errMsg)
        {
            if (speedy > 70)
            {
                Console.WriteLine("Too fast for me:" + errMsg);
            }
            else
            {
                base.TakeARide(speedy);
            }
        }
    }
}
