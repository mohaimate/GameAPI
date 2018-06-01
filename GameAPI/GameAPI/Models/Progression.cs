using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameAPI.Models
{
    public class Progression
    {
        public int AccountID { get; set; }
        public int Level { get; set; }
        public int Currentcoin { get; set; }
        public int Alltimecoin { get; set; }
    }
}