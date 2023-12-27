using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntreprisesContacts.Shared.Models
{
    public partial class Entreprise
    {
        public int EntrepriseId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string FirstAdress { get; set; }

        public string SecondAdress { get; set; }

        public string Zip { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        [Required]
        public string Phone { get; set; }

        [NotMapped]
        public string thumbnail { get; set; }
    }
}
