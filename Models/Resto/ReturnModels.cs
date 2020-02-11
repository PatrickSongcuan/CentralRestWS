using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentralRestWS.Models.Resto
{
    
    public class Special
    {
        public string item_name { get; set; }
        public string item_description { get; set; }
        public byte[] item_image { get; set; }
        public bool is_available { get; set; }
        public bool is_new { get; set; }
        public bool is_special { get; set; }
        public string date_created { get; set; }
    }
}