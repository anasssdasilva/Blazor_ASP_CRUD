using EntreprisesContacts.Server.Interfaces;
using EntreprisesContacts.Server.Models;
using EntreprisesContacts.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace EntreprisesContacts.Server.DataAccess
{
    public class ContactDataAccessLayer :IContact
    {
        readonly ContactDBContext _dbContext = new();

        public ContactDataAccessLayer(ContactDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        //To Get all contacts details   
        public List<Contact> GetAllContacts()
        {
            try
            {
                return _dbContext.Contacts.ToList();
            }
            catch
            {
                throw;
            }
        }

        //To Add new Contact record     
        public void AddContact(Contact contact)
        {
            try
            {
                _dbContext.Contacts.Add(contact);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        //To Update the records of a particluar contact    
        public void UpdateContact(Contact contact)
        {
            try
            {
                _dbContext.Entry(contact).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        //Get the details of a particular contact    
        public Contact GetContactData(int id)
        {
            try
            {
                Contact? contact = _dbContext.Contacts.Find(id);

                if (contact != null)
                {
                    return contact;
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

        //To Delete the record of a particular contact    
        public void DeleteContact(int id)
        {
            try
            {
                Contact? contact = _dbContext.Contacts.Find(id);

                if (contact != null)
                {
                    _dbContext.Contacts.Remove(contact);
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

        // To get the list of Entreprises
        public List<Entreprise> GetEntreprise()
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
       
    }
}
