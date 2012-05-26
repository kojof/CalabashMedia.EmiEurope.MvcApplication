using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web;
using DataAnnotationsExtensions;

namespace CalabashMedia.EmiEurope.Domain.Entities
{
    public class QuickRegisterEmail
    {
        public string Title { get; set; }
       
        public string FirstName { get; set; }
       
         public string LastName { get; set; }
       
       public string Telephone { get; set; }

        public string Profession { get; set; }
       
        public string EmailAddress { get; set; }
      
     
        public HttpPostedFileBase Attachment { get; set; }        
    }
}
