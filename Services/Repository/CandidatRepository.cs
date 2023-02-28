using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Services.Builders;
using Services.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repository
{
    public class CandidatRepository : ICandidatRepository
    {
        public static bool state = false;


        public List<Candidat> GetAllCandidats()
        {
            List<Candidat> list = new List<Candidat>();
            using (SqlConnection con = new SqlConnection(Connection.Singleton.SqlConnetionFactory.ConnectionString))
            {
                try
                {
                    con.Open();
                    var cmd = new SqlCommand("SP_V_ListAllCandidats");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 20000;
                    var rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Candidat candidat = CandidatBuilder.GetAllCandidats(rdr);
                        list.Add(candidat);
                    }
                    return list;
                }
                catch
                {
                    throw;

                }
                finally
                {
                    con.Close();
                }
            }
        }
        public List<Ville> GetAllVille()
        {
            List<Ville> list = new List<Ville>();
            using (SqlConnection con = new SqlConnection(Connection.Singleton.SqlConnetionFactory.ConnectionString))
            {
                try
                {
                    con.Open();
                    var cmd = new SqlCommand("SP_SelectAllVille");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 20000;
                    var rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Ville ville = CandidatBuilder.GetAllVille(rdr);
                        list.Add(ville);
                    }
                    return list;
                }
                catch
                {
                    throw;

                }
                finally
                {
                    con.Close();
                }
            }
        }
        public void AjouterCandidat(Candidat candidat)
        {




            string Message = string.Empty;
            string successMsg = string.Empty;




            DataTable dt = new DataTable();
            DataTable Edt = new DataTable();



            candidat.Candidat_Photo = "no-image.jpg";
            candidat.Candidat_LettreMotivation = "no-document.jpg";
            candidat.Candidat_CV = "no-document.jpg";


            string UserNomPrenom = candidat.Candidat_Nom_Prenom;
            string email = candidat.Candidat_Mail;

            dt = CheckUserNameExist(UserNomPrenom);

            if (dt.Rows.Count < 1)
            {

                Edt = IsEmailAddressExist(email);
                if (Edt.Rows.Count < 1)
                {
                    AjouterNVCandidat(candidat);

                }
                else
                {
                    Message = "L'adresse mail (" + email + ") déjà existe, veuillez choisir une autre adresse mail";
                    // return View();
                }
            }
            else
            {
                Message = "Le collaborateur  (" + UserNomPrenom + ") est déjà existe, veuillez vérifier le nom et prénom";
                //return View();
            }




        }

        public void AjouterNVCandidat(Candidat candidat)
        {

            var Id_User = 0;
            using (SqlConnection con = new SqlConnection(Connection.Singleton.SqlConnetionFactory.ConnectionString))
            {
                try
                {
                    con.Open();


                    var cmd = new SqlCommand("dbo.Sp_Candidat_Insert");
                    cmd.CommandType = CommandType.StoredProcedure;

                    
                    cmd.Parameters.Add(new SqlParameter("@Candidat_Nom", candidat.Candidat_Nom));
                    cmd.Parameters.Add(new SqlParameter("@Candidat_Prenom", candidat.Candidat_Prenom));
                    cmd.Parameters.Add(new SqlParameter("@Candidat_Nom_Prenom", candidat.Candidat_Nom_Prenom));
                    cmd.Parameters.Add(new SqlParameter("@Candidat_Tel", candidat.Candidat_Tel));
                   
                    cmd.Parameters.Add(new SqlParameter("@Candidat_Adressse", candidat.Candidat_Adressse));
                    cmd.Parameters.Add(new SqlParameter("@Candidat_CV", candidat.Candidat_CV));
                    cmd.Parameters.Add(new SqlParameter("@Candidat_IdentLieuNais", candidat.Candidat_IdentLieuNais));
                    cmd.Parameters.Add(new SqlParameter("@Candidat_LettreMotivation", candidat.Candidat_LettreMotivation));
                    cmd.Parameters.Add(new SqlParameter("@Candidat_Mail", candidat.Candidat_Mail));
                    cmd.Parameters.Add(new SqlParameter("@Candidat_NbreAnneExperience", candidat.Candidat_NbreAnneExperience));
            
                    cmd.Parameters.Add(new SqlParameter("@Candidat_Photo", candidat.Candidat_Photo));
                    cmd.Parameters.Add(new SqlParameter("@FormationCandidat_Specialite", candidat.FormationCandidat_Specialite));
                    cmd.Parameters.Add(new SqlParameter("@Candidat_NiveauScolaireId", candidat.Candidat_NiveauScolaireId));
                    cmd.Parameters.Add(new SqlParameter("@Candidat_DateNais", candidat.Candidat_DateNais));
                    
                    cmd.Parameters.Add(new SqlParameter("@Candidat_NationaliteId", candidat.Candidat_NationaliteId));
                    cmd.Parameters.Add(new SqlParameter("@Candidat_EtatCivilId", candidat.Candidat_EtatCivilId));
                    cmd.Parameters.Add(new SqlParameter("@Date_Modif", System.DateTime.Now));


                    // cmd.Parameters.Add(new SqlParameter("@Commentaire", demandeCh.Commentaire != null ? demandeCh.Commentaire : ""));


                    cmd.Connection = con;
                    cmd.CommandTimeout = 20000;
                    var rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Id_User = Convert.ToInt32(rdr["Candidat_Id"]);
                    }
                    // return DemandeId;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }


        }

        public void UploadFile(int UserId, IFormFile Image,string pathImage)
        {
            string filename = null;
            filename = new String(Path.GetFileNameWithoutExtension(Image.FileName).Take(10).ToArray()).Replace(" ", "-");
            filename = filename + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(Image.FileName);
            var physicalPath = Path.Combine(@pathImage, filename);

            using (var stream = new FileStream(physicalPath, FileMode.Create))
            {
                Image.CopyTo(stream);
            }

            var Id_User = 0;
            using (SqlConnection con = new SqlConnection(Connection.Singleton.SqlConnetionFactory.ConnectionString))
            {
                try
                {
                    con.Open();


                    var cmd = new SqlCommand("dbo.Sp_UploadFileCandidat");
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@Candidat_Id", UserId));
                    cmd.Parameters.Add(new SqlParameter("@Candidat_Photo", filename));

                    cmd.Connection = con;
                    cmd.CommandTimeout = 20000;
                    var rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Id_User = Convert.ToInt32(rdr["Candidat_Id"]);
                    }
                    // return DemandeId;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }


        }

        public void UploadCV(int UserId, IFormFile CV,string pathFile)
        {
            string filename = null;
            filename = new String(Path.GetFileNameWithoutExtension(CV.FileName).Take(10).ToArray()).Replace(" ", "-");
            filename = filename + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(CV.FileName);
            var physicalPath = Path.Combine(@pathFile, filename);

            using (var stream = new FileStream(physicalPath, FileMode.Create))
            {
                CV.CopyTo(stream);
            }

            var Id_User = 0;
            using (SqlConnection con = new SqlConnection(Connection.Singleton.SqlConnetionFactory.ConnectionString))
            {
                try
                {
                    con.Open();


                    var cmd = new SqlCommand("dbo.Sp_UploadCVCandidat");
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@Candidat_Id", UserId));
                    cmd.Parameters.Add(new SqlParameter("@Candidat_CV", filename));

                    cmd.Connection = con;
                    cmd.CommandTimeout = 20000;
                    var rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Id_User = Convert.ToInt32(rdr["Candidat_Id"]);
                    }
                    // return DemandeId;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }


        }

        public void UploadLettreMotivation(int UserId, IFormFile LettreMotivation, string pathFile)
        {
            string filename = null;
            filename = new String(Path.GetFileNameWithoutExtension(LettreMotivation.FileName).Take(10).ToArray()).Replace(" ", "-");
            filename = filename + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(LettreMotivation.FileName);
            var physicalPath = Path.Combine(@pathFile, filename);

            using (var stream = new FileStream(physicalPath, FileMode.Create))
            {
                LettreMotivation.CopyTo(stream);
            }

            var Id_User = 0;
            using (SqlConnection con = new SqlConnection(Connection.Singleton.SqlConnetionFactory.ConnectionString))
            {
                try
                {
                    con.Open();


                    var cmd = new SqlCommand("dbo.Sp_UploadLettreMotivationCandidat");
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@Candidat_Id", UserId));
                    cmd.Parameters.Add(new SqlParameter("@Candidat_LettreMotivation", filename));

                    cmd.Connection = con;
                    cmd.CommandTimeout = 20000;
                    var rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Id_User = Convert.ToInt32(rdr["Candidat_Id"]);
                    }
                    // return DemandeId;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }


        }
        public int GetLastIdCandidat()
        {
            int UserId = 0;
            using (SqlConnection con = new SqlConnection(Connection.Singleton.SqlConnetionFactory.ConnectionString))
            {
                try
                {


                    var cmd = new SqlCommand("select convert(int,MAX(Candidat_Id))  as LastCandidat from V_ListAllCandidats");
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con; cmd.CommandTimeout = 20000;
                    con.Open();
                    var rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {

                        UserId = rdr["LastCandidat"] != DBNull.Value ? (int)rdr["LastCandidat"] : 0;


                    }
                    con.Close();
                }
                catch (Exception)
                {
                    con.Close();
                    return UserId;
                }
            }


            return UserId;


        }

        public DataTable CheckUserNameExist(string UserNomPrenom)
        {
            state = false;
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Candidat_Nom_Prenom", SqlDbType.NVarChar, 250);
            param[0].Value = UserNomPrenom;

            dt = CollaborateurBuilder.SelectData("CheckUserNameCandidatExist", param);
            state = CollaborateurBuilder.state;
            return dt;
        }

        public DataTable IsEmailAddressExist(string User_Email)
        {
            state = false;
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Candidat_Mail", SqlDbType.NVarChar, 250);
            param[0].Value = User_Email;

            dt = CandidatBuilder.SelectData("CheckEmailCandidatExist", param);
            state = CandidatBuilder.state;
            return dt;
            // return db.AppUsers.Any(a => a.Email == email);
        }
    }
}
