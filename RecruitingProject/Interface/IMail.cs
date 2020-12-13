using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitingProject.Interface
{
   public  interface IMail
    {
       Task SendMail(string recieverEmail, string messageBody, string messageSubject);
    }
}
