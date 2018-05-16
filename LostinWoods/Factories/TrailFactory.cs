
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using LostinWoods.Models;

namespace LostinWoods.Factory
{
    public class TrailFactory : IFactory<Trails>
    {
        private string connectionString;
        public TrailFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=3306;database=lostinwoods;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get{
                    return new MySqlConnection(connectionString);
            }
        }

        public void Create(Trails item){
            using (IDbConnection dbConnection = Connection){
                string query = "INSERT INTO trails (name, description, traillength,elevation,log,lat) VALUES (@name, @description, @traillength, @elevation, @log, @lat)";
                dbConnection.Open();
                dbConnection.Execute(query,item);
            }
        }
        public IEnumerable<Trails> FindaAll(){
            using (IDbConnection dbConnection = Connection){
                dbConnection.Open();
                return dbConnection.Query<Trails>("SELECT * FROM trails");
            }
        }
       public Trails FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Trails>("SELECT * FROM trails WHERE id = @id", new { id = id }).FirstOrDefault();
            }
        }

    }
}
