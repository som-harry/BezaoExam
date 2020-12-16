using RecruitingProject.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecruitingProject.Models
{
    public class JobFormViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Category")]
        public string Category { get; set; }


        [Required]
        [Display(Name = "The  Job Name")]
        public string JobName { get; set; }

        [Required]
        [Display(Name = "The  Job Description")]
        public string JobDescription { get; set; }

        [Required]
        [Display(Name = "The  Employer Name")]
        public string EmployerName { get; set; }

        [Required]
        [Display(Name = "About Employer")]
        public string AboutEmployer { get; set; }

        [Required]
        [Display(Name = "Estimated Amount")]
        public decimal Amount { get; set; }

        [Required]
        [Display(Name = "The Mobile Phone")]
        public string MobileNumber { get; set; }

        [Required]
        [Display(Name = "The Email ")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "The Phone ")]
        public string OfficeLine { get; set; }

        [Required]
        [Display(Name = "The  Website")]
        public string Website { get; set; }

        [Required]
        [Display(Name = "Job Deadline")]
        public DateTime JobDeadLine { get; set; }

        [Required]
        [Display(Name = "Upload your Job Image")]
        public HttpPostedFileBase File { get; set; }

    }
}