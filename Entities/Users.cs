using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class Users
    {
        public int User_Id { get; set; }

        public string User_Login { get; set; }

        public string User_Pwd { get; set; }

        public string User_PwdConfirm { get; set; }

        public string User_Ident_Nom { get; set; }

        public string User_Ident_Prenom { get; set; }

        public string User_Nom_Prenom { get; set; }

        public string User_Tele { get; set; }

        public string User_Ident_Cin { get; set; }

        public string User_Email { get; set; }

        public string User_Adresse { get; set; }

        public string User_EmailConfirm { get; set; }

        public DateTime User_Ident_DteCin { get; set; }

        public string User_IdentMatricule { get; set; }

        public DateTime User_Ident_DteNais { get; set; }

        public int User_IdentLieuNais { get; set; }

        public string Lieu_Designation { get; set; }

        public int User_SenderId { get; set; }

        public int User_Role { get; set; }

        public string Role_Designation { get; set; }

        public int User_Specialite { get; set; }

        public string Specialite_Designation { get; set; }

        public int User_Modif { get; set; }

        public DateTime Date_Modif { get; set; }

        public string User_Photo { get; set; }
        
    }
}
