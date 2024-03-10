using System.ComponentModel.DataAnnotations;

namespace HalloDocServices.ViewModels
{
    public class Conceirgerequest1
    {
        [Required(ErrorMessage = "YourFirstName is required")]
        public required string YourFirstName { get; set; } = null!;


        [Required(ErrorMessage = "YourLastName is required")]
        public required string YourLastName { get; set; }


        [Required(ErrorMessage = "YourPhoneNumber is required")]
        public required string YourPhoneNumber { get; set; }


        [Required(ErrorMessage = "YourEmail is required")]
        public required string YourEmail { get; set; }

        public string? PropertyName { get; set; }


        [Required(ErrorMessage = "YouStreet is required")]
        public required string YourStreet { get; set; }


        [Required(ErrorMessage = "YourCity is required")]
        public required string YourCity { get; set; }


        [Required(ErrorMessage = "YourState is required")]
        public required string YourState { get; set; }


        [Required(ErrorMessage = "YourZipCode is required")]
        public required string YourZipCode { get; set; }


        [Required(ErrorMessage = "Symptoms is required")]
        public required string Symptoms { get; set; }


        [Required(ErrorMessage = "FirstName is required")]
        public required string FirstName { get; set; }


        [Required(ErrorMessage = "LastName is required")]
        public required string LastName { get; set; }


        [Required(ErrorMessage = "BirthDate is required")]
        public required string BirthDate { get; set; }


        [Required(ErrorMessage = "Email is required")]
        public required string Email { get; set; }


        [Required(ErrorMessage = "PhoneNumber is required")]
        public required string PhoneNumber { get; set; }

        public string? Room { get; set; }


    }
}
