using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recrutement_API.Controllers
{
   
    public class CollaborateurController : ControllerBase
    {

        private IConfiguration _config;

        public CollaborateurController(IConfiguration config)
        {
            _config = config;
        }


        [HttpGet]
        [Route("api/Collaborateur/GetAllCollaborateurs")]
        public List<Users> GetAllCollaborateurs()
        {
            return UnitOfWork.CollaborateurRepository.GetAllCollaborateurs();
        }

        [HttpPost]
        [Route("api/Collaborateur/AjouterCollaborateur")]

        public void AjouterCollaborateur([FromBody] Users user)
        {
            {
               
                UnitOfWork.CollaborateurRepository.AjouterCollaborateur(user);
            }
        }

        [HttpPut]
        [Route("api/Collaborateur/ModifierCollaborateur")]

        public void ModifierCollaborateur([FromBody] Offres user)
        {
            {

                UnitOfWork.CollaborateurRepository.ModifierCollaborateur(user);
            }
        }

        [HttpGet]
        [Route("api/Collaborateur/GetAllRoleUsers")]
        public List<RoleUser> GetAllRoleUsers()
        {
            return UnitOfWork.CollaborateurRepository.GetAllRoleUsers();
        }
        [HttpGet]
        [Route("api/Collaborateur/GetAllSpecialite")]
        public List<SpecialiteUser> GetAllSpecialite()
        {
            return UnitOfWork.CollaborateurRepository.GetAllSpecialite();
        }

        [HttpGet]
        [Route("api/Collaborateur/GetAllVilles")]
        public List<Ville> GetAllVilles()
        {
            return UnitOfWork.CollaborateurRepository.GetAllVille();
        }

        [HttpGet]
        [Route("api/Collaborateur/GetLastIdCollab")]
        public int GetLastIdCollab()
        {
            return UnitOfWork.CollaborateurRepository.GetLastIdCollab();
        }

        [HttpPut]
        [Route("api/Collaborateur/UploadFile")]

        public void UploadFile(Users user)
        {
            {
                var image = Request.Form.Files["Image"];

               var pathImage = _config["PathImageCollaborateur"];
              
                int UserId = UnitOfWork.CollaborateurRepository.GetLastIdCollab();

                UnitOfWork.CollaborateurRepository.UploadFile(UserId, image,pathImage);
            }
        }
        //select MAX(User_Id) from V_ListAllUsers
    }
}
