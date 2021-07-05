using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using Dapper;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace Sen.Core
{
    public static class DbContextExtension
    {
        public static IEnumerable<T> Query<T>(this DbContext context,
            string sql,
            object param = null,
            IDbTransaction transaction = null,
            bool buffered = true,
            int? commandTimeout = null,
            CommandType? commandType = null) where T : SenEntity
        {
            var conn = context.Database.GetDbConnection();

            return conn.Query<T>(sql, param, transaction, buffered, commandTimeout, commandType);
        }
    }
}
