using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_project.DataBase.Interface
{
    public interface IAdoSaveable
    {
        void ReadObject(DbDataReader reader);
        void SaveObject(DbCommand command,string tableName);
    }
}
