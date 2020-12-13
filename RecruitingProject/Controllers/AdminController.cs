using RecruitingProject.Interface;
using RecruitingProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecruitingProject.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class AdminController : Controller
    {

        IAdmin _adminRepo;
        public AdminController(IAdmin adminRepo)
        {
            _adminRepo = adminRepo;
        }

        // GET: Admin
        public ActionResult Index()
        {
            var viewModel = new AcceptAndRejectViewModel()
            {
                AcceptedRequest = _adminRepo.AcceptedRequest(),
                RejectedRequest = _adminRepo.RejectedtedRequest(),
                PendingRequest = _adminRepo.PendingRequest()
            };
          
            return View(viewModel);
        }

        public ActionResult GetAllAvaliableJobs()
        {
            var viewModel = _adminRepo.GetAllJobs();

            return View("GetAllAvaliableJobs",viewModel);
        }

        public ActionResult GetAllSubmittedApplication()
        {
            var viewModel = _adminRepo.GetSubmittedApplication();

            return View("GetAllSubmittedApplication", viewModel);
        }

        public ActionResult GetAllAcceptedRequest()
        {
            var viewModel = _adminRepo.GetAllAcceptedRequest();

            return View(viewModel);
        }
        public ActionResult GetAllRejectedRequest()
        {
            var viewModel = _adminRepo.GetAllRejectedRequest();

            return View(viewModel);
        }
        public ActionResult GetAllPendingRequest()
        {
            var viewModel = _adminRepo.GetAllPendingRequest();

            return View(viewModel);
        }

        public ActionResult GetAllApplicantfortheJob(int id)
        {
            var viewModel = _adminRepo.GetAllApplicantfortheJob(id);
            return View("GetAllApplicantfortheJob", viewModel);
        }

        public ActionResult Display(int id)
        {
            _adminRepo.display(id);
            return View();
        }

        public ActionResult Details(int id)
        {
            var viewModel = _adminRepo.Details(id);
            return View(viewModel);
        }
    }
}