using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BoredWebApp.Models;

namespace BoredWebApp.Controllers
{
    public class OneController : Controller
    {


        const string userAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:47.0) Gecko/20100101 Firefox/47.0";

        public  ActionResult Index()
        {
            HttpWebRequest request = WebRequest.CreateHttp("https://www.boredapi.com/api/Activity");

            request.UserAgent = userAgent;


            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //model insert
            Activity NewActivity = new Activity();


            if (response.StatusCode == HttpStatusCode.OK)
            {

                StreamReader data = new StreamReader(response.GetResponseStream());

                string JsonData = data.ReadToEnd();

                JObject dataObject = JObject.Parse(JsonData);

                ViewBag.Activity = dataObject.ToObject<Activity>();

                
                return View();
            }
            else
            {
                return null;
            }

        }
        
    }
}