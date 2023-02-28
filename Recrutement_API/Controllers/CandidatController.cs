using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Services;
using System.Collections.Generic;



namespace Recrutement_API.Controllers
{
   
    public class CandidatController : ControllerBase
    {
        public IConfiguration _config;

        public CandidatController(IConfiguration config)
        {
            _config = config;
        }


        [HttpGet]
        [Route("api/Candidat/GetAllCandidats")]
        public List<Candidat> GetAllCandidats()
        {
            return UnitOfWork.CandidatRepository.GetAllCandidats();
        }

        [HttpPost]
        [Route("api/Candidat/AjouterCandidat")]

        public void AjouterCandidat([FromBody] Candidat candidat)
        {
            {

                UnitOfWork.CandidatRepository.AjouterCandidat(candidat);
            }
        }

        [HttpPut]
        [Route("api/Collaborateur/ModifierCollaborateur")]

        public void ModifierCandidat([FromBody] Offres user)
        {
            {

                UnitOfWork.CollaborateurRepository.ModifierCollaborateur(user);
            }
        }

        [HttpGet]
        [Route("api/Candidat/GetAllNiveauScolaire")]
        public List<NiveauScolaire> GetAllNiveauScolaire()
        {
            return UnitOfWork.OffreRepository.GetAllNiveauScolaire();
        }

        [HttpGet]
        [Route("api/Candidat/GetAllVilles")]
        public List<Ville> GetAllVilles()
        {
            return UnitOfWork.CandidatRepository.GetAllVille();
        }

      

        [HttpPut]
        [Route("api/Candidat/UploadFile/Image")]

        public void UploadImage(Users user)
        {
            {
                var image = Request.Form.Files["Image"];
                var pathImage = _config["PathImageCandidat"];
                int UserId = UnitOfWork.CandidatRepository.GetLastIdCandidat();

                UnitOfWork.CandidatRepository.UploadFile(UserId, image,pathImage);
            }
        }

        [HttpPut]
        [Route("api/Candidat/UploadFile/CV")]

        public void UploadCV(Users user)
        {
            {
                var CV = Request.Form.Files["CV"];
                var pathFile = _config["PathFileCV"];
                int UserId = UnitOfWork.CandidatRepository.GetLastIdCandidat();

                UnitOfWork.CandidatRepository.UploadCV(UserId, CV,pathFile);
            }
        }

        [HttpPut]
        [Route("api/Candidat/UploadFile/LettreMotivation")]

        public void UploadLettreMotivation(Users user)
        {
            {
                var LettreMotivation = Request.Form.Files["LettreMotivation"];
                var pathFile = _config["PathFileLettreMotivation"];

                int UserId = UnitOfWork.CandidatRepository.GetLastIdCandidat();

                UnitOfWork.CandidatRepository.UploadLettreMotivation(UserId, LettreMotivation,pathFile);
            }
        }
    }
}
