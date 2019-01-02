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
    public class MultipleController : Controller
    {
        const string userAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:47.0) Gecko/20100101 Firefox/47.0";

        // GET: Multiple
        public ActionResult Index()
        {
            List<Activity> activityList = new List<Activity>();

            for (int i = 0; i < 5; i++)
            {
                activityList.Add(GetActivity());
            }           

            return View(activityList);
        }
        
        public Activity GetActivity()
        {
            HttpWebRequest request = WebRequest.CreateHttp($"http://www.boredapi.com/api/activity/");
            request.UserAgent = userAgent;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                StreamReader data = new StreamReader(response.GetResponseStream());
                //do stuff with the data here - make JObject

                string JsonData = data.ReadToEnd();
                JObject activity = JObject.Parse(JsonData);

                return activity.ToObject<Activity>();
                
            }

            else
            {
                return null;
            }

        }


    }
}