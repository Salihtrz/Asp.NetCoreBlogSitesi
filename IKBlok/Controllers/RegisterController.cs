using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Context;
using EFLayer.Class;
using FluentValidation.Results;
using BusinessLayer.Managment;
using BusinessLayer.ValidationRoles;
using DataAccessLayer.EntittyFramework;
using Microsoft.CodeAnalysis.Scripting;
using DataAccessLayer.Repostory;

namespace IKBlok.Controllers
{
    public class RegisterController : Controller
    {
        DataUserRepostory db = new DataUserRepostory();
        UserManagment um = new UserManagment(new EfUserRepo());

        public async Task<IActionResult> Index(User user)
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user)
        {
            RegisterValidationRoles us = new RegisterValidationRoles();
            ValidationResult result = us.Validate(user);
            if (result.IsValid)
            {
                db.add(user);
                ViewBag.KayitBasarili = true;
                return View();
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(user);
            }
        }
    }
}