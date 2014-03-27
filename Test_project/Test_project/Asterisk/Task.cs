using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Test_project.Asterisk
{
    public abstract class Task
    {
        protected StringBuilder sb;
        public abstract void Run(int n, TextWriter tr);
    }
}
