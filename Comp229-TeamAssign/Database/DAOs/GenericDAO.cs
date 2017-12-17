using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using Comp229_TeamAssign.Database.Exceptions;
using Comp229_TeamAssign.Database.Models;
using Comp229_TeamAssign.Database.Models.PrimaryKeys;

namespace Comp229_TeamAssign.Database.DAOs
{
    /// <summary>
    /// Class that will be implemented by all the DAO classes.
    /// </summary>
    /// <typeparam name="PK">The Model's Primary Key class</typeparam>
    /// <typeparam name="M">The Model class</typeparam>
    public abstract class GenericDAO<PK, M> : IGenericDAO<PK, M>
        where PK : GenericPrimaryKey
        where M : GenericModel<PK>, new()
    {
        // Oracle connection type.
        protected const string CNN_TYPE_ORACLE = "ORACLE";

        // SQL Server connection type.
        protected const string CNN_TYPE_SQLSVR = "SQLSVR";

        // The database connection string for SQL Server.
        protected static string SQL_CNN_STR = ConfigurationManager.ConnectionStrings["SqlCnnStr"].ConnectionString;

        // The database connection string for Oracle.
        protected static string ORA_CNN_STR = ConfigurationManager.ConnectionStrings["OraCnnStr"].ConnectionString;

        // The database type to connect to: SQLSVR for SQL Server or ORACLE for Oracle databases.
        protected static string DB_TYPE = ConfigurationManager.ConnectionStrings["DbType"].ConnectionString;

        /// <see cref="IGenericDAO{PK, M}"/>
        public List<M> FindAll()
        {
            if (CNN_TYPE_SQLSVR == DB_TYPE)
            {
                return FindAllSqlServer(BuildFindAllQueryString());
            }

            /// TODO: Implement oracle connections.

            return new List<M>();
        }

        /// <see cref="IGenericDAO{PK, M}"/>
        public List<M> FindPaged(QueryPage queryPage)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method that will be implemented by chikd classes in order to provide the correct query
        /// for the FindAll method.
        /// </summary>
        /// <returns>The build query string.</returns>
        protected abstract string BuildFindAllQueryString();

        /// <summary>
        /// Method that will crete an object using the given SqlDataReader
        /// </summary>
        /// <returns></returns>
        protected abstract M CreateObjectFromDataReader(DbDataReader dataReader);

        /// <summary>
        /// Finds all the database objects for the given type using SQL Server database.
        /// </summary>
        /// <param name="queryString">The query to be executed</param>
        /// <exception cref="DatabaseException">If an error occurs when trying to retrieve the data from the database.</exception>
        /// <returns>The list of objects populated with the database data.</returns>
        private List<M> FindAllSqlServer(string queryString)
        {
            var objectList = new List<M>();

            try
            {
                using (SqlConnection cnn = new SqlConnection(SQL_CNN_STR))
                {
                    using (SqlCommand cmd = new SqlCommand(queryString, cnn))
                    {
                        cnn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.NextResult())
                                {
                                    objectList.Add(CreateObjectFromDataReader(reader));
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseException("An error has occurred when searching for records on a SQL Server database.", ex);
            }

            return objectList;
        }
    }
}