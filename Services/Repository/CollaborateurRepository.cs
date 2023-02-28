using Data;
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
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repository
{
    public class CollaborateurRepository: ICollaborateurRepository
    {
        public static bool state = false;
        public List<Users> GetAllCollaborateurs()
        {
            List<Users> list = new List<Users>();
            using (SqlConnection con = new SqlConnection(Connection.Singleton.SqlConnetionFactory.ConnectionString))
            {
                try
                {
                    con.Open();
                    var cmd = new SqlCommand("SP_V_ListAllUsers");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 20000;
                    var rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Users collab = CollaborateurBuilder.GetAllCollaborateurs(rdr);
                        list.Add(collab);
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
        public List<RoleUser> GetAllRoleUsers()
        {
            List<RoleUser> list = new List<RoleUser>();
            using (SqlConnection con = new SqlConnection(Connection.Singleton.SqlConnetionFactory.ConnectionString))
            {
                try
                {
                    con.Open();
                    var cmd = new SqlCommand("SP_SelectAllRole");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 20000;
                    var rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        RoleUser roleUser = CollaborateurBuilder.GetAllRoleUsers(rdr);
                        list.Add(roleUser);
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
        public List<SpecialiteUser> GetAllSpecialite()
        {
            List<SpecialiteUser> list = new List<SpecialiteUser>();
            using (SqlConnection con = new SqlConnection(Connection.Singleton.SqlConnetionFactory.ConnectionString))
            {
                try
                {
                    con.Open();
                    var cmd = new SqlCommand("SP_SelectAllSpecialite");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 20000;
                    var rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        SpecialiteUser specialite = CollaborateurBuilder.GetAllSpecialite(rdr);
                        list.Add(specialite);
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
                        Ville ville = OffreBuilder.GetAllVille(rdr);
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
       
        public void AjouterCollaborateur(Users appUser)
        {
            

          

            string Message = string.Empty;
           string successMsg = string.Empty;




                   DataTable dt = new DataTable();
                   DataTable Edt = new DataTable();

                   string passwordCrypte =  AppHash.Encrypt(appUser.User_Pwd);
                   string passwordConfCrypte = AppHash.Encrypt(appUser.User_PwdConfirm);
            //appUser.User_EmailConfirm = AppHash.Encrypt(input);

                    appUser.User_Photo = "no-image.jpg";
                    appUser.User_Pwd = passwordCrypte;
                    appUser.User_PwdConfirm = passwordConfCrypte;
                    
                    string UserNomPrenom = appUser.User_Nom_Prenom;
                    string email = appUser.User_Email;

                    dt = CheckUserNameExist(UserNomPrenom);

                    if (dt.Rows.Count < 1)
                    {
                       
                        Edt = IsEmailAddressExist(email);
                        if (Edt.Rows.Count < 1)
                        {
                            AjouterCollab(appUser);
                             
                            string userId =AppHash.Encrypt((appUser.User_Id).ToString());
                            string Password = AppHash.Decrypt((appUser.User_Pwd).ToString());

                            string title = "Confirmez votre inscription à l'application VisioRecru ";
                            string body = "Bonjour " + UserNomPrenom + "<br />";
                            body += "Votre compte a été créé avec succès " + "<br />" + "<br />";
                            body += "Voici votre login: " + appUser.User_Login + "<br />" + "<br />";
                            body += "et votre mot de passe: " + Password + "<br />" + "<br />";
                            body += "https://localhost:44313/Acount/AccountValidate?UId=" + userId;

                            if (SendEmail(email, body, title))  
                            {
                                if ( InsertEmailConfirm(appUser.User_Id))
                                {
                                    successMsg = "Compte Collaborateur a créé avec succès";
                                
                                }
                                else
                                {
                                    Message = "Erreur lors de l'ajout du compte, veuillez réessayer plus tard";
                                }
                            }
                            else
                            {
                                if ( InsertEmailConfirm(appUser.User_Id))
                                {
                                    Message = "Le compte a été créé avec succès et le message d'activation n'a pas pu être envoyé à l'adresse e-mail de collaborateur";
                                }
                            }

                         

                          //  return RedirectToAction(nameof(Register));
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

    
        public DataTable CheckUserNameExist(string UserNomPrenom)
        {
             state = false;
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@User_Nom_Prenom", SqlDbType.NVarChar, 250);
            param[0].Value = UserNomPrenom;

            dt = CollaborateurBuilder.SelectData("CheckUserNameExist", param);
            state =CollaborateurBuilder.state;
            return dt;
        }
    
        public DataTable IsEmailAddressExist(string User_Email)
        {
            state = false;
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@User_Email", SqlDbType.NVarChar, 250);
            param[0].Value = User_Email;

            dt = CollaborateurBuilder.SelectData("CheckEmailExist", param);
            state = CollaborateurBuilder.state;
            return dt;
            // return db.AppUsers.Any(a => a.Email == email);
        }
        public static string GetRoleId(string roleName)
        {
            string str = string.Empty;
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@RoleName", SqlDbType.NVarChar, 150);
            param[0].Value = roleName;

            DataAccessLayer DAL = new DataAccessLayer();
            dt = DAL.SelectData("GetMemberId", param);
            if (dt.Rows.Count > 0)
            {
                str = dt.Rows[0][0].ToString();
            }

            return str;
        }

        public bool SendEmail(string email, string body, string title)
        {
            try
            {
                MailMessage ms = new MailMessage("saami.aloui@gmail.com", email);
                ms.Subject = title;
                ms.Body = body;
                ms.IsBodyHtml = true;
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.Credentials = new NetworkCredential()
                {
                    UserName = "saami.aloui@gmail.com",
                    Password = "rragsqimqrxkggto"
                };

                client.EnableSsl = true;
                client.Send(ms);

                return true;
            }
            catch { }

            return false;
        }

        public bool InsertEmailConfirm(int userId)
        {
            try
            {
                AppConfirm app = new AppConfirm();
                app.UserId = userId;
                app.DateConfirm = DateTime.Now;
                AjouterAppConfirm(app);
                int id = app.Id;
               
                return true;
            }
            catch { }

            return false;
        }
       
        public void AjouterCollab(Users user)
        {

            var Id_User = 0;
            using (SqlConnection con = new SqlConnection(Connection.Singleton.SqlConnetionFactory.ConnectionString))
            {
                try
                {
                    con.Open();

            
                    var cmd = new SqlCommand("dbo.Sp_Collaborateur_Insert");
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@User_Login", user.User_Login));
                    cmd.Parameters.Add(new SqlParameter("@User_Pwd", user.User_Pwd));
                    cmd.Parameters.Add(new SqlParameter("@User_Ident_Nom", user.User_Ident_Nom));
                    cmd.Parameters.Add(new SqlParameter("@User_Ident_Prenom", user.User_Ident_Prenom));
                    cmd.Parameters.Add(new SqlParameter("@User_Nom_Prenom", user.User_Nom_Prenom));
                    cmd.Parameters.Add(new SqlParameter("@User_Ident_Cin", user.User_Ident_Cin != "NULL" ? user.User_Ident_Cin : ""));
                    cmd.Parameters.Add(new SqlParameter("@User_Ident_DteCin", user.User_Ident_DteCin));
                    cmd.Parameters.Add(new SqlParameter("@User_IdentMatricule", user.User_Login));
                    cmd.Parameters.Add(new SqlParameter("@User_Ident_DteNais", user.User_Ident_DteNais));
                    cmd.Parameters.Add(new SqlParameter("@User_Tele", user.User_Tele));
                    cmd.Parameters.Add(new SqlParameter("@User_IdentLieuNais", user.User_IdentLieuNais));
                    cmd.Parameters.Add(new SqlParameter("@User_Adresse", user.User_Adresse != "NULL" ? user.User_Adresse: ""));
                    cmd.Parameters.Add(new SqlParameter("@User_SpecialiteId", user.User_Specialite));
                    cmd.Parameters.Add(new SqlParameter("@User_Modif", user.User_Modif));
                    cmd.Parameters.Add(new SqlParameter("@User_Photo", user.User_Photo));
                    cmd.Parameters.Add(new SqlParameter("@User_RoleId", user.User_Role));
                    cmd.Parameters.Add(new SqlParameter("@User_Email", user.User_Email));
                    cmd.Parameters.Add(new SqlParameter("@User_EmailConfirm", 1));
                    cmd.Parameters.Add(new SqlParameter("@User_PwdConfirm", user.User_PwdConfirm));
                    cmd.Parameters.Add(new SqlParameter("@Date_Modif", System.DateTime.Now));
              

                    // cmd.Parameters.Add(new SqlParameter("@Commentaire", demandeCh.Commentaire != null ? demandeCh.Commentaire : ""));


                    cmd.Connection = con;
                    cmd.CommandTimeout = 20000;
                    var rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Id_User = Convert.ToInt32(rdr["User_Id"]);
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


        public void AjouterAppConfirm(AppConfirm app)
        {

            using (SqlConnection con = new SqlConnection(Connection.Singleton.SqlConnetionFactory.ConnectionString))
            {
                try
                {
                    con.Open();


                    var cmd = new SqlCommand("dbo.Sp_UserConfirm_Insert");
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@User_Id", app.UserId));
                    cmd.Parameters.Add(new SqlParameter("@Date_Confirm", app.DateConfirm));
             


                    // cmd.Parameters.Add(new SqlParameter("@Commentaire", demandeCh.Commentaire != null ? demandeCh.Commentaire : ""));


                    cmd.Connection = con;
                    cmd.CommandTimeout = 20000;
                    var rdr = cmd.ExecuteReader();

                  

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


        public void ModifierCollaborateur(Offres offre)
        {

            var Id_Offre = 0;
            using (SqlConnection con = new SqlConnection(Connection.Singleton.SqlConnetionFactory.ConnectionString))
            {
                try
                {
                    con.Open();


                    var cmd = new SqlCommand("dbo.Sp_Offre_Update");
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@Id_Offre", offre.IdOffre));
                    cmd.Parameters.Add(new SqlParameter("@Offre_Designation", offre.OffreDesignation));
                    cmd.Parameters.Add(new SqlParameter("@Lieu_Offre", offre.LieuOffre));
                    cmd.Parameters.Add(new SqlParameter("@Postes_Vancants", offre.PostesVancants));
                    cmd.Parameters.Add(new SqlParameter("@Type_Emploi", offre.TypeEmploi));
                    cmd.Parameters.Add(new SqlParameter("@Nb_Ans_Exp", offre.NbAnsExp));

                    cmd.Parameters.Add(new SqlParameter("@Niveau_Etude", offre.NiveauEtude));
                    cmd.Parameters.Add(new SqlParameter("@Description_Emploi", offre.DescriptionEmploi));
                    cmd.Parameters.Add(new SqlParameter("@Exigence_Emploi", offre.ExigenceEmploi));
                    cmd.Parameters.Add(new SqlParameter("@Date_Expiration", offre.DateExpiration != null ? offre.DateExpiration : System.DateTime.Now));
                    cmd.Parameters.Add(new SqlParameter("@Date_Modif", System.DateTime.Now));

                    // cmd.Parameters.Add(new SqlParameter("@Commentaire", demandeCh.Commentaire != null ? demandeCh.Commentaire : ""));


                    cmd.Connection = con;
                    cmd.CommandTimeout = 20000;
                    var rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Id_Offre = Convert.ToInt32(rdr["Id_Offre"]);
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

        public int GetLastIdCollab()
        {
            int UserId = 0;
            using (SqlConnection con = new SqlConnection(Connection.Singleton.SqlConnetionFactory.ConnectionString))
            {
                try
                {


                   var cmd = new SqlCommand("select convert(int,MAX(User_Id))  as LastUser from V_ListAllUsers");
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con; cmd.CommandTimeout = 20000;
                    con.Open();
                    var rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {

                        UserId = rdr["LastUser"] != DBNull.Value ? (int)rdr["LastUser"] : 0;
                        
                        
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


                    var cmd = new SqlCommand("dbo.Sp_UploadFile");
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@User_Id", UserId));
                    cmd.Parameters.Add(new SqlParameter("@User_Photo", filename));
                
                    cmd.Connection = con;
                    cmd.CommandTimeout = 20000;
                    var rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Id_User = Convert.ToInt32(rdr["User_Id"]);
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


    }
}
