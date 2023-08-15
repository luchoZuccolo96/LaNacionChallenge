using System;
using System.ComponentModel.DataAnnotations;

namespace ChallengeLaNacion.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Company { get; set; }

        public byte[]? Profile_Image { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public DateTime? Birthdate { get; set; }

        [Required]
        public string? Work_Phone { get; set; }

        [Required]
        public string? Personal_Phone { get; set; }

        [Required]
        public string? Address { get; set; }
    }
}
