using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NUnit.Framework;
using Test_project.Attributes;

namespace Test_project.DataBase.PersonConnecters
{
    class MyOrmConnecter<T>: IPersonConnecter<T>
    {
        
        Dictionary<string, MemberInfo> mappedType = new Dictionary<string, MemberInfo>();
        private string tableName;
        private Random idGenerator = new Random();

        public  MyOrmConnecter()
        {
            MapClass();
        }

        

        public void MapClass()
        {
            Type t = typeof(T);
            TableOrmSaveAttribute tableOrmInstance = t.GetCustomAttribute<TableOrmSaveAttribute>();
           
            if (tableOrmInstance == null)
                return;
            tableName = tableOrmInstance.Name;
            
            mapMembers(t.GetFields());
            mapMembers(t.GetProperties());
        }

        private void mapMembers(IEnumerable<MemberInfo> members)
        {
            foreach (MemberInfo memberInfo in members)
            {
                FieldOrmSaveAttribute attr = memberInfo.GetCustomAttribute<FieldOrmSaveAttribute>();
                if (attr != null)
                {
                    mappedType.Add(attr.Name, memberInfo);
                }
            }
        }
        
        

        public string MakeInsertString(object obj)
        {
            if (mappedType.Count < 0)
            {
                return string.Empty;
            }

            StringBuilder into = new StringBuilder();
            StringBuilder values = new StringBuilder();


            into.Append(typeof(T).Name+"_id ,");
            values.Append(getId()+" ,");

            foreach (KeyValuePair<string, MemberInfo> pair in mappedType)
            {

                into.Append(pair.Key + " ,");
                values.Append(pair.Value.GetValue(obj) + " ,");
                
            }
            
            into.Remove(into.Length - 1, 1);
            values.Remove(values.Length - 1, 1);
         
            return string.Format("Insert into {0}({1}) Values ({1})",tableName, into.ToString(), values.ToString());
        }

        public string MakeDeleteString(string whereSection)
        {
            if (mappedType.Count < 0)
            {
                return string.Empty;
            }

            return string.Format("Delete from {0} " + whereSection, tableName, whereSection);
        }

        public string MakeSelectString(string whereSection)
        {
            if (mappedType.Count < 0)
            {
                return string.Empty;
            }

            return string.Format("Select * from {0} " + whereSection, tableName, whereSection);
        }




        private string getId()
        {
            return idGenerator.Next(9000).ToString();
        }

       
        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetbyName(string Name)
        {
            throw new NotImplementedException();
        }

        public void DeletebyName(string Name)
        {
            throw new NotImplementedException();
        }

        public bool Insert(T p)
        {
            throw new NotImplementedException();
            //string tName = getTableName();

        }
    }
}
