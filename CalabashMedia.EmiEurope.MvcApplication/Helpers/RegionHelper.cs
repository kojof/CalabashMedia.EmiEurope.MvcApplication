using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CalabashMedia.EmiEurope.BLL;
using CalabashMedia.EmiEurope.Domain.Entities;

namespace CalabashMedia.EmiEurope.MvcApplication.Helpers
{
    public class RegionHelper
    {
        private static VacancyService _vacancyService;

        public static SelectList GetRegions()
        {
            _vacancyService = new VacancyService();
            List<Region> regions = _vacancyService.GetRegions().ToList();
            var selectListItems = new SelectList(regions, "Id", "Name");
            return selectListItems;
        }
    }
}
