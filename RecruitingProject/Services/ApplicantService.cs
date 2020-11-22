using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNet.Identity;
using RecruitingProject.Entity;
using RecruitingProject.Infrastructure;
using RecruitingProject.Interface;
using RecruitingProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Web.HttpContext;

namespace RecruitingProject.Services
{
    public class ApplicantService:IApplicant
    {
        ContextService dbContext;
        private CloudinaryInitialization _cloudinaryInitialization = new CloudinaryInitialization();
        public ApplicantService(ContextService _context)
        {
            dbContext = _context;
        }

        public void CreateApplicant(ApplicantFormViewModel model, string userid)
        {
            //setting up the image
            var cloudinary = _cloudinaryInitialization.initialize();

            var image = new ImageUploadParams()
            {
                File = new FileDescription(model.File.FileName, model.File.InputStream)
            };

            var upload = cloudinary.Upload(image);
            Applicant newapplicant = new Applicant()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                ApplicationStatus = ApplicationStatus.pending,
                Dob = model.Dob,
                ImageLocation = upload.SecureUrl.AbsoluteUri,
                UserId = userid
            };
            dbContext.context.Applicants.Add(newapplicant);
            dbContext.context.SaveChanges();
        }

        public EditFormViewModel Edit()
        {
            //get the current userId and match with the applicant user id from the database
            var userId = Current.User.Identity.GetUserId();
            var applicant = dbContext.context.Applicants.SingleOrDefault(a => a.User.Id == userId);

            if (applicant == null)
                throw new Exception("There is no current applicant ");

            var viewModel = new EditFormViewModel()
            {
                Address = applicant.Address,
                FirstName = applicant.FirstName,
                LastName = applicant.LastName,
                Dob = applicant.Dob,
            };
            return viewModel;   
        }

        public void UpdateApplicant(EditFormViewModel model)
        {
            //get the current userId and match with the applicant user id from the database

            var userId = Current.User.Identity.GetUserId();
            var applicantInDb = dbContext.context.Applicants.SingleOrDefault(a => a.User.Id == userId);

            applicantInDb.FirstName = model.FirstName;
            applicantInDb.LastName = model.LastName;
            applicantInDb.Address = model.Address;
            applicantInDb.Dob = model.Dob;

            dbContext.context.SaveChanges();
        }

        public Applicant Accept(int id)
        {
            // get the current applicant 
            var applicant = dbContext.context.Applicants.SingleOrDefault(a => a.id == id);

            if (applicant == null)
                throw new Exception(" Id didn't match");

            if(applicant.ApplicationStatus != ApplicationStatus.accept)
            {
                applicant.ApplicationStatus = ApplicationStatus.accept;
                dbContext.context.Entry(applicant).State = EntityState.Modified;
                dbContext.context.SaveChanges();
            }

            return applicant;
        }

        public Applicant Reject(int id)
        {
            // get the current applicant 
            var applicant = dbContext.context.Applicants.SingleOrDefault(a => a.id == id);

            if (applicant == null)
                throw new Exception(" Id didn't match");

            if (applicant.ApplicationStatus != ApplicationStatus.reject)
            {
                applicant.ApplicationStatus = ApplicationStatus.reject;
                dbContext.context.Entry(applicant).State = EntityState.Modified;
                dbContext.context.SaveChanges();
            }

            return applicant;
        }


    }
}