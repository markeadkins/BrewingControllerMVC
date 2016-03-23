using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrewingControllerMVC.Models
{
    public class TempProbe
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public PIDNames AssignedPID { get; set; }  
        public int CurrentTemp { get; set; }

    }
}