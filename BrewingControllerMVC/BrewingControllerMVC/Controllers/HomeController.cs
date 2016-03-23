using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace BrewingControllerMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult AssignProbes()
        {
            ViewBag.Message = "Assign Probes Here";

            return View();
        }

        public ActionResult Contact()
        {
            
            ViewBag.TheMessage = "Having trouble?  Send us a message.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(string message)
        {
            // TODO : Send message to HQ 
            String[] strArray = GetTempProbeNames();
            int arrayLength = strArray.Length;
            string strReturn = "";
            for (int i = 0; i < arrayLength; i++)
            {
                strReturn = strReturn + strArray[i].ToString();
                if (!(i == arrayLength - 1))
                {
                    strReturn = strReturn + ", ";
                }
            }


            //ViewBag.TheMessage = "Thanks, we got your message!";
            ViewBag.TheMessage = strReturn;
            return View();

        }

        public static String[] GetTempProbeNames()
        {
            string folderLocation = "/sys/bus/w1/devices/w1_bus_master1";
            string[] dir = Directory.GetDirectories(folderLocation, "28-0*");
            int indexNum = 0;
            foreach (string str in dir)
            {
                int i = str.IndexOf("28-0");
                string newStr = str.Substring(i, 15);
                dir[indexNum] = newStr;
                indexNum++;
            }

            return dir;
        }
    }
}