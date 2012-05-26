using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CalabashMedia.EmiEurope.Domain.Entities;

namespace CalabashMedia.EmiEurope.MvcApplication.Helpers
{
    public class EmploymentTypeHelper
    {

        public static SelectList GetEmploymentTypes()
        {
            List<EmploymentType> employmentTypes = new List<EmploymentType>();
            EmploymentType EmploymentType1 = new EmploymentType
                                                 {
                                                     Id = 1,
                                                     Name = "Permanent"
                                                 };
            EmploymentType EmploymentType2 = new EmploymentType
                                                {
                                                    Id = 2,
                                                    Name = "Contract"
                                                };
            employmentTypes.Add(EmploymentType1);
             employmentTypes.Add(EmploymentType2);

            var selectListItems = new SelectList(employmentTypes, "Id", "Name");
            return selectListItems;

        }

    }
}
