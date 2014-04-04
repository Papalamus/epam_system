﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Test_project.DataBase.PersonConnecters
{
    public delegate void CustomizeCommandHandler(DbCommand command);
    public delegate void ProcessReaderHandler(DbDataReader reader);

    class AdoHelper
    {
        private DbProviderFactory providerFactory;
        private string cnStr;

        Random r = new Random();

        public AdoHelper()
        {
            cnStr = ConfigurationManager.ConnectionStrings["cnString"].ConnectionString;
            string provider = ConfigurationManager.ConnectionStrings["cnString"].ProviderName;
            providerFactory = DbProviderFactories.GetFactory(provider);
        }

        public void ExequteQuery(CustomizeCommandHandler customizeFoo,ProcessReaderHandler readerHandler)
        {
            using (DbConnection dbc = providerFactory.CreateConnection())
            {
                dbc.ConnectionString = cnStr;
                dbc.Open();
                DbCommand command = dbc.CreateCommand();
                customizeFoo(command);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        readerHandler(reader);
                    }
                }
            }
        }
        public void ExequteQuery(string commandText, ProcessReaderHandler readerHandler)
        {
            ExequteQuery(command => command.CommandText = commandText, readerHandler);
        }

        public void ExuquteNonQuery(CustomizeCommandHandler customizeFoo)
        {
            using (DbConnection dbc = providerFactory.CreateConnection())
            {
                dbc.ConnectionString = cnStr;
                dbc.Open();
                DbCommand command = dbc.CreateCommand();
                customizeFoo(command);
                command.ExecuteNonQuery();
            }
        }

        public void ExuquteNonQuery(string commandText)
        {
            ExuquteNonQuery(command => command.CommandText = commandText);
        }
        
        private Person ReadPerson(DbDataReader reader)
        {
            int age = int.Parse(reader["Age"].ToString());
            string name = (string)reader["Name"];
            string surname = (string)reader["Surname"];
            var adress = (string)reader["Adress"];
            bool isMale = ("0".Equals(reader["IsMale"].ToString()));
            int inn = int.Parse(reader["INN"].ToString());
            string position = (string)reader["Position"];
            int salary = int.Parse(reader["Salary"].ToString());
            return new Person(age,name,surname,adress,inn,isMale,position,salary);
        }

        public Person GetbyName(string Name)
        {
            using (DbConnection dbc = providerFactory.CreateConnection())
            {
                dbc.ConnectionString = cnStr;
                dbc.Open();
                DbCommand command = dbc.CreateCommand();
                
                string statement = "Select * from Person where name = @Name";
                command.CommandText = statement;
                
                DbParameter param1 = command.CreateParameter();
                param1.ParameterName = "@Name";
                param1.Value = Name;

                command.Parameters.Add(param1);

                using (DbDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    return ReadPerson(reader);

                }
            }

        }

        public void DeletebyName(string Name)
        {
            using (DbConnection dbc = providerFactory.CreateConnection())
            {
                dbc.ConnectionString = cnStr;
                dbc.Open();
                DbCommand command = dbc.CreateCommand();

                string statement = "Delete from Person where name = @Name";
                command.CommandText = statement;

                DbParameter param1 = command.CreateParameter();
                param1.ParameterName = "@Name";
                param1.Value = Name;

                command.Parameters.Add(param1);

                command.ExecuteNonQuery();
                
            }
        }

        public bool Insert(Person p)
        {
            using (DbConnection dbc = providerFactory.CreateConnection())
            {
                dbc.ConnectionString = cnStr;
                dbc.Open();
                DbCommand command = dbc.CreateCommand();

                MakeInsertCommand(command, p);
            
                command.ExecuteNonQuery();
                return true;
            }
        }

        private void MakeInsertCommand(DbCommand command, Person p)
        {
            
            StringBuilder sb = new StringBuilder("Insert into Person(Person_id,Age,Name,Surname," +
                                                 "Adress,INN,IsMale,Position,Salary) Values(");
            sb.Append(r.Next(10,30000)).Append(",")
                .Append(p.Age).Append(",'")
                .Append(p.Name).Append("','")
                .Append(p.Surname).Append("','")
                .Append(p.Adress).Append("',")
                .Append(p.INN).Append(",")
                .Append((p.IsMale) ? 1 : 0).Append(",'")
                .Append(p.Position).Append("',")
                .Append(p.Salary).Append(")");
            
            command.CommandText = sb.ToString();
            
        }
    }
}