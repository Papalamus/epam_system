using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_project.Asterisk
{
    class Task1 
    {

        public void Run()
        {
            int width,length;
            length = RequestValue("Введите длинну прямоугольника");
            width = RequestValue("Введите ширину прямоугольника");
            Console.WriteLine("Площадь прямоугольника = {0} ", length * width);

        }
        int RequestValue(string message)
        {
             int result ;
             bool isRead;
             Console.WriteLine(message);
             do
             {
                 isRead = int.TryParse(Console.ReadLine(),out result);
                 if (isRead)
                 {
                     if (result > 0)
                     {
                         return result;
                     }
                     else
                     {
                         Console.WriteLine("Введите целое число больше 0");
                     }
                 }
               
             } while (true);
        }

    }
}
