using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CalabashMedia.EmiEurope.DataAccess;
using CalabashMedia.EmiEurope.Domain.Entities;

namespace CalabashMedia.EmiEurope.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class VacancyService : IVacancyService
    {
        private VacancyRepository _vacancyRepository;

        public VacancyService()
        {
            _vacancyRepository = new VacancyRepository();
        }

        public IList<Vacancy> GetVacancies()
        {

            return _vacancyRepository.GetVacancies();
        }


        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
