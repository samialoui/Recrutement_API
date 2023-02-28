using Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Builders
{
    public static class OffreBuilder
    {
        public static Offres GetAllOffres(SqlDataReader rdr)
        {
            Offres Offre = new Offres();

            Offre.IdOffre = Convert.ToInt32(rdr["Id_Offre"]);
            Offre.OffreDesignation = rdr["Offre_Designation"] != DBNull.Value ? rdr["Offre_Designation"].ToString() : "";
            Offre.LieuOffre = rdr["Lieu_Offre"] != DBNull.Value ? rdr["Lieu_Offre"].ToString() : "";
            Offre.PostesVancants = Convert.ToInt32(rdr["Postes_Vancants"]);
            Offre.TypeEmploi_Designation = rdr["EmploiType_Designation"] != DBNull.Value ? rdr["EmploiType_Designation"].ToString() : "";
            Offre.TypeEmploi = Convert.ToInt32(rdr["Type_Emploi"]);
            Offre.NbAnsExp = rdr["Nb_Ans_Exp"] != DBNull.Value ? rdr["Nb_Ans_Exp"].ToString() : "";
            Offre.NiveauEtude_Designation = rdr["NiveauScolaire_Designation"] != DBNull.Value ? rdr["NiveauScolaire_Designation"].ToString() : "";
            Offre.NiveauEtude = Convert.ToInt32(rdr["Niveau_Etude"]);
            Offre.DescriptionEmploi = rdr["Description_Emploi"] != DBNull.Value ? rdr["Description_Emploi"].ToString() : "";
            Offre.ExigenceEmploi = rdr["Exigence_Emploi"] != DBNull.Value ? rdr["Exigence_Emploi"].ToString() : "";
            Offre.DateExpiration = rdr["Date_Expiration"] != DBNull.Value ? Convert.ToDateTime(rdr["Date_Expiration"]) : System.DateTime.MinValue;
            Offre.DateModif = rdr["Date_Modif"] != DBNull.Value ? Convert.ToDateTime(rdr["Date_Modif"]) : System.DateTime.MinValue;

            return Offre;

        }

        public static NiveauScolaire GetAllNiveauScolaire(SqlDataReader rdr)
        {
            NiveauScolaire niveauScolaire = new NiveauScolaire();

            niveauScolaire.NiveauScolaire_Id = Convert.ToInt32(rdr["NiveauScolaire_Id"]);
            niveauScolaire.NiveauScolaire_Designation = rdr["NiveauScolaire_Designation"] != DBNull.Value ? rdr["NiveauScolaire_Designation"].ToString() : "";
            niveauScolaire.NiveauScolaire_Code = rdr["NiveauScolaire_Code"] != DBNull.Value ? rdr["NiveauScolaire_Code"].ToString() : "";
            niveauScolaire.User_Modif = Convert.ToInt32(rdr["User_Modif"]);
            niveauScolaire.Date_Modif = rdr["Date_Modif"] != DBNull.Value ? Convert.ToDateTime(rdr["Date_Modif"]) : System.DateTime.MinValue;

            return niveauScolaire;

        }
        public static TypeEmploi GetAllTypeEmploi(SqlDataReader rdr)
        {
            TypeEmploi typeEmploi = new TypeEmploi();

            typeEmploi.EmploiType_Id = Convert.ToInt32(rdr["EmploiType_Id"]);
            typeEmploi.EmploiType_Designation = rdr["EmploiType_Designation"] != DBNull.Value ? rdr["EmploiType_Designation"].ToString() : "";
            typeEmploi.EmploiType_Code = rdr["EmploiType_Code"] != DBNull.Value ? rdr["EmploiType_Code"].ToString() : "";
            typeEmploi.User_Modif = Convert.ToInt32(rdr["User_Modif"]);
            typeEmploi.Date_Modif = rdr["Date_Modif"] != DBNull.Value ? Convert.ToDateTime(rdr["Date_Modif"]) : System.DateTime.MinValue;

            return typeEmploi;

        }

        public static Pays GetAllPays(SqlDataReader rdr)
        {
            Pays pays = new Pays();

            pays.Pays_Id = Convert.ToInt32(rdr["Pays_Id"]);
            pays.Pays_Designation = rdr["Pays_Designation"] != DBNull.Value ? rdr["Pays_Designation"].ToString() : "";
            pays.Pays_Code = rdr["Pays_Code"] != DBNull.Value ? rdr["Pays_Code"].ToString() : "";
            //pays.User_Modif = Convert.ToInt32(rdr["User_Modif"]);
            pays.Date_Modif = rdr["Date_Modif"] != DBNull.Value ? Convert.ToDateTime(rdr["Date_Modif"]) : System.DateTime.MinValue;

            return pays;

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
