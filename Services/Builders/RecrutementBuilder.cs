using Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Builders
{
    public static class RecrutementBuilder
    {
        public static Recrutements buildRecrutements(SqlDataReader rdr)
        {
            Recrutements Recru = new Recrutements();

            Recru.RecrutementId = Convert.ToInt32(rdr["Id_Recrutement"]);
            Recru.Poste_Recru = rdr["Poste_Recru"] != DBNull.Value ? rdr["Poste_Recru"].ToString() : "";
            Recru.CondidatId = rdr["Condidat_Id"] != DBNull.Value ? (int)rdr["Condidat_Id"] : -1;
            Recru.CollaborateurId = rdr["Collaborateur_Id"] != DBNull.Value ? (int)rdr["Collaborateur_Id"] : -1;
            Recru.DateMofid = rdr["Date_Modif"] != DBNull.Value ? Convert.ToDateTime(rdr["Date_Modif"]) : System.DateTime.MinValue;

            return Recru;

        }
    }
}
