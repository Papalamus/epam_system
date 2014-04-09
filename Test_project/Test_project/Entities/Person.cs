﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_project.Attributes;
using Test_project.DataBase.Interface;
using Test_project.Entities;

namespace Test_project.Entities
{
    [Serializable]
    [TableOrmSave(Name = "PersonTable")]
    public class Person : IAdoSaveable
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
        
        
        public string Position { get; set; }
        public int Salary { get; set; }

        public Person() { }
        
        public Person(int Age, string Name, string Surname,string Adress,
            int INN,string Position,int Salary)
        {
            this.Adress = Adress;
            this.Age = Age;
            this.INN = INN;
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

        public void ReadObject(DbDataReader reader)
        {
            Age = int.Parse(reader["Age"].ToString());
            Name = (string)reader["Name"];
            Surname = (string)reader["Surname"];
            Adress = (string)reader["Adress"];
            INN = int.Parse(reader["INN"].ToString());
            Position = (string)reader["Position"];
            Salary = int.Parse(reader["Salary"].ToString());
            
        }
       

        public override string ToString()
        {
            return "Name = "+Name+" Surname = "+Surname;
        }


        public void SaveObject(DbCommand command, string tableName)
        {
            const int fieldCount = 3;
            command.CommandText = string.Format("Insert into {0}(Age,Name,Surname,Adress,INN,Position,Salary)" +
                                                " Values (@Age,@Name,@Surname,@Adress,@INN,@Position,@Salary)",tableName);
            AddParametrs(command, "@INN", INN);
            AddParametrs(command, "@Name", Name);
            AddParametrs(command, "@Surname", Surname);

            AddParametrs(command, "@Adress", Adress??"");
            AddParametrs(command, "@Age", Age);
            AddParametrs(command, "@Position", Position ?? "");
            AddParametrs(command, "@Salary", Salary);
        }

        public void AddParametrs(DbCommand command, string name, object value)
        {
            var parametr = command.CreateParameter();
            parametr.ParameterName = name;
            parametr.Value = value;
            command.Parameters.Add(parametr);
        }
        


    }
}


