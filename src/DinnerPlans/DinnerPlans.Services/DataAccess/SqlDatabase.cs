using DinnerPlans.API.Models;
using DinnerPlans.API.Models.Enums;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DinnerPlans.DataAccess
{
    public static class SqlDataAccess 
    {
        public static string GetConnectionString(string connectionName ="Default")
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }


        public static IDbConnection GetConnection()
        {
            return new SqlConnection(GetConnectionString(""));
        }
    }

    
}
