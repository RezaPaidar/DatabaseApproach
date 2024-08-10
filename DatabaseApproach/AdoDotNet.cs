using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseApproach
{
    public class AdoDotNet
    {
        private SqlConnection _connection;
        private const string connectionString = "Data Source=.;Initial Catalog=FIFA;Integrated Security=True;";


        public AdoDotNet()
        {
            _connection = new SqlConnection(connectionString);
        }

        private bool Connect()
        {
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
                return true;
            }
            return false;
        }

        private void Disconnect()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        /// <summary>
        /// For execute update, delete and insert commands [Write Operations]
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public int ExecuteCommand_To_SQLServer(string query)
        {
            try
            {
                Connect();
                var cmd = new SqlCommand();
                cmd.Connection = _connection;
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;

                int result = cmd.ExecuteNonQuery();

                return result;
            }
            catch (SqlException e)
            {
                return e.Number * (-1);
            }
            finally
            {
                Disconnect();
            }
        }

        public string Read_Opr(string query)
        {
            try
            {
                Connect();
                var cmd = new SqlCommand();
                cmd.Connection = _connection;
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;

                string result = "";

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result = reader["cName"].ToString();
                }
                return result;

            }
            catch (SqlException e)
            {
                return null;
            }
            finally
            {
                Disconnect();
            }
        }
    }
}
