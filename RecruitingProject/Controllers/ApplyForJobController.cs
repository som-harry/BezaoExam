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
    public class ApplyForJobController : Controller
    {
        private ApplicationUserManager _manager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));

        IApplyForJob _applyRepo;
        IMail _mailRepo;
        public ApplyForJobController(IApplyForJob applyRepo, IMail mailRepo)
        {
            _applyRepo = applyRepo;
            _mailRepo = mailRepo;
        }

        private ApplicationUserManager UserManager
        {
            get
            {
                return _manager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            set { _manager = value; }
        }

        [Authorize(Roles = "APPLICANTS")]

        // GET: ApplyForJobController
        public ActionResult Index(int id)
        {
            var viewModel = new ApplyFormViewModel
            {
                JobId = id,
            };
            return View("ApplyForm", viewModel);
        }

        [Authorize(Roles = "APPLICANTS")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Save(ApplyFormViewModel model)
        {
            var userId = Current.User.Identity.GetUserId();
            var viewModel =   _applyRepo.SubmitResume(model);
            var user = await UserManager.FindByIdAsync(userId);

            //send mail with the applicant info
            var mail = $"{user.Email} has applied for a job," +
                $" He applied for the position {viewModel.JobRole};" +
                $" Please do well to accept or reject him ";
            await _mailRepo.SendMail("chisomekeh71@gmail.com", mail, "Application Submission");

            return View("ReviewPage", viewModel);
        }
    }
}