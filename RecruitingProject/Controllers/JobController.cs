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
            var job = _jobRepo.GetThreeJobs();
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
            if (ModelState.IsValid)
            {
                _jobRepo.CreateJob(model);
                return View("MoreJobs");
            }

            else
            {
                ModelState.AddModelError("1", "Failed to create job");
            }
            return View("JobForm");

        }

        [Authorize(Roles = "ADMIN")]
        public ActionResult Edit(int id)
        {
            var viewModel = _jobRepo.Edit(id);
            
            return View(viewModel);
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        public ActionResult UpdateJob(JobEditFormViewModel model, int id)
        {
            _jobRepo.UpdateJob(model, id);
            return RedirectToAction("Index", "Admin");
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

            return View("Index");
        }

        [AllowAnonymous]
        // GET: Job
        public ActionResult ViewMoreJob()
        {
            var job = _jobRepo.GetAllJobs();
            return View("MoreJobs",job);
        }
    }
}