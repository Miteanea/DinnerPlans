using System.Configuration;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Collections.Generic;
using DinnerPlans.API.Models;
using System;

namespace DinnerPlans.DataAccess
{
    public static class SqlDataAccess : IRecipeDataBase
    {
        public static string GetConnectionString(string connectionName ="Default")
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString("")))
            {
                return cnn.Query<T>(sql).ToList();
            }
        }

        public List<Recipe> GetAllRecipes()
        {
            throw new NotImplementedException();
        }

        public List<Recipe> GetAllRecipesForUser(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
