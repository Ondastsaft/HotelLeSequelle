using System.ComponentModel.DataAnnotations;

namespace HotelLeSequelle.Models
{
    public abstract partial class Person
    {
        public int PersonId { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Nationality { get; set; }
        public string? StreetAdress { get; set; }
        public string? ZipCode { get; set; }
        public string? Locality { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }


    }
}


