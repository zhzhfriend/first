using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using TYAJZWeb.Data;

namespace TYAJZWeb.Controllers
{
    public class BaseController : Controller
    {
        protected TYAJZDataContext Context = null;

        protected BaseController()
        {
            Context = new TYAJZDataContext();
        }
    }
}
