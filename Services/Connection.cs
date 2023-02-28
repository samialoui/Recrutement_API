using Data;
using Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    
       

        public sealed class Connection
        {

        //private IConfiguration _config;

        //public  Connection(IConfiguration config)
        //{
        //    _config = config;
        //}

        // public  string Connction()
        //{
        //    {
        //        var conx = _config.GetConnectionString("defaultConnection");
        //        string connectionStr = conx;

        //        return connectionStr;
        //    }
        //}

        // Connection's configuration:
        private static string connectionString = "Server=DESKTOP-TDT294R; Database=SWIB_TIME_RECRUTEMENT ; Trusted_Connection=True ; MultipleActiveResultSets=True; User ID=sa;Password=Swib123456;Trust Server Certificate=true;";
            private static Connection singleton;
            private static SqlConnection sqlConnection;

            public SqlConnection SqlConnetionFactory
            {
                get { return sqlConnection; }
            }

            private Connection() { }

            public static Connection Singleton
            {
                get
                {
                    if (singleton == null)
                        singleton = new Connection();

                    sqlConnection = new SqlConnection(connectionString);
                    return singleton;
                }
            }

        }
    
}
