using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using RecruitingProject.Interface;
using RecruitingProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RecruitingProject.Controllers
{
    [ValidateAntiForgeryToken]
    public class ApplicantController : Controller
    {
        private ApplicationUserManager _manager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
        private ApplicationSignInManager _signInManager;

        IApplicant _applicantRepo;

        public ApplicantController(IApplicant applicantRepo)
        {
            _applicantRepo = applicantRepo;
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

        // GET: Applicant
        public ActionResult Index()
        {
            return View("ApplicantForm");
        }

        [HttpPost]
        public async Task<ActionResult> Save(ApplicantFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("1", "Failed to create customer");
                return View("ApplicationForm");
            }
            if (model.id == 0)
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
                    return RedirectToAction("Index", "Applicant");
                }
            }
            else
            {
                //_customerRepo.UpdateCustomer(model);
            }
            return RedirectToAction("ProductForm", "Customer");
        }
    }
}