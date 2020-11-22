using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecruitingProject.Models
{
    public class EditFormViewModel
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
    }
}