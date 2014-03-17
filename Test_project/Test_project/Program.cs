using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_project.Attributes;
using Test_project.Classes;
using System.Reflection;

namespace Test_project
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassInspector.Inspect(Assembly.GetAssembly(typeof(Car)));
            Console.ReadLine();
        }
    }
}
