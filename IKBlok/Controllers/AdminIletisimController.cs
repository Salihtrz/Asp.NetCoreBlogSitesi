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
	public class AdminIletisimController : Controller
	{

		IletisimManagment il = new IletisimManagment(new EfIletisimRepo());
		public async Task<IActionResult> Index()
		{
			return View(il.getAllList());
		}


		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("IletisimId,Mail,Telefon,Adres")] Iletisim iletisim)
		{
			if (ModelState.IsValid)
			{
				il.add(iletisim);
				return RedirectToAction(nameof(Index));
			}
			return View(iletisim);
		}



		public async Task<IActionResult> Edit(int id)
		{

			return View(il.getCategoryById(id));
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("IletisimId,Mail,Telefon,Adres")] Iletisim iletisim)
		{
            if (ModelState.IsValid)
            {
                il.update(iletisim);
                return RedirectToAction(nameof(Index));
            }

            return View(iletisim);
		}



		public async Task<IActionResult> Delete(int? id)
		{
			
			return View();
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			
			return View();
		}


	}
}




















//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using DataAccess.Context;
//using EFLayer.Class;
//using BusinessLayer.Managment;
//using DataAccessLayer.EntittyFramework;

//namespace IKBlok.Controllers
//{

//	public class AdminIletisimController : Controller
//	{

//		IletisimManagment il = new IletisimManagment(new EfIletisimRepo());
//		// GET: AdminIletisim
//		public async Task<IActionResult> Index()
//		{
//			return View(il.getAllList());
//		}

//		public IActionResult Create()
//		{
//			return View();
//		}

	
//		[HttpPost]
//		[ValidateAntiForgeryToken]
//		public async Task<IActionResult> Create([Bind("IletisimId,Mail,Telefon,Adres")] Iletisim iletisim)
//		{
//			if (ModelState.IsValid)
//			{
//				il.add(iletisim);
//				return RedirectToAction(nameof(Index));
//			}
//			return View(iletisim);
//		}

//			// GET: AdminIletisim/Edit/5


//			public async Task<IActionResult> Edit(int id)
//		    {

//			return View();
//		    }

		
//		[HttpPost]
//		[ValidateAntiForgeryToken]
//		public async Task<IActionResult> Edit(int id, [Bind("IletisimId,Mail,Telefon,Adres")] Iletisim iletisim)
//		{

//			if (ModelState.IsValid)
//			{
//				il.update(iletisim);
//				return RedirectToAction(nameof(Index));
//			}
//			return View(iletisim);
//	     }


		// GET: AdminIletisim/Delete/5
		//public async Task<IActionResult> Delete(int? id)
		//{
			
		//	return View();
		//}

		// POST: AdminIletisim/Delete/5
		//[HttpPost, ActionName("Delete")]
		//[ValidateAntiForgeryToken]
		//public async Task<IActionResult> DeleteConfirmed(int id)
		//{
		
		//	return View();
		//}

	
//	}
//}
