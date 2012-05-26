using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CalabashMedia.EmiEurope.Domain.Entities;

namespace CalabashMedia.EmiEurope.DataAccess.Interfaces
{
    public interface IVacancyRepository
    {
        IList<Vacancy> GetVacancies();
        bool CreateVacancy(Vacancy vacancy);
        Vacancy EditVacancy(int vacancyId);
        bool DeleteVacancy(int vacancyId);
        bool SaveVacancy(Vacancy vacancy);
        IList<Region> GetRegions();
        EmploymentType GetEmploymentTypes();
        IList<State> GetStates();
    }
}
