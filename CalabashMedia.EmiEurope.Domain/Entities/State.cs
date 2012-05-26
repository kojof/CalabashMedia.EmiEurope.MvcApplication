using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace CalabashMedia.EmiEurope.Domain.Entities
{
    public class State
    {
         [Column("StateName")]
        public string Name { get; set; }

         [Column("StateId")]
        public int Id { get; set; }

        public string StateCode { get; set; }
    }
}
