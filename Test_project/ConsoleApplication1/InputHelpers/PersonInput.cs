using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_project.Entities;

namespace ConsoleApplication1.InputHelpers
{
    class PersonInput : IInputHelper<Person>
    {
        public Person makeObject()
        {
            return new Person()
            {
                Name = UserChoise.Request("Введите имя"),
                Surname = UserChoise.Request("Введите фамилию"),
                INN = UserChoise.Request<int>("Введите ИНН", Int32.TryParse)
            };
        }

        public object requestID()
        {
            return UserChoise.Request<int>("Введите ИНН элемента", Int32.TryParse);
        }
    }
}
