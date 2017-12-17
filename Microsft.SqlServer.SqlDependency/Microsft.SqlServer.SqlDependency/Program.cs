using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsft.SqlServer.SqlDependency
{
    class Program
    {
        static void ReadMessages()
        {
            DatabaseHelper databaseHelper = new DatabaseHelper();
            SqlCommand cmd = databaseHelper.CreateCommand(SQLQueries.GET_MESSAGES);
            System.Data.SqlClient.SqlDependency sqlDependency = databaseHelper.SqlDependency(cmd);
            databaseHelper.DependencyStart();
            sqlDependency.OnChange += SqlDep_OnChange;
            SqlDataReader dr = databaseHelper.ExecuteReader(cmd);
            Console.WriteLine("Time:" + DateTime.Now);
            while (dr.Read())
            {
                Console.WriteLine(dr["Message"]);
            }

        }
        static void Main(string[] args)
        {
            ReadMessages();
            Console.ReadLine();
        }

        private static void SqlDep_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info == SqlNotificationInfo.Insert)
            {
                if (e.Info == SqlNotificationInfo.Update)
                {
                    if (e.Info == SqlNotificationInfo.Delete)
                    {
                        if (e.Info == SqlNotificationInfo.Alter)
                        {

                        }
                    }
                }
            }

            ReadMessages();
        }
    }
}
