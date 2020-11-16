using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace online_business_api.Helper
{
    public class SqlHelper
    {
        private static string ConStr { get; set; }

        public static DataTable ExecuteTable(string cmdText)
        {
            using (SqlConnection conn = new SqlConnection(ConStr))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(cmdText, conn);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataSet set = new DataSet();
                sqlDataAdapter.Fill(set);
                return set.Tables[0];
            }

        }

    }
}
