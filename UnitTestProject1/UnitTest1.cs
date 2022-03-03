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
using System.Data.Entity.Core.Objects;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1 
    {
        
        [TestMethod]
        public void GetAllGroup()
        {
            /*vamo acceder al token*/

                    
            var controller = new GRUPOController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var result = controller.Get() as OkNegotiatedContentResult<IEnumerable<GRUPO>>;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(1, result.Content.Count());
          

        }

        [TestMethod]
        public void ObtainToken()
        {
            /*vamo acceder al token*/


            var controller = new AccountController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            MarsoApi.Models.Login login = new Login();
            login = SetLogin();

            var result = controller.Login(login) as OkNegotiatedContentResult<IEnumerable<Login>>;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(1, result.Content.Count());


        }

        public string GetToken()
        {
            string toke = "";
            var controller = new AccountController();

            
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

           MarsoApi.Models.Login login = new Login();
            login = SetLogin();
            var result = controller.Login(login) as OkNegotiatedContentResult<IEnumerable<GRUPO>>;
            toke = result.ToString();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(3, result.Content.Count());


            return toke;
        }


        private Login SetLogin()
        {
            Login test = new Login  { Username = "Marso.api", Password = "123456" };
           

            return test;
        }
    }
}
