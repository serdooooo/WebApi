using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication2.Models;


namespace WebApplication2.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(string returnUrl = "/Home/Index")
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        // GET: User
        
        string Baseurl = "https://localhost:44318/";
        [HttpPost]
        public async Task<ActionResult> Login(string email, string password, string returnUrl)
        {
            List<User> UserInfo = new List<User>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/User");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    UserInfo = JsonConvert.DeserializeObject<List<User>>(EmpResponse);
                    foreach (var item in UserInfo)
                    {
                        if (item.Email==email && item.Password==password)
                        {
                            
                            if (returnUrl==null || returnUrl == "")
                            {
                                return Redirect("/Home/Index");
                            }
                            return Redirect(returnUrl);
                        }
                    }
                }
                return View();
            }
        }
    }
}