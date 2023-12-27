using EntreprisesContacts.Server.Interfaces;
using EntreprisesContacts.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntreprisesContacts.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContact _contactService;

        public ContactController(IContact contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<List<Contact>> Get()
        {
            return await Task.FromResult(_contactService.GetAllContacts());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Contact contact = _contactService.GetContactData(id);
            if (contact != null)
            {
                return Ok(contact);
            }
            return NotFound();
        }
        
        [HttpPost]
        public void Post(Contact contact)
        {
            _contactService.AddContact(contact);
        }

        [HttpPut]
        public void Put(Contact contact)
        {
            _contactService.UpdateContact(contact);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _contactService.DeleteContact(id);
            return Ok();
        }

        [HttpGet]
        [Route("GetEntrepriseList")]
        public async Task<IEnumerable<Entreprise>> EntrepriseList()
        {
            return await Task.FromResult(_contactService.GetEntreprise());
        }

    }
}

