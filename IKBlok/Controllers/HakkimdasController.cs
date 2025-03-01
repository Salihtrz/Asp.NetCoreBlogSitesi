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

namespace IKBlok.Controllers
{
    public class HakkimdasController : Controller
    {
        IKBlokContex _context = new IKBlokContex();
		KategoryManagment kt = new KategoryManagment(new EfKategoryRepo());
		HakkimdaManagment hk = new HakkimdaManagment(new EfHakkimdaRepo());
        public async Task<IActionResult> Index()
        {
			TempData["kategoriler"] = kt.getAllList();
			return View(hk.getAllList().FirstOrDefault());

        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Hakkimdas == null)
            {
                return NotFound();
            }

            var hakkimda = await _context.Hakkimdas
                .FirstOrDefaultAsync(m => m.hakkimdaId == id);
            if (hakkimda == null)
            {
                return NotFound();
            }

            return View(hakkimda);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("hakkimdaId,baslik,icerik,resimLinki")] Hakkimda hakkimda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hakkimda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hakkimda);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Hakkimdas == null)
            {
                return NotFound();
            }

            var hakkimda = await _context.Hakkimdas.FindAsync(id);
            if (hakkimda == null)
            {
                return NotFound();
            }
            return View(hakkimda);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("hakkimdaId,baslik,icerik,resimLinki")] Hakkimda hakkimda)
        {
            if (id != hakkimda.hakkimdaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hakkimda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HakkimdaExists(hakkimda.hakkimdaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(hakkimda);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Hakkimdas == null)
            {
                return NotFound();
            }

            var hakkimda = await _context.Hakkimdas
                .FirstOrDefaultAsync(m => m.hakkimdaId == id);
            if (hakkimda == null)
            {
                return NotFound();
            }

            return View(hakkimda);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Hakkimdas == null)
            {
                return Problem("Entity set 'IKBlokContex.Hakkimdas'  is null.");
            }
            var hakkimda = await _context.Hakkimdas.FindAsync(id);
            if (hakkimda != null)
            {
                _context.Hakkimdas.Remove(hakkimda);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HakkimdaExists(int id)
        {
          return (_context.Hakkimdas?.Any(e => e.hakkimdaId == id)).GetValueOrDefault();
        }
    }
}
