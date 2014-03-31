using MvcCastleIntegration.Controllers.Interfaces;
using MvcCastleIntegration.Dependencies;
using MvcCastleIntegration.Models;
using System.Web.Mvc;

namespace MvcCastleIntegration.Controllers
{
    public class TestController : Controller, ITestController
    {
        public IMessageSource Messages { get; set; }

        //
        // GET: /Test/
        public ActionResult Index()
        {
            var model = new DisplayMessage();

            model.Message = Messages.GetMessage();

            return View(model);
        }
    }
}
