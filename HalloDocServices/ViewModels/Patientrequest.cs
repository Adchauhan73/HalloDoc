using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace HalloDocServices.ViewModels
{
    public class Patientrequest
    {
        
        [Required(ErrorMessage = "FirstName is required")]
        public required string FirstName { get; set; } = null!;


        [Required(ErrorMessage = "LastName is required")]
        public required string LastName { get; set; }


        [Required(ErrorMessage = "PhoneNumber is required")]
		public required string PhoneNumber { get; set; }


		[Required(ErrorMessage = "Email is required")]
		public required string Email { get; set; } = null!;


		[Required(ErrorMessage = "ZipCode is required")]
		public required string ZipCode { get; set; }


		[Required(ErrorMessage = "State is required")]
		public required string State { get; set; }


		[Required(ErrorMessage = "City is required")]
		public required string City { get; set; }


		[Required(ErrorMessage = "Street is required")]
		public required string Street { get; set; }


		[Required(ErrorMessage = "Symptoms is required")]
		public required string Symptoms { get; set; }

        public  string? Room { get; set; }


		[Required(ErrorMessage = "BirthDate is required")]
		public required DateTime BirthDate { get; set; }

        public  IEnumerable<IFormFile>? File { get; set; }










    }
}
