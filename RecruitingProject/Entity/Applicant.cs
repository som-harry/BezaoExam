using RecruitingProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RecruitingProject.Entity
{
    public enum ApplicationStatus
    {
        pending,
        reject,
        accept
    }
    public class Applicant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string FirstName { get; set; }
        public string  LastName { get; set; }
        public string  Address { get; set; }
        public DateTime Dob { get; set; }
        public  ApplicationStatus ApplicationStatus { get; set; }
        public string ImageLocation { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

    }
}