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
    public class AdminKategorilerController : Controller
    {
		IKBlokContex _context = new IKBlokContex();
		KategoryManagment kt = new KategoryManagment(new EfKategoryRepo());


		public async Task<IActionResult> Index()
        {
              return View(kt.getAllList());
        }

    
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Kategories kategories)
        {
            if (ModelState.IsValid)
            {
                kt.add(kategories);
                return RedirectToAction(nameof(Index));
            }
            return View(kategories);
        }

	
		public async Task<IActionResult> Edit(int id)
		{

			return View(kt.getCategoryById(id));
		}


		[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("kategoriId,kategoryName")] Kategories kategories)
        {

			if (ModelState.IsValid)
			{
				kt.update(kategories);
				return RedirectToAction(nameof(Index));
			}
			return View(kategories);
			

        }

        public async Task<IActionResult> Delete(int id)
        {

			return View(kt.getCategoryById(id));
			
		
		}

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int kategoriId)
        {
            var kategorigetir = _context.Kategories.Where(x => x.kategoriId == kategoriId).Include(i => i.Gonderiler).FirstOrDefault();
            _context.RemoveRange(kategorigetir.Gonderiler);
            _context.Remove(kategorigetir);
            _context.SaveChanges();
            //kt.remove(kategories);
				return RedirectToAction(nameof(Index));
						
		}

    }
}
