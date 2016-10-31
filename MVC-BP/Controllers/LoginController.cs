using Model_BP;
using MVC_BP.Includes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace MVC_BP.Controllers
{
    public class LoginController : Controller
    {
        public JsonResult Login(string Username, string Password, bool rememberMe)
        {
            if (Username == "" || Password == "")
            {
                return Json("Null", JsonRequestBehavior.AllowGet);
            }

            var kor = new KorisnikDTO
            {
                UsernameDTO = Username,
                SifraDTO = Password
            };

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = client.PostAsJsonAsync<KorisnikDTO>(DefaultAPI.GetPath("Korisnik/Login").ToString(), kor).Result;

                if (response.IsSuccessStatusCode)
                {
                    var rez = response.Content.ReadAsAsync<KorisnikDTO>().Result;
                    if (rez != null)
                    {
                        if (rememberMe)
                            SignIn(kor.UsernameDTO, true);
                        else
                            SignIn(kor.UsernameDTO, false);

                        return Json("Pocetna", JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json("Error", JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json("Greska", JsonRequestBehavior.AllowGet);
                }
            }
        }

        public void SignIn(string Username, bool createPersistentCookie)
        {
            if (createPersistentCookie)
            {
                Response.Cookies.Clear();
                int timeout = createPersistentCookie ? 43200 : 30; //43200 = 1 month
                var ticket = new FormsAuthenticationTicket(Username, createPersistentCookie, timeout);
                string encrypted = FormsAuthentication.Encrypt(ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                cookie.Expires = System.DateTime.Now.AddMinutes(timeout);
                System.Web.HttpContext.Current.Response.Cookies.Add(cookie);
            }
            else
            {
                FormsAuthentication.SetAuthCookie(Username, false);
            }
        }



    }
}