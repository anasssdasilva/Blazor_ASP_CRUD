using EntreprisesContacts.Shared.Models;

namespace EntreprisesContacts.Server.Interfaces
{
    public interface IContact
    {
        public List<Contact> GetAllContacts();

        public void AddContact(Contact contact);

        public void UpdateContact(Contact contact);

        public Contact GetContactData(int id);

        public void DeleteContact(int id);

        public List<Entreprise> GetEntreprise();

    }
}
