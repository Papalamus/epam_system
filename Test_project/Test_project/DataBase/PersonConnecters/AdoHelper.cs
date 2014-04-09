using System;
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

    internal class AdoHelper
    {
        private DbProviderFactory providerFactory;
        private string cnStr;

        private Random r = new Random();

        public AdoHelper()
        {
            cnStr = ConfigurationManager.ConnectionStrings["cnString"].ConnectionString;
            string provider = ConfigurationManager.ConnectionStrings["cnString"].ProviderName;
            providerFactory = DbProviderFactories.GetFactory(provider);
        }

        public void ExequteQuery(CustomizeCommandHandler customizeFoo, ProcessReaderHandler readerHandler)
        {
            using (DbConnection connection = providerFactory.CreateConnection())
            {
                connection.ConnectionString = cnStr;
                connection.Open();
                DbCommand command = connection.CreateCommand();
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

        public void ExequteNonQuery(CustomizeCommandHandler customizeFoo)
        {
            using (DbConnection connection = providerFactory.CreateConnection())
            {
                
                connection.ConnectionString = cnStr;
                connection.Open();
                DbCommand command = connection.CreateCommand();
                customizeFoo(command);
                command.ExecuteNonQuery();
                
            }

        }

        public void ExequteNonQuery(string commandText)
        {
            ExequteNonQuery(command => command.CommandText = commandText);
        }

    }
}
