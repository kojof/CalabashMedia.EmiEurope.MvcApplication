using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CalabashMedia.EmiEurope.Domain.Entities;

namespace CalabashMedia.EmiEurope.BLL
{
    public interface IVacancyService
    {
        IList<Vacancy> GetVacancies();
        Vacancy EditVacancy(int vacancyId);
        bool SaveVacancy(Vacancy vacancy);
        bool DeleteVacancy(int vacancyId);
        bool CreateVacancy(Vacancy vacancy);
        IList<State> GetStates();
        IList<Region> GetRegions();
    }
}
