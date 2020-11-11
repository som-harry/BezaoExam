using CloudinaryDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecruitingProject.Infrastructure
{
    public class CloudinaryInitialization
    {
        public Cloudinary initialize()
        {
            Account account = new Account(
                 "sommy",
                 "753628146372445",
                 "2vmVcSiUcuN7XPxoorMVr3y_6cI"
                 );
            return new Cloudinary(account);
        }
    }
}