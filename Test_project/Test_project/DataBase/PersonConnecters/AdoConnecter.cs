using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_project.DataBase.Interface;
using Test_project.Entities;

namespace Test_project.DataBase.PersonConnecters
{
    public class AdoConnecter<T> : IPersonConnecter<T> where T:IAdoSaveable, new()
    {
        private DbProviderFactory dbf;
        private string cnStr;
        private string tableName;

        private AdoHelper adoHelper;

        public AdoConnecter()
        {
            adoHelper = new AdoHelper();
            tableName = typeof(T).Name;
        }

        public List<T> GetAll()
        {
            List<T> result = new List<T>();
            T temp;
            
            adoHelper.ExequteQuery(string.Format("Select * from {0}",tableName), (reader) =>
            {
                temp = new T();
                temp.ReadObject(reader);
                result.Add(temp);
            });
             
            return result;
        }

        


        public bool Insert(T p)
        {
            adoHelper.ExequteNonQuery(command =>
            {
                p.SaveObject(command,tableName); 
            });
            return true;

        }

        //private void MakeInsertCommand(DbCommand command, Person p)
        //{

        //    StringBuilder sb = new StringBuilder("Insert into Person(Person_id,Age,Name,Surname," +
        //                                         "Adress,INN,IsMale,Position,Salary) Values(");
        //    sb.Append(r.Next(10, 30000)).Append(",")
        //        .Append(p.Age).Append(",'")
        //        .Append(p.Name).Append("','")
        //        .Append(p.Surname).Append("','")
        //        .Append(p.Adress).Append("',")
        //        .Append(p.INN).Append(",")
        //        .Append((p.IsMale) ? 1 : 0).Append(",'")
        //        .Append(p.Position).Append("',")
        //        .Append(p.Salary).Append(")");

        //    command.CommandText = sb.ToString();

        //}


        public T GetbyID(object ID)
        {
            string stringID = ID.ToString();
            T result = new T();
            var idField = ConfigurationManager.AppSettings[tableName];
            string statement = String.Format("Select * from {0} where {1}= @id", tableName, idField);
            adoHelper.ExequteQuery(command =>
            {
                command.CommandText = statement;
                DbParameter param1 = command.CreateParameter();
                param1.ParameterName = "@id";
                param1.Value = stringID;
                command.Parameters.Add(param1);
            }, reader =>
            {
                result.ReadObject(reader);
            });
            return result;
        
        }

        public void DeletebyID(object ID)
        {
            adoHelper.ExequteNonQuery(command =>
            {
                string stringID = ID.ToString();
                var idField = ConfigurationManager.AppSettings[tableName];
                string statement = string.Format("Delete from {0} where {1} = @Name",tableName,idField);
                command.CommandText = statement;

                DbParameter param1 = command.CreateParameter();
                param1.ParameterName = "@Name";
                param1.Value = stringID;

                command.Parameters.Add(param1);
            });
        }
    }
}
