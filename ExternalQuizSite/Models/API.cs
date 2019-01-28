using ExternalQuizSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExternalQuizSite {


    /**********************************************************************     Quiz Model

     **********************************************************************/

    public class API {

        public string PrivateKey { get; set; }
        public string PrivatePassword { get; set; }
        public string ReturnURL { get; set; }
        public string StudentID { get; set; }


    }
}