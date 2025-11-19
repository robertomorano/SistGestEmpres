using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataBase
{
    internal class Conection
    {
        public static string GetConnectionString()
        {
            
            return "server=rmora.database.windows.net;database=PersonasDB;uid=prueba;pwd=abcd1234!; trustServerCertificate = true;";

            
        }
    }
}
