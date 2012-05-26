using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace CalabashMedia.EmiEurope.Domain.Entities
{
    public class Vacancy
    {
      [Required]
      public int VacancyId {get;set;}

      [DisplayName("Vacancy Title")]
      [Required]
      public string VacancyTitle { get; set; }

      [DisplayName("Vacancy Details")]
      [Required]
      public string VacancyDetails { get; set; }

      //[Required]
      public string Location { get; set; }

      [Required]
      public string Duration {get;set;}

      [Required]
      public string Salary {get;set;}

      [Required]
      public string StartDate {get;set;}


      [Required]
      [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
      public string Contact {get;set;}
        
    // [Required]
      public int? EmploymentTypeId {get;set;}
   
      public DateTime? DatePosted { get; set; }

      public int? RegionId {get;set;}

     [Required]
      public int StateId{get;set;}

      public Region Region { get; set; }

      public State State { get; set; }

      public EmploymentType EmploymentType { get; set; }
    }
}
