using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_project.DataBase.PersonConnecters
{
    //class AdoConnecter : IPersonConnecter<Person>
    //{
    //    private DbProviderFactory dbf;
    //    private string cnStr;

    //    Random r = new Random();
    //    private AdoHelper adoHelper;

    //    public AdoConnecter()
    //    {
    //        adoHelper = new AdoHelper();
    //    }
        
    //    public List<Person> GetAll()
    //    {
    //        List<Person> result = new List<Person>();
    //        adoHelper.ExequteQuery("Select * from Person",(reader) => 
    //                    result.Add(ReadPerson(reader)));
    //        return result;
    //    }

    //    private Person ReadPerson(DbDataReader reader)
    //    {
    //        int age = int.Parse(reader["Age"].ToString());
    //        string name = (string)reader["Name"];
    //        string surname = (string)reader["Surname"];
    //        var adress = (string)reader["Adress"];
    //        bool isMale = ("0".Equals(reader["IsMale"].ToString()));
    //        int inn = int.Parse(reader["INN"].ToString());
    //        string position = (string)reader["Position"];
    //        int salary = int.Parse(reader["Salary"].ToString());
    //        return new Person(age,name,surname,adress,inn,isMale,position,salary);
    //    }

    //    public Person GetbyName(string Name)
    //    {
    //        Person result= null;
    //        string statement = "Select * from Person where name = @Name";
    //        adoHelper.ExequteQuery(command =>
    //        {
    //            command.CommandText = statement;
    //            DbParameter param1 = command.CreateParameter();
    //            param1.ParameterName = "@Name";
    //            param1.Value = Name;
    //            command.Parameters.Add(param1);
    //        }, reader => {
    //                         result = ReadPerson(reader);
    //        });
    //        return result;
    //    }
        
    //    public void DeletebyName(string Name)
    //    {
    //        adoHelper.ExequteNonQuery(command =>
    //        {
    //            string statement = "Delete from Person where name = @Name";
    //            command.CommandText = statement;

    //            DbParameter param1 = command.CreateParameter();
    //            param1.ParameterName = "@Name";
    //            param1.Value = Name;

    //            command.Parameters.Add(param1);
    //        });
    //    }

    //    public bool Insert(Person p)
    //    {
    //        adoHelper.ExequteNonQuery(command =>
    //        {
    //            MakeInsertCommand(command, p);
    //        });
    //        return true;
            
    //    }

    //    private void MakeInsertCommand(DbCommand command, Person p)
    //    {
            
    //        StringBuilder sb = new StringBuilder("Insert into Person(Person_id,Age,Name,Surname," +
    //                                             "Adress,INN,IsMale,Position,Salary) Values(");
    //        sb.Append(r.Next(10,30000)).Append(",")
    //            .Append(p.Age).Append(",'")
    //            .Append(p.Name).Append("','")
    //            .Append(p.Surname).Append("','")
    //            .Append(p.Adress).Append("',")
    //            .Append(p.INN).Append(",")
    //            .Append((p.IsMale) ? 1 : 0).Append(",'")
    //            .Append(p.Position).Append("',")
    //            .Append(p.Salary).Append(")");
            
    //        command.CommandText = sb.ToString();
            
    //    }
    //}
}
