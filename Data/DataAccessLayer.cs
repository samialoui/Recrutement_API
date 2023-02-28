using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace Data
{
    public class DataAccessLayer
    {
        SqlDataReader rdr = null;
        SqlConnection con;
        public string a = string.Empty;
        public bool state = false;

        public DataAccessLayer()
        {
            con = new SqlConnection(@"Server = DESKTOP-EL7FT3K; Database = E-Recrutement; Integrated Security = True; User ID=sa;Password=Swib123456;");
        }

        public void open()
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
        }

        public void Close()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        public DataTable SelectData(string Stored_Procedure, SqlParameter[] param)
        {
            state = false;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Stored_Procedure;
            cmd.Connection = con;

            if (param != null)
            {
                for (int i = 0; i < param.Length; i++)
                {
                    cmd.Parameters.Add(param[i]);
                }
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
                state = true;
            }
            catch
            {
                state = false;
            }
            return dt;
        }

        public void ExecuteCommand(string Stored_Procedure, SqlParameter[] param)
        {
            try
            {
                state = false;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = Stored_Procedure;
                cmd.Connection = con;

                if (param != null)
                {
                    cmd.Parameters.AddRange(param);
                }
                cmd.ExecuteNonQuery();
                state = true;
            }
            catch
            {
                state = false;
            }
        }

        public string GetString(string Stored_Procedure, SqlParameter[] param)
        {
            a = string.Empty;
            state = false;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Stored_Procedure;
            cmd.Connection = con;

            if (param != null)
            {
                for (int i = 0; i < param.Length; i++)
                {
                    cmd.Parameters.Add(param[i]);
                }
            }
            try
            {
                open();
                a = cmd.ExecuteScalar().ToString();
                Close();
                state = true;
            }
            catch
            {
                state = false;
            }
            return a;
        }

        public int GetUserId(string Stored_Procedure, SqlParameter[] param)
        {
            int a = 0;
            state = false;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Stored_Procedure;
            cmd.Connection = con;

            if (param != null)
            {
                for (int i = 0; i < param.Length; i++)
                {
                    cmd.Parameters.Add(param[i]);
                }
            }
            try
            {
                open();
                var rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {

                    a = rdr["id"] != DBNull.Value ? (int)rdr["id"] : 0;
                }
                Close();
                state = true;
            }
            catch
            {
                state = false;
            }
            return a;
        }

    }
}
