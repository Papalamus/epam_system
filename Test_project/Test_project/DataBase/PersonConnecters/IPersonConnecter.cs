using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_project.DataBase
{
    interface IPersonConnecter
    {
        List<Person> GetAll();
        Person GetbyName(string Name);
        void DeletebyName(string Name);
        bool Insert(Person p);
    }
    
}
