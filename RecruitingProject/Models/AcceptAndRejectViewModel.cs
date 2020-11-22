using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecruitingProject.Models
{
    public class AcceptAndRejectViewModel
    {
        public int AcceptedRequest { get; set; }
        public int RejectedRequest { get; set; }
        public int PendingRequest { get; set; }
    }
}