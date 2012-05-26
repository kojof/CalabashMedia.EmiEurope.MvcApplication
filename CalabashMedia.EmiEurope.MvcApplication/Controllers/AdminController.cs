using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using CalabashMedia.EmiEurope.BLL;
using CalabashMedia.EmiEurope.Domain.Entities;
using CalabashMedia.EmiEurope.MvcApplication.Helpers;
using CalabashMedia.EmiEurope.MvcApplication.Models;

namespace CalabashMedia.EmiEurope.MvcApplication.Controllers
{
    public class AdminController : Controller
    {
        private IVacancyService vacancyService;
        private int PageSize = 2;

        public AdminController()
        {
            vacancyService = new VacancyService();
        }


        //
        // GET: /Account/LogOn

        public ActionResult LogOn()
        {
            return View();
        }

        //
        // POST: /Account/LogOn

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/LogOff

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/Register

        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                MembershipCreateStatus createStatus;
                Membership.CreateUser(model.UserName, model.Password, model.Email, null, null, true, null, out createStatus);

                if (createStatus == MembershipCreateStatus.Success)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false /* createPersistentCookie */);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", ErrorCodeToString(createStatus));
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ChangePassword

        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Account/ChangePassword

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {

                // ChangePassword will throw an exception rather
                // than return false in certain failure scenarios.
                bool changePasswordSucceeded;
                try
                {
                    MembershipUser currentUser = Membership.GetUser(User.Identity.Name, true /* userIsOnline */);
                    changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword);
                }
                catch (Exception)
                {
                    changePasswordSucceeded = false;
                }

                if (changePasswordSucceeded)
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ChangePasswordSuccess

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }


        public ViewResult VacancyIndex(int page = 1)
        {
            int totalItems = 0;
            List<Vacancy> vacancyList = new List<Vacancy>();
            vacancyList = vacancyService.GetVacancies().ToList();
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

        
        [HttpPost]
        public ActionResult Create(VacancyViewModel vacancyViewModel)
        {
            vacancyViewModel.Vacancy.DatePosted = DateTime.Now;
           
            if (ModelState.IsValid)
            {
                bool bReturn = vacancyService.CreateVacancy(vacancyViewModel.Vacancy);
                return RedirectToAction("VacancyIndex");
            }
       //     vacancyViewModel.EmploymentTypes = EmploymentTypeHelper.GetEmploymentTypes();
            vacancyViewModel.States = StateHelper.GetStates();
            vacancyViewModel.Regions = RegionHelper.GetRegions();
            return View("Create", vacancyViewModel);
        }

         [HttpGet]
        public ActionResult Create()
         {
             VacancyViewModel vacancyViewModel = new VacancyViewModel();
            // vacancyViewModel.EmploymentTypes =  EmploymentTypeHelper.GetEmploymentTypes();
             vacancyViewModel.States = StateHelper.GetStates();
             vacancyViewModel.Regions = RegionHelper.GetRegions();
             return View(vacancyViewModel);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            Vacancy vacancy = vacancyService.EditVacancy(id);
            VacancyViewModel vacancyViewModel = new VacancyViewModel();
          //  vacancyViewModel.EmploymentTypes = EmploymentTypeHelper.GetEmploymentTypes();
            vacancyViewModel.States = StateHelper.GetStates();
            vacancyViewModel.Regions = RegionHelper.GetRegions();
            vacancyViewModel.Vacancy = vacancy;
            return View(vacancyViewModel);
        }
    

        [HttpPost]
        public ActionResult Edit(VacancyViewModel vacancyViewModel)
        {
           if (ModelState.IsValid)
            {

                bool bReturn = vacancyService.SaveVacancy(vacancyViewModel.Vacancy);
                return RedirectToAction("VacancyIndex");
            }
            vacancyViewModel.States = StateHelper.GetStates();
            vacancyViewModel.Regions = RegionHelper.GetRegions();
            return View(vacancyViewModel);
        }
         
        [HttpPost]
        public ActionResult Delete(int id)
        {

            if (ModelState.IsValid)
            {
                bool bReturn = vacancyService.DeleteVacancy(id);
                return RedirectToAction("VacancyIndex");
            }
            return View();
        }

       

        #region Status Codes
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion
    }
}
