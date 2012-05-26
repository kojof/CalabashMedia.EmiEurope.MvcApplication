using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace CalabashMedia.EmiEurope.Domain.Entities
{
    public class EmploymentType
    {
     [Column("EmploymentTypeId")]
     public int Id { get; set; }
     
      [Column("EmploymentTypeName")]
      public string Name { get; set; }
    }
}
