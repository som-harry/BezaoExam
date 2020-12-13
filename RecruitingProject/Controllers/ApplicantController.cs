using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using RecruitingProject.Interface;
using RecruitingProject.Models;
using RecruitingProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static System.Web.HttpContext;

namespace RecruitingProject.Controllers
{
    public class ApplicantController : Controller
    {
        private ApplicationUserManager _manager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
        private ApplicationSignInManager _signInManager;

        IApplicant _applicantRepo;
        IMail _mailRepo;

        public ApplicantController(IApplicant applicantRepo, IMail mailRepo)
        {
            _applicantRepo = applicantRepo;
            _mailRepo = mailRepo;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        private ApplicationUserManager UserManager
        {
            get
            {
                return _manager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            set { _manager = value; }
        }

        [AllowAnonymous]
        // GET: Applicant
        public ActionResult Index()
        {
            return View("ApplicantForm");
        }

        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Save(ApplicantFormViewModel model, EditFormViewModel edit)
        {
            if (ModelState.IsValid)
            {   
                ApplicationUser user = new ApplicationUser()
                {
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    UserName = model.Email
                };
                IdentityResult result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {

                    _applicantRepo.CreateApplicant(model, user.Id);
                    var roleStore = new RoleStore<IdentityRole>(new ApplicationDbContext());
                    var rolemanager = new RoleManager<IdentityRole>(roleStore);
                    await rolemanager.CreateAsync(new IdentityRole("APPLICANTS"));
                    await UserManager.AddToRoleAsync(user.Id, "APPLICANTS");
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    //if successfully creates customer
                    TempData["Message"] = "Applicant account created successfully";
                    return RedirectToAction("Index", "Job");
                }
                else
                {
                    ViewBag.Message = result.Errors;
                    return View("Error");
                }
            }
            else
            {
                ModelState.AddModelError("1", "Failed to create customer");
            }
            return View("ApplicantForm");
        }

        [Authorize(Roles = "APPLICANTS")]
        public ActionResult Edit()
        {
           var viewModel = _applicantRepo.Edit();
           return View("EditForm", viewModel);
        }

        [Authorize(Roles = "APPLICANTS")]
        [HttpPost]
        public ActionResult Edit(EditFormViewModel model)
        {
            _applicantRepo.UpdateApplicant(model);

            return RedirectToAction("Index", "Job");
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            return View("Contact");
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> ContactMail(string message, string subject)
        {
           await _mailRepo.SendMail("Chisomekeh71@gmail.com",message, subject);
            return RedirectToAction("Index", "job");
        }

        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> Accept(int id)
        {
            var applicant = _applicantRepo.Accept(id);

            var user = await UserManager.FindByIdAsync(applicant.UserId);
            var mail = $"{applicant.FirstName} Congratulations, your application has been approved ";
            await _mailRepo.SendMail(user.Email, mail, "Your submission has been approved");

            return View("Accept", applicant);
        }

        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> Reject(int id)
        {
            var applicant = _applicantRepo.Reject(id);

            var user = await UserManager.FindByIdAsync(applicant.UserId);
            var mail = $" Sorry {applicant.FirstName}, your application wasn't successful ";
            await _mailRepo.SendMail(user.Email, mail, "Your submission has been approved");

            return View("Accept",  applicant);
        }
    }
}