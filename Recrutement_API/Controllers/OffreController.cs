using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;
using System.Net.Http;

namespace Recrutement_API.Controllers
{
  
    public class OffreController : ControllerBase
    {
        [HttpGet]
        [Route("api/Offre/GetAllOffres")]
        public List<Offres> GetAllOffres()
        {
            return UnitOfWork.OffreRepository.GetAllOffres();
        }

        [HttpPost]
        [Route("api/Offre/PublierOffre")]
      
        public void PublierOffre([FromBody] Offres offre)
        {
            {    
                UnitOfWork.OffreRepository.PublierOffre(offre);         
            }
        }

        [HttpPut]
        [Route("api/Offre/ModifierOffre")]

        public void ModifierOffre([FromBody] Offres offre)
        {
            {

                UnitOfWork.OffreRepository.ModifierOffre(offre);
            }
        }


        [HttpGet]
        [Route("api/Offre/GetAllNiveauEtude")]
        public List<NiveauScolaire> GetAllNiveauEtude()
        {
            return UnitOfWork.OffreRepository.GetAllNiveauScolaire();
        }

        [HttpGet]
        [Route("api/Offre/GetAllTypeEmploi")]
        public List<TypeEmploi> GetAllTypeEmploi()
        {
            return UnitOfWork.OffreRepository.GetAllTypeEmploi();
        }

        [HttpGet]
        [Route("api/Offre/GetAllPays")]
        public List<Pays> GetAllPays()
        {
            return UnitOfWork.OffreRepository.GetAllPays();
        }

        [HttpGet]
        [Route("api/Offre/GetAllVille")]
        public List<Ville> GetAllVille()
        {
            return UnitOfWork.OffreRepository.GetAllVille();
        }

     
    }
}
