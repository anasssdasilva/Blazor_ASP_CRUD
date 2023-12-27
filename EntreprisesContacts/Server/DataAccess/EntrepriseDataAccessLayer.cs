using EntreprisesContacts.Server.Interfaces;
using EntreprisesContacts.Server.Models;
using EntreprisesContacts.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace EntreprisesContacts.Server.DataAccess
{
    public class EntrepriseDataAccessLayer :IEntreprise
    {
        readonly ContactDBContext _dbContext = new();

        public EntrepriseDataAccessLayer(ContactDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        //To Get all entreprises details   
        public List<Entreprise> GetAllEntreprises()
        {
            try
            {
                return _dbContext.Entreprises.ToList();
            }
            catch
            {
                throw;
            }
        }

        //To Add new Entreprise record     
        public void AddEntreprise(Entreprise entreprise)
        {
            try
            {
                _dbContext.Entreprises.Add(entreprise);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        //To Update the records of a particluar Entreprise    
        public void UpdateEntreprise(Entreprise entreprise)
        {
            try
            {
                _dbContext.Entry(entreprise).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        //Get the details of a particular Entreprise    
        public Entreprise GetEntrepriseData(int id)
        {
            try
            {
                Entreprise? entreprise = _dbContext.Entreprises.Find(id);

                if (entreprise != null)
                {
                    return entreprise;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record of a particular Entreprise    
        public void DeleteEntreprise(int id)
        {
            try
            {
                Entreprise? entreprise = _dbContext.Entreprises.Find(id);

                if (entreprise != null)
                {
                    _dbContext.Entreprises.Remove(entreprise);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        // To get the list of contacts by Entreprise
        public List<Contact> GetContactsByEntreprise(int id)
        {
            try
            {
                Entreprise entreprise = GetEntrepriseData(id);
                return _dbContext.Contacts.Where(contact => contact.Entreprise == entreprise.Name).ToList();
            }
            catch
            {
                throw;
            }
        }
    }
}
