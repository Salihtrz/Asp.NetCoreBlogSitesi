using BusinessLayer.ValidationRoles;
using DataAccess.Context;
using EFLayer.Class;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace IKBlok.Controllers
{
    
    [AllowAnonymous]
	public class LoginController : Controller
    {
		IKBlokContex iKBlokContex = new IKBlokContex();

        public async Task<IActionResult> Index()
        {
            HttpContext.Session.Remove("roleid");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(User user)
        {
            UsersValidationRoles uv = new UsersValidationRoles();
            ValidationResult result = uv.Validate(user);

            if (result.IsValid)
            {
                var varmi = iKBlokContex
                    .User
                    .Where(x => x.UserAdi == user.UserAdi & x.Password == user.Password)
                    .FirstOrDefault();
                if (varmi != null)
                {
                    HttpContext.Session.SetInt32("roleid",varmi.RoleId);
                    return RedirectToAction("Index", "Users");
                }
                ViewBag.EslesmeHatasi = true;
                return View();
            }
            else
            {
                foreach (var item in result.Errors)
                {

                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }
            return View(user);
        }
    }
}