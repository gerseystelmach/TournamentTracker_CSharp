using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.DataAccess;

namespace TrackerLibrary
{
    public static class GlobalConfig
    {
        /// <summary>
        /// This variable will hold any Class that implements the IDataConnection.
        /// </summary>
        public static IDataConnection Connection { get; private set; }

        public static void InitializeConnections(DatabaseType connectionType)
        {

            if (connectionType == DatabaseType.Sql)
            {
                SqlConnector sql = new SqlConnector();
                Connection = sql;
            } 
            else if (connectionType == DatabaseType.Textfile)
            {
                TextConnector text = new TextConnector();
                Connection = text;
            }
        }

        public static string getConnectionString(string name)
        {
           return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
