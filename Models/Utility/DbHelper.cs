using HasB4bBase.Attribute;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HasB4bBase.Models.Utility
{
    public class DbHelper
    {
        [ExceptionLogger]
        public static int ExecuteNonQuery(string procedureName,params object[] paramaters)
        {
            int statu = 0;
            if (paramaters.Length % 2 != 0)
                throw new ArgumentException("Wrong number of parameters sent to procedure. Expected an even number.");

            try
            {
                List<SqlParameter> paramList = CreateParameter(paramaters);
                using (SqlConnection conn = new SqlConnection(Connection.DAL))
                {
                    SqlCommand cmd = new SqlCommand(procedureName, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(paramList.ToArray());
                    conn.Open();
                    statu = cmd.ExecuteNonQuery();
                    conn.Close();
                }
                return statu;
            }
            catch(Exception exp)
            {
                return statu = 0;
            }
        }

        [ExceptionLogger]
        public static DataTable ExecuteReader(string procedureName, params object[] paramaters)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da;
            if (paramaters.Length % 2 != 0)
                throw new ArgumentException("Wrong number of parameters sent to procedure. Expected an even number.");

            try
            {
                List<SqlParameter> paramList = CreateParameter(paramaters);
                using (SqlConnection conn = new SqlConnection(Connection.DAL))
                {
                    SqlCommand cmd = new SqlCommand(procedureName, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(paramList.ToArray());
                    conn.Open();
                    da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    conn.Close();
                }
                return dt;
            }
            catch(Exception exp)
            {
                return new DataTable();
            }
        }

        [ExceptionLogger]
        public static DataSet ExecuteScalar(string procedureName, params object[] paramaters)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            if (paramaters.Length % 2 != 0)
                throw new ArgumentException("Wrong number of parameters sent to procedure. Expected an even number.");

            try
            {
                List<SqlParameter> paramList = CreateParameter(paramaters);
                using (SqlConnection conn = new SqlConnection(Connection.DAL))
                {
                    SqlCommand cmd = new SqlCommand(procedureName, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(paramList.ToArray());
                    conn.Open();
                    da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    conn.Close();
                }
                return ds;
            }
            catch (Exception exp)
            {
                return new DataSet();
            }
        }

        private static List<SqlParameter> CreateParameter(params object[] parameters)
        {
            List<SqlParameter> parametersList = new List<SqlParameter>();
            for(int i = 0; i < parameters.Length; i+=2)
                parametersList.Add(new SqlParameter(parameters[i] as string, parameters[i + 1]));
            return parametersList;
        }
    }
}