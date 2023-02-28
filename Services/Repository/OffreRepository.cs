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
    public class OffreRepository: IOffreRepository
    {

        public List<Offres> GetAllOffres()
        {
            List<Offres> list = new List<Offres>();
            using (SqlConnection con = new SqlConnection(Connection.Singleton.SqlConnetionFactory.ConnectionString))
            {
                try
                {
                    con.Open();
                    var cmd = new SqlCommand("SP_SelectAllOffre");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 20000;
                    var rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Offres offre = OffreBuilder.GetAllOffres(rdr);
                        list.Add(offre);
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

        public void PublierOffre(Offres offre)
        {

            var Id_Offre = 0;
            using (SqlConnection con = new SqlConnection(Connection.Singleton.SqlConnetionFactory.ConnectionString))
            {
                try
                {
                    con.Open();


                   var cmd = new SqlCommand("dbo.Sp_Offre_Insert");
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@Offre_Designation", offre.OffreDesignation));
                    cmd.Parameters.Add(new SqlParameter("@Lieu_Offre", offre.LieuOffre));
                    cmd.Parameters.Add(new SqlParameter("@Postes_Vancants", offre.PostesVancants));
                    cmd.Parameters.Add(new SqlParameter("@Type_Emploi", offre.TypeEmploi));
                    cmd.Parameters.Add(new SqlParameter("@Nb_Ans_Exp", offre.NbAnsExp));

                    cmd.Parameters.Add(new SqlParameter("@Niveau_Etude", offre.NiveauEtude));
                    cmd.Parameters.Add(new SqlParameter("@Description_Emploi", offre.DescriptionEmploi));
                    cmd.Parameters.Add(new SqlParameter("@Exigence_Emploi", offre.ExigenceEmploi));
                    cmd.Parameters.Add(new SqlParameter("@Date_Expiration",offre.DateExpiration != null ? offre.DateExpiration : System.DateTime.Now));
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


        public void ModifierOffre(Offres offre)
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


        public List<NiveauScolaire> GetAllNiveauScolaire()
        {
            List<NiveauScolaire> list = new List<NiveauScolaire>();
            using (SqlConnection con = new SqlConnection(Connection.Singleton.SqlConnetionFactory.ConnectionString))
            {
                try
                {
                    con.Open();
                    var cmd = new SqlCommand("SP_SelectAllNiveauScolaire");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 20000;
                    var rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        NiveauScolaire niveauScolaire = OffreBuilder.GetAllNiveauScolaire(rdr);
                        list.Add(niveauScolaire);
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

         public List<TypeEmploi> GetAllTypeEmploi()
        {
            List<TypeEmploi> list = new List<TypeEmploi>();
            using (SqlConnection con = new SqlConnection(Connection.Singleton.SqlConnetionFactory.ConnectionString))
            {
                try
                {
                    con.Open();
                    var cmd = new SqlCommand("SP_SelectAllTypeEmploi");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 20000;
                    var rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        TypeEmploi typeEmploi = OffreBuilder.GetAllTypeEmploi(rdr);
                        list.Add(typeEmploi);
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

        public List<Pays> GetAllPays()
        {
            List<Pays> list = new List<Pays>();
            using (SqlConnection con = new SqlConnection(Connection.Singleton.SqlConnetionFactory.ConnectionString))
            {
                try
                {
                    con.Open();
                    var cmd = new SqlCommand("SP_SelectAllPays");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 20000;
                    var rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Pays pays = OffreBuilder.GetAllPays(rdr);
                        list.Add(pays);
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
    }
}
