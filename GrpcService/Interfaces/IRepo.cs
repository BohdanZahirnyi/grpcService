using Dapper;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
 
namespace GrpcService.Interfaces
{
    public interface IRepo<T>
    {
        T Get(int id);
        List<T> GetAll();
    }
}