using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CalabashMedia.EmiEurope.Domain.Entities;
using CalabashMedia.EmiEurope.BLL;
using CalabashMedia.EmiEurope.MvcApplication.Models;
using CalabashMedia.EmiEurope.MvcApplication.VacancyServiceReference;
using IVacancyService = CalabashMedia.EmiEurope.BLL.IVacancyService;

namespace CalabashMedia.EmiEurope.MvcApplication.Controllers
{
    public class VacancyController : Controller
    {
        private IVacancyService vacancyService;
        private VacancyServiceReference.IVacancyService vacancyServiceReference;
        private int PageSize = 2;

        public VacancyController()
        {
            vacancyService = new VacancyService();
            vacancyServiceReference = new VacancyServiceClient();
        }

        //
        // GET: /Vacancy/

        public ViewResult Index(int page =1)
        {
            int totalItems = 0;
            List<Vacancy> vacancyList = new List<Vacancy>();
         //   vacancyList = vacancyService.GetVacancies().ToList();
            vacancyList = vacancyServiceReference.GetVacancies().ToList();
            totalItems = vacancyList.Count;
            VacancyViewModel vacancyViewModel = new VacancyViewModel();
            vacancyViewModel.Vacancies = new List<Vacancy>();                                       
            vacancyViewModel.Vacancies = (vacancyList
                                                     .OrderByDescending(v => v.VacancyId)
                                                     .Skip((page - 1) * PageSize)
                                                     .Take(PageSize).ToList());
            var pagingInfo = new PagingInfo
                                        {
                                            CurrentPage = page,
                                            ItemsPerPage = PageSize,
                                            TotalItems = totalItems
                                        };
            vacancyViewModel.PagingInfo = pagingInfo;                                       
                                                       
                                                    
     
            return View(vacancyViewModel);
        }

        //
        // GET: /Vacancy/Details/5

        //public ViewResult Details(int id)};
        //{
        //    Vacancy vacancy = db.Vacancies.Find(id);
        //    return View(vacancy);
        //}

        //
        // GET: /Vacancy/Create

      

       
    }
}