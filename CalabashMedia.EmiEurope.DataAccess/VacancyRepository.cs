#region ..Usings
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CalabashMedia.EmiEurope.DataAccess.Interfaces;
using CalabashMedia.EmiEurope.Domain.Entities;
using System.Data.Entity;
#endregion

namespace CalabashMedia.EmiEurope.DataAccess
{
    public class VacancyRepository : IVacancyRepository
    {
        #region Private Variables
        private VacancyContext vacancyContext;
        #endregion

        #region Constructor
        public VacancyRepository()
        {
            vacancyContext = new VacancyContext();
        }
        #endregion

        #region Public Methods
        public IList<Vacancy> GetVacancies()
        {
            var vacancies = vacancyContext.Vacancy
                    .Include(p => p.Region)
                    .Include(p => p.EmploymentType)
                    .Include(p => p.State)
                    .ToList();
            return vacancies;
        }

        public Vacancy EditVacancy(int vacancyId)
        {
            var vacancy = vacancyContext.Vacancy.Find(vacancyId);
            return vacancy;
        }

        public bool SaveVacancy(Vacancy vacancy)
        {
            vacancyContext.Entry(vacancy).State = EntityState.Modified;
           
            vacancyContext.SaveChanges();
            Vacancy savedVacancy = vacancyContext.Vacancy.Find(vacancy.VacancyId);

            if(savedVacancy.VacancyId > 0)
            {
                return true;
            }
            return false;
        }

        public bool CreateVacancy(Vacancy vacancy)
        {
          
            vacancyContext.Vacancy.Add(vacancy);
            vacancyContext.SaveChanges();
            Vacancy savedVacancy = vacancyContext.Vacancy.Find(vacancy.VacancyId);

            if (savedVacancy.VacancyId > 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteVacancy(int vacancyId)
        {
            Vacancy vacancy = vacancyContext.Vacancy.Find(vacancyId);
            vacancyContext.Vacancy.Remove(vacancy);
            vacancyContext.SaveChanges();

            Vacancy deletedVacancy = vacancyContext.Vacancy.Find(vacancy.VacancyId);

            if (deletedVacancy == null)
            {
                return true;
            }
            return false;
        }

        public IList<Region> GetRegions()
        {
            var regions = (from p in vacancyContext.Region
                           where p.Status == false
                           select p).ToList();
            return regions;
        }

        public IList<State> GetStates()
        {
            var states = vacancyContext.State
                .ToList();
            return states;
        }

        public EmploymentType GetEmploymentTypes()
        {
            throw new NotImplementedException();
        }
        #endregion

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (vacancyContext != null)
                {
                    vacancyContext.Dispose();
                    vacancyContext = null;
                }
            }
        }
    }
}
