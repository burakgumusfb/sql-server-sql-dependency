using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsft.SqlServer.SqlDependency
{
    public class DatabaseHelper
    {

        protected string connectionString
        {
            get { return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString; }
        }


        private SqlConnection Connection
        {
            get
            {
                SqlConnection connection = new SqlConnection(this.connectionString);

                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();

                return connection;
            }
        }
        public SqlCommand CreateCommand(string Command)
        {
            SqlCommand command = new SqlCommand(Command, Connection);
            return command;
        }
        public SqlDataReader ExecuteReader(SqlCommand cmd)
        {

            SqlDataReader dr = cmd.ExecuteReader();

            if (Connection.State == System.Data.ConnectionState.Open)
                Connection.Close();

            return dr;
        }

        public System.Data.SqlClient.SqlDependency SqlDependency(SqlCommand command)
        {
            System.Data.SqlClient.SqlDependency sqlDependency = new System.Data.SqlClient.SqlDependency(command);
            return sqlDependency;
        }

        public void DependencyStart()
        {
            System.Data.SqlClient.SqlDependency.Start(connectionString);
        }
        public void DependencyStop()
        {
            System.Data.SqlClient.SqlDependency.Start(connectionString);
        }


    }
}
