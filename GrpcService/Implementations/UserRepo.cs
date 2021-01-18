using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using GrpcService.Interfaces;
using GrpcService.Models;
using Microsoft.Data.SqlClient;

namespace GrpcService.Implementations
{
    public class UserRepo : IRepo<User>
    {
        private const string getAllUsers = "SELECT * FROM Users";
        private const string getUserById = "SELECT * FROM Users WHERE Id = @id";
        readonly string connectionString = null;

        public UserRepo(string conn)
        {
            connectionString = conn;
        }

        public User Get(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<User>(getUserById, new {id}).FirstOrDefault();
            }
        }

        public List<User> GetAll()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<User>(getAllUsers).ToList();
            }
        }
    }
}