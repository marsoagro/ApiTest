using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MarsoApi.Models;
namespace MarsoApi.Controllers
{
    [AllowAnonymous]
    public class AccountController : ApiController
    {
        public AccountController() { }
        
        /// <summary>
                                    /// Metodo que en teoria realizara la autenticacion
                                    /// </summary>
                                    /// <param name="logindto"></param>
                                    /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Login(Login logindto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool isCredentialvalid = (logindto.Password == "123456");
            if (isCredentialvalid)
            {
                var token = TokenGenerator.GenerateTokenJwt(logindto.Username);
                return Ok(token);
            }
            else
            return Unauthorized();
        }
    }
}
