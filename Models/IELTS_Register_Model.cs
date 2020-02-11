using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentralRestWS.Models
{
    public class IELTS_Register_Model
    {
        public string username { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string email_address { get; set; }
        public string contact_number { get; set; }
        public int is_admin { get; set; }
    }

    public class IELTS_Register_Model_Container
    {
        public IELTS_Register_Model RegisterModel { get; set; }
    }
}