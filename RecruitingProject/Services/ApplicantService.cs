using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using RecruitingProject.Entity;
using RecruitingProject.Infrastructure;
using RecruitingProject.Interface;
using RecruitingProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

            //setting up the file
            byte[] uploadedFile = new byte[model.Files.InputStream.Length];
            model.Files.InputStream.Read(uploadedFile, 0, uploadedFile.Length);

            Applicant newapplicant = new Applicant()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                ApplicationStatus = true,
                Dob = model.Dob,
                JobRole = model.JobRole,
                ImageLocation = upload.SecureUrl.AbsoluteUri,
                Resume = uploadedFile,
                UserId = userid
            };
            dbContext.context.Applicants.Add(newapplicant);
            dbContext.context.SaveChanges();
        }
    }
}