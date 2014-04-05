using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_project.Attributes;

namespace Test_project.DataBase
{
    [Serializable]
    [TableOrmSave(Name = "PersonTable")]
    public class Person
    {

        [FieldOrmSave(Name ="AgeField",type = typeof(int))]
        public int Age { get; set; }
        [FieldOrmSave(Name = "NameField", type = typeof(string))]
        public string Name { get; set; }
        [FieldOrmSave(Name = "SurnameField", type = typeof(string))]
        public string Surname { get; set; }
        public string Adress { get; set; }
        [IdFieldOrmSave(Name = "Person_id", type = typeof(int))]
        public int INN { get; set; }
        
        //True is Male
        public bool IsMale{ get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }

        public Person() { }
        
        public Person(int Age, string Name, string Surname,string Adress,
            int INN, bool IsMale, string Position,int Salary)
        {
            this.Adress = Adress;
            this.Age = Age;
            this.INN = INN;
            this.IsMale = IsMale;
            this.Name = Name;
            this.Position = Position;
            this.Salary = Salary;
            this.Surname = Surname;            
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Person p  = (Person)obj;
            Type t = this.GetType();

            var fields = from f in t.GetFields()
                         select f;

            bool equals = true;
            foreach (var field in fields)
            {
                if (field.GetValue(this).Equals(field.GetValue(p)))
                {
                    equals = false;
                }

            }
            return equals;
        }


       

        public override string ToString()
        {
            return "Name = "+Name+" Surname = "+Surname;
        }

    }
}
