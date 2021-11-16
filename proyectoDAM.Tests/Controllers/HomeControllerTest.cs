using Microsoft.VisualStudio.TestTools.UnitTesting;
using proyectoDAM;
using proyectoDAM.Controllers;
using System.Web.Mvc;

namespace proyectoDAM.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Disponer
            HomeController controller = new HomeController();

            // Actuar
            ViewResult result = controller.Index() as ViewResult;

            // Declarar
            Assert.IsNotNull(result);
            Assert.AreEqual("Seweser", result.ViewBag.Title);
        }
    }
}
