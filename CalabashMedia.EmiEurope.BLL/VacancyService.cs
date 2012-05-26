using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CalabashMedia.EmiEurope.DataAccess;
using CalabashMedia.EmiEurope.Domain.Entities;

namespace CalabashMedia.EmiEurope.BLL
{
    public class VacancyService: IVacancyService
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

        public Vacancy EditVacancy(int vacancyId)
        {

            return _vacancyRepository.EditVacancy(vacancyId);
        }

        public bool SaveVacancy(Vacancy vacancy)
        {
            return _vacancyRepository.SaveVacancy(vacancy);
        }

        public bool DeleteVacancy(int vacancyId)
        {
            return _vacancyRepository.DeleteVacancy(vacancyId);
        }

        public bool CreateVacancy(Vacancy vacancy)
        {
            return _vacancyRepository.CreateVacancy(vacancy);
        }

        public IList<State> GetStates()
        {
            return _vacancyRepository.GetStates();
        }

        public IList<Region> GetRegions()
        {
            return _vacancyRepository.GetRegions();
        }
    }
}

