using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_project.Asterisk
{
    class Task2: Task
    {
        
        public override void Run(int n, System.IO.TextWriter tr)
        {
            sb = new StringBuilder();
            for (int i = 1; i <= n; i++)
            {
                AddPyramidLine(i);
            }
            tr.Write(sb.ToString());
        }

        private void AddPyramidLine(int i)
        {
            sb.Append('*',i);
            sb.AppendLine();
        }
    }
}
