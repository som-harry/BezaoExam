using RecruitingProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecruitingProject.Services
{
    public class ContextService:Controller
    {
        public ApplicationDbContext context;
        public ContextService()
        {
            context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }
    }
}