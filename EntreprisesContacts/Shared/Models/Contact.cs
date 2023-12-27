using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace EntreprisesContacts.Shared.Models
{
    public class Contact
    {
        public int ContactId { get; set; }

        [Required]
        public string Lastname { get; set; } = null!;

        [Required]
        public string Firstname { get; set; } = null!;

        [Required]
        public string Entreprise { get; set; } = null!;

        [Required]
        public string Phone { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;
    }
}
