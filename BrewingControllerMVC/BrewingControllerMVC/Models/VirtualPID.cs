using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrewingControllerMVC.Models
{
    public class VirtualPID
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string AssignedTempProbe { get; set; }
        public string AssignedSSR { get; set; }
        public PIDNames PIDName { get; set; }


    }

        public enum PIDNames {Boil, Mash, HLT_RIMs};

    
}