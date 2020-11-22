using RecruitingProject.Interface;
using RecruitingProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecruitingProject.Controllers
{
    public class JobController : Controller
    {
        IJob _jobRepo;

        public JobController(IJob jobRepo)
        {
            _jobRepo = jobRepo;
        }


        [AllowAnonymous]
        // GET: Job
        public ActionResult Index()
        {
            var job = _jobRepo.GetAllJobs();
            return View(job);
        }

        [Authorize(Roles = "ADMIN")]
        public ActionResult New()
        {
            return View("JobForm");
        }

        [Authorize(Roles = "ADMIN")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(JobFormViewModel model)
        {
            _jobRepo.CreateJob(model);

            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "APPLICANTS")]
        public ActionResult Details(int id)
        {
            try
            {
                var job = _jobRepo.Details(id);
                return View(job);
            }
            catch
            {
                ViewBag.Error = true;
                ViewBag("No job found");
            }

            return RedirectToAction("Index", "Job");
        }
    }
}