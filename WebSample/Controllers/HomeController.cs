using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSample.Controllers
{
    public class HomeController : Controller
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        public ActionResult Index()
        {
            _logger.Info("Hello, Nlog on Web");

            try
            {
                throw new Exception("Oh,My God!!");
            }
            catch (Exception ex)
            {
                _logger.Error("Exception occured", ex);
            }
            _logger.Error("Hello, Nlog on Web, Error Error");

            return View();
        }
	}
}