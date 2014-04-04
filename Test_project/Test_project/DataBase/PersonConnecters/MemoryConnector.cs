using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_project.DataBase
{
    class MemoryConnector :IPersonConnecter<Person>
    {
        List<Person> DB ;
        public MemoryConnector(List<Person> DB)
        {
              this.DB = new List<Person>(DB);
        }


        public List<Person> GetAll()
        {
            return DB;
        }

        public Person GetbyName(string Name)
        {
            return DB.Find((i) => i.Name == Name);
        }

        public void DeletebyName(string Name)
        {
            DB.Remove(DB.Find((i) => i.Name == Name));
        }

        public bool Insert(Person p)
        {
            DB.Add(p);
            return true;
        }
    }
}
