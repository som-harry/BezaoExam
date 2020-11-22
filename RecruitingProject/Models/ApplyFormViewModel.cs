using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecruitingProject.Models
{
    public class ApplyFormViewModel
    {
        public int Id { get; set; }

        public int JobId { get; set; }

        [Required]
        [Display(Name ="What is your greatest achievement")]
        public string WhatYourgreatestAchieviement { get; set; }

        [Required]
        [Display(Name ="Upload your resume")]
        public HttpPostedFileBase File { get; set; }

        [Required]
        [Display(Name ="Your stack")]
        public string JobRole { get; set; }
    }
}