using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Data;

namespace PlanningPrep.Core.Storage
{
    public class ObjectStore : IObjectStore
    {
        private string _connectionstring = "";
        public ObjectStore()
        {
            _connectionstring = ConfigurationManager.ConnectionStrings[""].ConnectionString;
        }

        public void Store<T>(string key, string searchString, T value) where T : class, new()
        {
            //serialize to binaryasdd
            var sql = @"IF NOT EXISTS(SELECT ID FROM ObjectStore WHERE ObjectKey=@Key AND SearchString=@SearchString )
                            INSERT INTO ObjectStore(ObjectKey,SearchString,SystemType,Data)
                            VALUES(@Key,@SearchString,@Type,@Data)
                        ELSE
                            UPDATE ObjectStore SET ModifiedOn=getdate(),Data=@Data
                            WHERE ObjectKey=@Key AND SearchString=@SearchString";

            SqlParameter[] Parameters = new[]{
                                                 new SqlParameter("@Key", key),
                                                 new SqlParameter("@SearchString", searchString),
                                                 new SqlParameter("@Type", typeof (T).Name),
                                                 new SqlParameter("@Data", value.ToBinary())
                                             };

            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                using(SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddRange(Parameters);
                    //execute
                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void Store<T>(string key, T value) where T : class, new()
        {
            Store(key, "", value);
        }

        public void Delete(string key, string searchString)
        {
            var sql = @"DELETE FROM ObjectStore WHERE ObjectKey=@key AND searchString=@searchString";

            SqlParameter[] Parameters = new[]{
                                                 new SqlParameter("@Key", key),
                                                 new SqlParameter("@SearchString", searchString)
                                             };

            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddRange(Parameters);
                    //execute
                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        public void Delete(string key)
        {
            var sql = @"DELETE FROM ObjectStore WHERE ObjectKey=@key";

            SqlParameter[] Parameters = new[]{
                                                 new SqlParameter("@Key", key)
                                             };

            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddRange(Parameters);
                    //execute
                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        public T Get<T>(string key) where T : class, new()
        {
            return Get<T>(key, "");
        }

        public IList<T> GetList<T>(string key) where T : class, new()
        {
            var result = new List<T>();
            var sql = @"SELECT * FROM ObjectStore WHERE ObjectKey=@Key";
            var bits = new byte[0];
            string sType;

            SqlParameter[] Parameters = new[]
                                            {
                                                new SqlParameter("@Key", key)
                                            };

            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddRange(Parameters);
                    //execute
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader != null && reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                sType = reader["SystemType"].ToString();
                                bits = (byte[]) reader["Data"];


                                if (bits.Length > 0)
                                {

                                    //make sure the types match
                                    if (!typeof (T).Name.Equals(sType))
                                    {
                                        throw new InvalidDataException("The type requested (" + typeof (T).Name + ") doesn't match the type stored: " + sType);
                                    }

                                    var item = default(T);
                                    item = item.FromBinary(bits);
                                    result.Add(item);
                                }


                            }
                            reader.Close();
                        }
                    }
                }
                connection.Close();
            }

            return result;
        }

        public T Get<T>(string key, string searchString) where T : class, new()
        {
            var result = default(T);
            //HACK: Select * Isn't good for perf - but the ObjectStore shouldn't be a high-search/hit
            var sql = @"SELECT * FROM ObjectStore WHERE ObjectKey=@Key AND SearchString=@SearchString";
            if (String.IsNullOrEmpty(searchString))
            {
                sql = @"SELECT * FROM ObjectStore WHERE ObjectKey=@Key";
            }

            var bits = new byte[0];
            var sType = "";

            SqlParameter[] Parameters = new[]
                                            {
                                                new SqlParameter("@Key", key),
                                                new SqlParameter("@searchString", searchString), 
                                            };

            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddRange(Parameters);
                    //execute
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader != null && reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                sType = reader["SystemType"].ToString();
                                bits = (byte[])reader["Data"];
                            }
                            reader.Close();
                        }
                    }
                }
                connection.Close();
            }

            if (bits.Length > 0)
            {
                //make sure the types match
                if (!typeof(T).Name.Equals(sType))
                {
                    throw new InvalidDataException("The type requested (" + typeof(T).Name + ") doesn't match the type stored: " + sType);
                }

                try
                {
                    result = result.FromBinary(bits);
                }
                catch
                {
                    //if there's an error then the serialization was bad
                    //kill it
                    Delete(key, searchString);
                }
            }

            return result;
        }
    }
}