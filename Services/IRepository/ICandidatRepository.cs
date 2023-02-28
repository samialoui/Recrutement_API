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
    public interface ICandidatRepository
    {
        public void AjouterCandidat(Candidat candidat);
        public List<Ville> GetAllVille();
        public List<Candidat> GetAllCandidats();
        public void AjouterNVCandidat(Candidat candidat);
        public void UploadFile(int UserId, IFormFile Image, string pathImage);
        public void UploadCV(int UserId, IFormFile CV, string pathFile);
        public void UploadLettreMotivation(int UserId, IFormFile LettreMotivation, string pathFile);
        public int GetLastIdCandidat();
        public DataTable CheckUserNameExist(string UserNomPrenom);
        public DataTable IsEmailAddressExist(string User_Email);

    }
}
