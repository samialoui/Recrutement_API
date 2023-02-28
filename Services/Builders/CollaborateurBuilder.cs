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
    public static class CollaborateurBuilder
    {
        public static bool state = false;
        public static Users GetAllCollaborateurs(SqlDataReader rdr)
        {
            Users collab = new Users();

            collab.User_Id = Convert.ToInt32(rdr["User_Id"]);
            collab.User_Ident_Nom = rdr["User_Ident_Nom"] != DBNull.Value ? rdr["User_Ident_Nom"].ToString() : "";
            collab.User_Ident_Prenom = rdr["User_Ident_Prenom"] != DBNull.Value ? rdr["User_Ident_Prenom"].ToString() : "";
            collab.User_Nom_Prenom = rdr["User_Nom_Prenom"] != DBNull.Value ? rdr["User_Nom_Prenom"].ToString() : "";
           // collab. = Convert.ToInt32(rdr["Postes_Vancants"]);
            collab.Specialite_Designation = rdr["Specialite_Designation"] != DBNull.Value ? rdr["Specialite_Designation"].ToString() : "";
           // collab.TypeEmploi = Convert.ToInt32(rdr["Type_Emploi"]);
            collab.User_Email = rdr["User_Email"] != DBNull.Value ? rdr["User_Email"].ToString() : "";
            collab.Role_Designation = rdr["Role_Designation"] != DBNull.Value ? rdr["Role_Designation"].ToString() : "";
           // collab.NiveauEtude = Convert.ToInt32(rdr["Niveau_Etude"]);
            collab.Lieu_Designation = rdr["Ville_Desingation"] != DBNull.Value ? rdr["Ville_Desingation"].ToString() : "";
            collab.User_IdentMatricule = rdr["User_IdentMatricule"] != DBNull.Value ? rdr["User_IdentMatricule"].ToString() : "";
            collab.User_Tele = rdr["User_Tele"] != DBNull.Value ? rdr["User_Tele"].ToString() : "";
            collab.User_Photo = rdr["User_Photo"] != DBNull.Value ? rdr["User_Photo"].ToString() : "";
            collab.User_Ident_DteNais = rdr["User_Ident_DteNais"] != DBNull.Value ? Convert.ToDateTime(rdr["User_Ident_DteNais"]) : System.DateTime.MinValue;
            collab.User_Ident_DteCin = rdr["User_Ident_DteCin"] != DBNull.Value ? Convert.ToDateTime(rdr["User_Ident_DteCin"]) : System.DateTime.MinValue;

            return collab;

        }
        public static RoleUser GetAllRoleUsers(SqlDataReader rdr)
        {
            RoleUser roleUser = new RoleUser();

            roleUser.Role_Id = Convert.ToInt32(rdr["Role_Id"]);
            roleUser.RoleUser_Designation = rdr["Role_Designation"] != DBNull.Value ? rdr["Role_Designation"].ToString() : "";
           
            roleUser.Date_Modif = rdr["Date_Modif"] != DBNull.Value ? Convert.ToDateTime(rdr["Date_Modif"]) : System.DateTime.MinValue;

            return roleUser;

        }
        public static SpecialiteUser GetAllSpecialite(SqlDataReader rdr)
        {
            SpecialiteUser specialite = new SpecialiteUser();

            specialite.Specialite_Id = Convert.ToInt32(rdr["Specialite_Id"]);
            specialite.Specialite_Designation = rdr["Specialite_Designation"] != DBNull.Value ? rdr["Specialite_Designation"].ToString() : "";

            specialite.Date_Modif = rdr["Date_Modif"] != DBNull.Value ? Convert.ToDateTime(rdr["Date_Modif"]) : System.DateTime.MinValue;

            return specialite;

        }

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
    }
}
