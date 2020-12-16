using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RecruitingProject.Entity
{
    public class Job
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string JobName { get; set; }
        public string  JobDescription { get; set; }
        public string EmployerName { get; set; }
        public string AboutEmployer { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string OfficeLine { get; set; }
        public string Website { get; set; }
        public string ImageLocation { get; set; }
        public DateTime JobDeadLine { get; set; }
        public decimal Amount { get; set; }
        public ICollection<Applicant> Applicants { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }

    }
}