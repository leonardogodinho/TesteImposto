using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Framework
{
    public class BaseRepository
    {
        private string ConnectionString { get { return DataConfigConnection.AppConfigConnectionStringSqlServer; } }

        private string Owner { get { return DataConfigConnection.OwnerSqlServer; } }

        protected int ExecuteNonQueryCommand(string procedure, SqlParameter[] parameterCollection)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                cn.Open();                
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cn;
                    cmd.CommandTimeout = cn.ConnectionTimeout;
                    cmd.CommandType = CommandType.StoredProcedure;                    

                    return ExecuteTransactionNonQueryCommand(cmd, procedure, parameterCollection);
                }
            }
        }

        protected int ExecuteTransactionNonQueryCommand(SqlCommand cmd, string pathProcedure, SqlParameter[] parameterCollection)
        {
            int countRowAffected = -1;

            cmd.CommandText = string.Concat(Owner, ".", pathProcedure);            
            
            try
            {
                cmd.Parameters.AddRange(parameterCollection);
                countRowAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {                
                throw e;
            }
            
            return countRowAffected;
        }
    }
}
