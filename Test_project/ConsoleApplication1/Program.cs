using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1;
using Test_project.DataBase;
using Test_project.Entities;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Client c = new Client();
            c.SelectEntity();
        }
    }
}
