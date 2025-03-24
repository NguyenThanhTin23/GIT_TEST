using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DA_WINFORM
{
    class DataConnection
    {
        string conStr;
        public DataConnection()
        {
            conStr = "Data Source=.;Initial Catalog=DA_WINFORM;Integrated Security=True;TrustServerCertificate=True;";
        }

        public SqlConnection getConnect()
        {
            return new SqlConnection(conStr);
        }
    }
}
