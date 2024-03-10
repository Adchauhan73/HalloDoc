using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace HalloDocServices.ViewModels
{
    public class Familyrequest
    {

        [Required(ErrorMessage = "YourFirstName is required")]
        public required string YourFirstName { get; set; } = null!;


        [Required(ErrorMessage = "YourLastName is required")]
        public required string YourLastName { get; set; }


        [Required(ErrorMessage = "YourPhoneNumber is required")]
        public required string YourPhoneNumber { get; set; }


        [Required(ErrorMessage = "YourEmail is required")]
        public required string YourEmail { get; set; } = null!;


        [Required(ErrorMessage = "Symptoms is required")]
        public required string Symptoms { get; set; }


        [Required(ErrorMessage = "FirstName is required")]
        public required string FirstName { get; set; }


        [Required(ErrorMessage = "LastName is required")]
        public required string LastName { get; set; }


        [Required(ErrorMessage = "BirthDate is required")]
        public required DateTime BirthDate { get; set; }


        [Required(ErrorMessage = "Email is required")]
        public required string Email { get; set; }


        [Required(ErrorMessage = "PhoneNumber is required")]
        public required string PhoneNumber { get; set; }


        [Required(ErrorMessage = "RelationWithPatient is required")]
        public required string RelationWithPatient { get; set; }


        [Required(ErrorMessage = "street is required")]
        public required string Street { get; set; }


        [Required(ErrorMessage = "City is required")]
        public required string City { get; set; }


        [Required(ErrorMessage = "State is required")]
        public required string State { get; set; }


        [Required(ErrorMessage = "ZipCode is required")]
        public required string ZipCode { get; set; }

        public  string? Room { get; set; }


        public IEnumerable<IFormFile>? File { get; set; }


    }
}
