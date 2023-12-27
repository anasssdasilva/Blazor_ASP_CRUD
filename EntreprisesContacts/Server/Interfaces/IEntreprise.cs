using EntreprisesContacts.Shared.Models;

namespace EntreprisesContacts.Server.Interfaces
{
    public interface IEntreprise
    {
        public List<Entreprise> GetAllEntreprises();

        public void AddEntreprise(Entreprise entreprise);

        public void UpdateEntreprise(Entreprise entreprise);

        public Entreprise GetEntrepriseData(int id);

        public void DeleteEntreprise(int id);

        public List<Contact> GetContactsByEntreprise(int id);

    }
}
