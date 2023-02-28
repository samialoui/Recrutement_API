using Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;




// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Recrutement_API.Controllers
{
    
    public class RecrutementController : ControllerBase
    {

        [HttpGet]
        [Route("api/Recrutement/GetAllRecrutements")]
        public List<Recrutements> GetAllRecrutements()
        {
            return UnitOfWork.RecrutementRepository.GetAllRecrutments();
        }

        // GET api/<RecrutementController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

     

        // DELETE api/<RecrutementController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
