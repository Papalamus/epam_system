using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.InputHelpers;
using Test_project.Entities;
using Test_project.DataBase.Interface;
using Test_project.DataBase.PersonConnecters;

namespace ConsoleApplication1
{
    public delegate bool TryParseHandler<T>(string s,out T result);
    class Client
    {

        public void SelectEntity()
        {
            string msg = "Выберите тип объекта \n";
            UserChoise entityChoise = new UserChoise(msg);
            bool exit = false;
            
            entityChoise.Add("Person", ()=> Process(SelectConnector<Person>(),new PersonInput()));
            entityChoise.Add("Article", ()=> Process(SelectConnector<Article>(),new ArticleInput()));
            entityChoise.Add("Назад", () => exit = true);
            do
            {
                entityChoise.Run();
            } while (!exit);
        }

        public void Process<T>(IPersonConnecter<T> connecter, IInputHelper<T> inputHelper)
        {
            string msg = "";
            bool exit = false;
            
            UserChoise actionChoise = new UserChoise(msg);
            actionChoise.Add("Вывести все", () => PrintList(connecter.GetAll()));
            actionChoise.Add("Вставить элемент", () => connecter.Insert(inputHelper.makeObject()));
            actionChoise.Add("Удалить элемент", () => connecter.DeletebyID(inputHelper.requestID()));
            actionChoise.Add("Получить элемент", () => Console.WriteLine(connecter.GetbyID(inputHelper.requestID())));
            actionChoise.Add("Назад", () => exit = true);
            do
            {
                actionChoise.Run();
            } while (!exit);
        }

        private void PrintList<T>(List<T> list)
        {
            foreach (var entry in list)
            {
                Console.WriteLine(entry);    
            }
            
        }


        public IPersonConnecter<T> SelectConnector<T>() where T : IAdoSaveable, new()
        {
            IPersonConnecter<T> connecter =null;
            string msg = "Выберите тип базы данных \n";
            UserChoise connecterChoise = new UserChoise(msg);

            connecterChoise.Add("Orm", () => connecter = new MyOrmConnecter<T>());
            connecterChoise.Add("Простой Ado.net", () => connecter = new AdoConnecter<T>());

            connecterChoise.Run();
            return connecter;
        }

    }
    
}
