using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_project.Asterisk;
using Test_project.Attributes;
using Test_project.Classes;
using Test_project.DataBase;
using System.Reflection;
using Test_project.DataBase.PersonConnecters;

namespace Test_project
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //Test.MakeDbFile(@"Data.txt", Test.getTestList());
            IPersonConnecter DB = new AdoConnecter();
            //foreach (var element in DB.GetAll())
            //{
            //    Console.WriteLine(element);
            //}
            NUnitTests n1 = new NUnitTests();
            foreach (var person in n1.T1)
            {
                DB.Insert(person);
            }
            foreach (var element in DB.GetAll())
            {
                Console.WriteLine(element);
            }
            Console.WriteLine("______________________________________________");
            foreach (var person in n1.T1)
            {
                DB.DeletebyName(person.Name);
            }
            foreach (var element in DB.GetAll())
            {
                Console.WriteLine(element);
            }

            Console.ReadKey();
        }
         
    }
}
