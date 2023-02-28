using Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IRepository
{
   public interface ICollaborateurRepository
    {
        public List<Users> GetAllCollaborateurs();
        public List<RoleUser> GetAllRoleUsers();
        public List<SpecialiteUser> GetAllSpecialite();
        public List<Ville> GetAllVille();
        public int GetLastIdCollab();
        public void AjouterCollaborateur(Users appUser);
        public DataTable CheckUserNameExist(string UserNomPrenom);
        public DataTable IsEmailAddressExist(string User_Email);
        public bool SendEmail(string email, string body, string title);
        public bool InsertEmailConfirm(int userId);
        public void AjouterCollab(Users user);
        public void AjouterAppConfirm(AppConfirm app);
        public void ModifierCollaborateur(Offres offre);
        public void UploadFile(int UserId, IFormFile Image, string pathImage);



    }
}
