using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RecruitingProject.Entity
{
    public class ApplyForJob
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string JobRole { get; set; }
        public string UploadResume { get; set; }
        public DateTime DateApply { get; set; }
        public string WhatYourgreatestAchieviement { get; set; }
        public int JobId { get; set; }
        public Job Job { get; set; }
        public int ApplicantId { get; set; }
        public Applicant Applicant { get; set; }
    }
}