using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Candidat
    {
        public int Candidat_Id { get; set; }


        public string Candidat_Nom { get; set; }

        public string Candidat_Prenom { get; set; }

        public string Candidat_Nom_Prenom { get; set; }

        public DateTime Candidat_DateNais { get; set; }

        public string Candidat_Adressse { get; set; }

        public string Candidat_Mail { get; set; }

        public string Candidat_Tel { get; set; }

        public int Candidat_NationaliteId { get; set; }

        public int Candidat_LicenceId { get; set; }

        public int Candidat_EtatCivilId { get; set; }

        public int Candidat_NiveauScolaireId { get; set; }
        public string NiveauScolaire_Designation { get; set; }

        public int Candidat_NbreAnneExperience { get; set; }

        public int User_Modif { get; set; }

        public DateTime Date_Modif { get; set; }

        public int Candidat_IdentLieuNais { get; set; }
        public string IdentLieuNais_Designation { get; set; }

        public string Candidat_LettreMotivation { get; set; }

        public string Candidat_CV { get; set; }

        public string Candidat_Photo { get; set; }

        public int Site_Id { get; set; }

        public int Fonction_Id { get; set; }

        public int NiveauScolaire_Id { get; set; }

        public int Etablissement_Id { get; set; }

        public string FormationCandidat_Specialite { get; set; }
        
    }
}
