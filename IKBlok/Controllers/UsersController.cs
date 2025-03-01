using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Context;
using EFLayer.Class;
using BusinessLayer.Managment;
using DataAccessLayer.EntittyFramework;
using Microsoft.AspNetCore.Authorization;
using DataAccessLayer.Repostory;
using BusinessLayer.ValidationRoles;
using FluentValidation.Results;

namespace IKBlok.Controllers
{
	[Yetki]
	public class UsersController : Controller
    {
		DataUserRepostory db = new DataUserRepostory();
		UserManagment us = new UserManagment(new EfUserRepo());
		public async Task<IActionResult> Index()
        {
			return View(us.getAllList());
		}
       
        public IActionResult Create()
        {
			ViewData["RoleId"] = new SelectList(us.getAllList(), "RoleId","RoleId");
			return View();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user)
        {
			AdminUserValidationRoles admin = new AdminUserValidationRoles();
			ValidationResult result = admin.Validate(user);
			if (result.IsValid)
			{
				db.add(user);
				return RedirectToAction(nameof(Index));
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

        public async Task<IActionResult> Edit(int id)
        {
			return View(us.getCategoryById(id));
		}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(User user)
        {
            AdminUserValidationRoles admin = new AdminUserValidationRoles();
            ValidationResult result = admin.Validate(user);
            if (result.IsValid)
			{
				db.update(user);
				return RedirectToAction(nameof(Index));
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

        public async Task<IActionResult> Delete(int id)
        {
			return View(us.getCategoryById(id));
		}

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(User user)
        {
			us.remove(user);
			return RedirectToAction(nameof(Index));
		}
    }
}