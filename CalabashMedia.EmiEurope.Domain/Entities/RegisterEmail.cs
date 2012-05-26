using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web;
using DataAnnotationsExtensions;

namespace CalabashMedia.EmiEurope.Domain.Entities
{
    public class RegisterEmail
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string FirstName { get; set; }

         [Required]
         public string LastName { get; set; }
       
        public string Company { get; set; }

        public string Position { get; set; }

        public string Telephone { get; set; }

        public string Mobile { get; set; }

        public string Profession { get; set; }

        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        [Required]
        public string EmailAddress { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string TownCity { get; set; }

        public string County { get; set; }
        
        public string State { get; set; }

        public string PostCode { get; set; }

        public string Country { get; set; }

        public string DesiredPosition { get; set; }

        public string DesiredLocation { get; set; }

        public string Comments { get; set; }

         [FileExtensions("doc|docx")]
        public HttpPostedFileBase Attachment { get; set; }        
    }
}
