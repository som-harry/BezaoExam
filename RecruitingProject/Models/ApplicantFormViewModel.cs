using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecruitingProject.Models
{
    public class ApplicantFormViewModel
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "Your first name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Your last name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Your address")]
        [StringLength(200, MinimumLength = 10)]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Your Birthday")]
        public DateTime Dob { get; set; }

        [Required]
        [Display(Name = "Postion you are applying for")]
        public string JobRole { get; set; }

        [Required(ErrorMessage = "Please enter a valid Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a valid phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter a valid password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and confirm password do not match")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Profile Image")]
        public HttpPostedFileBase File { get; set; }

        [Required]
        [Display(Name = "Upload your resume")]
        public HttpPostedFileBase Files { get; set; }
    }
}