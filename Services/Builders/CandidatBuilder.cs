using Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Builders
{
    public class CandidatBuilder
    {
        public static bool state = false;

        public static DataTable SelectData(string Stored_Procedure, SqlParameter[] param)
        {
            using (SqlConnection con = new SqlConnection(Connection.Singleton.SqlConnetionFactory.ConnectionString))
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
        }
        public static Ville GetAllVille(SqlDataReader rdr)
        {
            Ville ville = new Ville();

            ville.Ville_Id = Convert.ToInt32(rdr["Ville_Id"]);
            ville.Ville_Designation = rdr["Ville_Desingation"] != DBNull.Value ? rdr["Ville_Desingation"].ToString() : "";
            ville.Ville_Code = rdr["Ville_Code"] != DBNull.Value ? rdr["Ville_Code"].ToString() : "";
            //pays.User_Modif = Convert.ToInt32(rdr["User_Modif"]);
            ville.Date_Modif = rdr["Date_Modif"] != DBNull.Value ? Convert.ToDateTime(rdr["Date_Modif"]) : System.DateTime.MinValue;

            return ville;

        }

        public static Candidat GetAllCandidats(SqlDataReader rdr)
        {
            Candidat candidat = new Candidat();

            candidat.Candidat_Id = Convert.ToInt32(rdr["Candidat_Id"]);
            candidat.Candidat_Nom = rdr["Candidat_Nom"] != DBNull.Value ? rdr["Candidat_Nom"].ToString() : "";
            candidat.Candidat_Prenom = rdr["Candidat_Prenom"] != DBNull.Value ? rdr["Candidat_Prenom"].ToString() : "";
            candidat.Candidat_Nom_Prenom = rdr["Candidat_Nom_Prenom"] != DBNull.Value ? rdr["Candidat_Nom_Prenom"].ToString() : "";
            // collab. = Convert.ToInt32(rdr["Postes_Vancants"]);
            candidat.FormationCandidat_Specialite = rdr["FormationCandidat_Specialite"] != DBNull.Value ? rdr["FormationCandidat_Specialite"].ToString() : "";
            // collab.TypeEmploi = Convert.ToInt32(rdr["Type_Emploi"]);
            candidat.Candidat_Mail= rdr["Candidat_Mail"] != DBNull.Value ? rdr["Candidat_Mail"].ToString() : "";
            candidat.Candidat_NbreAnneExperience = Convert.ToInt32(rdr["Candidat_NbreAnneExperience"]);
            candidat.Candidat_Adressse = rdr["Candidat_Adressse"] != DBNull.Value ? rdr["Candidat_Adressse"].ToString() : "";
            // collab.NiveauEtude = Convert.ToInt32(rdr["Niveau_Etude"]);
            candidat.IdentLieuNais_Designation = rdr["Ville_Desingation"] != DBNull.Value ? rdr["Ville_Desingation"].ToString() : "";
            candidat.NiveauScolaire_Designation = rdr["NiveauScolaire_Designation"] != DBNull.Value ? rdr["NiveauScolaire_Designation"].ToString() : "";
            candidat.Candidat_Tel = rdr["Candidat_Tel"] != DBNull.Value ? rdr["Candidat_Tel"].ToString() : "";
            candidat.Candidat_CV = rdr["Candidat_CV"] != DBNull.Value ? rdr["Candidat_CV"].ToString() : "";
            candidat.Candidat_Photo = rdr["Candidat_Photo"] != DBNull.Value ? rdr["Candidat_Photo"].ToString() : "";
            candidat.Candidat_LettreMotivation = rdr["Candidat_LettreMotivation"] != DBNull.Value ? rdr["Candidat_LettreMotivation"].ToString() : "";
          
            candidat.Candidat_DateNais = rdr["Candidat_DateNais"] != DBNull.Value ? Convert.ToDateTime(rdr["Candidat_DateNais"]) : System.DateTime.MinValue;
            candidat.Date_Modif = rdr["Date_Modif"] != DBNull.Value ? Convert.ToDateTime(rdr["Date_Modif"]) : System.DateTime.MinValue;
            return candidat;

        }
    }
}
