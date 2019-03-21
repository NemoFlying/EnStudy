using EnStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnStudy.Controllers
{
    public class EnStudyBaseController : Controller
    {
        // GET: EnStudyBase
       
        protected User GUserInfo=>(User)HttpContext.Session["userinfo"];
    }
}