using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsoApi.Models;
using MarsoApi.Controllers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using System.Web.Http;
using System.Net.Http;
using System.Linq;

namespace UnitTestMasoApi
{
    [TestClass]
    public class GRUPOControllersTest
    {
       
        [TestMethod]
        public void GetAllGroup()
        {
            var controller = new GRUPOController();

            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var result = controller.Get() as OkNegotiatedContentResult<IEnumerable<GRUPO>>;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(3, result.Content.Count());
        }


    }
}
