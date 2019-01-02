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
    public class SpecificController : Controller
    {
        const string userAgent = "Mozilla / 5.0(Windows NT 6.1; Win64; x64; rv: 47.0) Gecko / 20100101 Firefox / 47.0";

        // GET: Specific
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowActivity(string type)
        {
            HttpWebRequest request = WebRequest.CreateHttp("https://www.boredapi.com/api/activity?type=" + type);
            request.UserAgent = userAgent;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                StreamReader data = new StreamReader(response.GetResponseStream());
                string JsonData = data.ReadToEnd();
                JObject dataObject = JObject.Parse("{activity:" + JsonData + "}");
                ViewBag.Activity = dataObject["activity"];
            }

            return View();
        }
    }
}