using System.ComponentModel.DataAnnotations;

namespace DoctorWebAPI.Model
{
	public class Doctor
	{
		public Guid Id { get; set; }

		[Required(ErrorMessage = "Name is required")]
		public string? Name { get; set; }

		[Required(ErrorMessage = "Email is required")]
		[EmailAddress(ErrorMessage = "Invalid Email Address")]

		public string? Email { get; set; }

		[Required(ErrorMessage = "Phone no is required")]
		[RegularExpression(@"\d{10}$", ErrorMessage = "Invalid phone number format")]

		public long phone { get; set; }

		[Required(ErrorMessage = "Salary is required")]
		[Range(0, long.MaxValue, ErrorMessage = "Salary must be a positive value")]

		public long Salary { get; set; }

		[Required(ErrorMessage = "Department is required")]

		public string? Department { get; set; }


	}
}
