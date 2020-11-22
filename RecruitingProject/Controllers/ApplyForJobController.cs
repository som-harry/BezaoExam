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
        public ApplyForJobController(IApplyForJob applyRepo)
        {
            _applyRepo = applyRepo;
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
            var mail = $"Your application has been recieved," +
                $" you applied for this position {viewModel.JobRole};" +
                $" We acknowledge you to wait for our feedback";
            await NotificationRequest.SendMail(user.Email, mail, "Application Submission");

            return View("ReviewPage", viewModel);
        }
    }
}