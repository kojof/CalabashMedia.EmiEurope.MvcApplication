using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CalabashMedia.EmiEurope.BLL;
using CalabashMedia.EmiEurope.Domain.Entities;

namespace CalabashMedia.EmiEurope.MvcApplication.Helpers
{
    public class StateHelper
    {
        private static VacancyService _vacancyService;
           
        public static SelectList GetStates()
        {
            _vacancyService = new VacancyService();
            List<State> states = _vacancyService.GetStates().ToList();
            var selectListItems = new SelectList(states, "Id", "Name");
            return selectListItems;
        }
    }
}
