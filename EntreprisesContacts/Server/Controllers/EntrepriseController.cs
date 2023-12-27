using EntreprisesContacts.Server.Interfaces;
using EntreprisesContacts.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntreprisesContacts.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntrepriseController : ControllerBase
    {
        private readonly IEntreprise _entrepriseService;

        public EntrepriseController(IEntreprise entrepriseService)
        {
            _entrepriseService = entrepriseService;
        }

        [HttpGet]
        public async Task<List<Entreprise>> Get()
        {
            return await Task.FromResult(_entrepriseService.GetAllEntreprises());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Entreprise entreprise = _entrepriseService.GetEntrepriseData(id);
            if (entreprise != null)
            {
                return Ok(entreprise);
            }
            return NotFound();
        }

        [HttpPost]
        public void Post(Entreprise entreprise)
        {
            _entrepriseService.AddEntreprise(entreprise);
        }

        [HttpPut]
        public void Put(Entreprise entreprise)
        {
            _entrepriseService.UpdateEntreprise(entreprise);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _entrepriseService.DeleteEntreprise(id);
            return Ok();
        }

        [HttpGet]
        [Route("GetContactsByEntreprise/{id}")]
        public async Task<IEnumerable<Contact>> ContactsByEntrepriseList(int id)
        {
            return await Task.FromResult(_entrepriseService.GetContactsByEntreprise(id));
        }
    }
}
