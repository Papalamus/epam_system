using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_project.Asterisk
{
    class Task3 : Task
    {
        int Lines;
       
        public override void Run(int n, System.IO.TextWriter tr)
        {
            this.Lines = n;
            sb = new StringBuilder();
            for (int i = 1; i <= n; i++)
            {
                AddPyramidLine(i);
            }
            tr.Write(sb.ToString());
        }

        private void AddPyramidLine(int i)
        {
            int k = 2 * i - 1;
            sb.Append(' ',Lines-i);
            sb.Append('*', k);
            sb.Append(' ', Lines - i);
            sb.AppendLine();
        }
    }
}
