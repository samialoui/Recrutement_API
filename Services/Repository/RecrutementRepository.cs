using Data;
using Entities;
using Microsoft.Data.SqlClient;
using Services.Builders;
using Services.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repository
{
    public class RecrutementRepository: IRecrutementRepository
    {
      
        public List<Recrutements> GetAllRecrutments()
        {
            List<Recrutements> list = new List<Recrutements>();
            using (SqlConnection con = new SqlConnection(Connection.Singleton.SqlConnetionFactory.ConnectionString))
            {
                try
                {
                    con.Open();
                    var cmd = new SqlCommand("SP_SelectAllRecrutement");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 20000;
                    var rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Recrutements recru = RecrutementBuilder.buildRecrutements(rdr);
                        list.Add(recru);
                    }
                    return list;
                }
                catch
                {
                    throw ;
                    
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}
