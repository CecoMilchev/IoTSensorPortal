using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IoTSensorPortal.Controllers
{
    public class SensorDataFetchController : Controller
    {
        public ActionResult Run()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://telerikacademy.icb.bg/api/sensor/f1796a28-642e-401f-8129-fd7465417061");
            request.Headers.Add("auth-token", "8e4c46fe-5e1d-4382-b7fc-19541f7bf3b0");
            var response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string strResponse = reader.ReadToEnd();
            ViewBag.Message = strResponse;
            return this.View();
        }
    }
}