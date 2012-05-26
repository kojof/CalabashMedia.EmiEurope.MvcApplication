using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CalabashMedia.EmiEurope.Domain.Entities;

namespace CalabashMedia.EmiEurope.MvcApplication.Models
{
    public class VacancyViewModel 
    {
        public IList<Vacancy> Vacancies { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public IEnumerable<SelectListItem> EmploymentTypes { get; set; }
        public IEnumerable<SelectListItem> States { get; set; }
        public IEnumerable<SelectListItem> Regions { get; set; }
        public Vacancy Vacancy { get; set; }

    }
}
