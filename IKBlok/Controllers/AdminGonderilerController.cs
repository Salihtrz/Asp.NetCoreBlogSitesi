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

namespace IKBlok.Controllers
{

	[Yetki]
    public class AdminGonderilerController : Controller
    {

        GonderiManagement gn = new GonderiManagement(new EfGonderiRepo());
        KategoryManagment kt = new KategoryManagment(new EfKategoryRepo());

    
        public async Task<IActionResult> Index()
        {
            return View(gn.getAllList());
        }


		public async Task<IActionResult> Edit(int id)
		{
            ViewData["kategoriId"] = new SelectList(kt.getAllList(), "kategoriId", "kategoryName");
            return View(gn.getCategoryById(id));


        }

  
        public async Task<IActionResult> Details(int? id)
        {
            

            return View();
        }

     
        public IActionResult Create()
        {
            DateTime mevcutTarih = gn.GetMevcutTarih();
            ViewData["MevcutTarih"] = mevcutTarih;
            ViewData["kategoriId"] = new SelectList(kt.getAllList(), "kategoriId", "kategoryName");

            return View();
        }


       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Gonderiler gonderiler)
        {
            if (ModelState.IsValid)
            {
                gn.add(gonderiler);

                return RedirectToAction(nameof(Index));

            }
            return View(gonderiler);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("GonderiId,GonderiName,GonderiBaslik,GonderiIcerik,GonderiResim,kategoriId")] Gonderiler gonderiler)
        {
            if (ModelState.IsValid)
            {
                gn.update(gonderiler);
                return RedirectToAction(nameof(Index));
            }
            return View(gonderiler);


        }

     
        public async Task<IActionResult> Delete(int id)
        {
            return View(gn.getCategoryById(id));
       
        

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
       
        public async Task<IActionResult> DeleteConfirmed(Gonderiler gonderiler)
        {

            gn.remove(gonderiler);
            return RedirectToAction(nameof(Index));
        }


    }
}
