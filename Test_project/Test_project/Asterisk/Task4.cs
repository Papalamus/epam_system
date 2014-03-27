using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Test_project.Asterisk
{
    class Task4: Task
    {
        Task3 t3;
        public override void Run(int n, TextWriter tr)
        {
            for (int i = 0; i < n; i++)
            {
                t3.Run(i, tr);    
            }
        }
    }
}
