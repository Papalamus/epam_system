﻿
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using NUnit.Framework;
using Test_project.DataBase.Interface;
using Test_project.Entities;

namespace Test_project.DataBase
{
    [TestFixture]
    public class NUnitTests
    {
        const string pathDB = "test.txt";
        List<Person> t1 = new List<Person>(){
                new Person(16,"Bob","Marley","Jamaica",1122,"Singer",0),
                new Person(39,"Dilan","Volkov","Samara",0697,"Manager",20000),
                new Person(57,"Dilan","Fetroda","Japan",4534,"Programmer",  12000),
                new Person(23,"Peka","Boyarskaya","America",3451,"Midnight Dancer",30000),
                new Person(11,"Jamshut","Azergajiev","Moskow",2234,"Worker",40000)
            };
        public NUnitTests()
        {
            MakeDbFile(pathDB, t1);
        }

        public List<Person> T1
        {
            get { return t1; }
        }

        [Test]
        public void SumOfTwoNumbers()
        {            
            IPersonConnecter<Person>[] connectors =
            {
                new MemoryConnector(t1),
                new FileConnector(pathDB)
            };
            List<List<Person>> results = new List<List<Person>>();
            
            for (int i = 0;i<2 ;i++)
            {
                results.Add(connectors[i].GetAll());    
            }

            for (int i = 0; i < results.Count; i++)
			{
			 Assert.AreEqual(results[0][i],results[0][i]);
			}

        }
     

        public static void MakeDbFile(string path, List<Person> lp)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>), new Type[] { typeof(Person) });
            using (Stream fstream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                serializer.Serialize(fstream, lp);
            }
        }
    }

}
 