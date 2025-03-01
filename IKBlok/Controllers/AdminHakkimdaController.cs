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
	public class AdminHakkimdaController : Controller
	{

		HakkimdaManagment hk = new HakkimdaManagment(new EfHakkimdaRepo());

		public async Task<IActionResult> Index()
		{
			return View(hk.getAllList());
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
				hk.add(hakkimda);
				return RedirectToAction(nameof(Index));
			}
			return View(hakkimda);
		}

		
		public async Task<IActionResult> Edit(int id)
		{

			return View(hk.getCategoryById(id));
		}

		


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("hakkimdaId,baslik,icerik,resimLinki")] Hakkimda hakkimda)
		{
			if (ModelState.IsValid)
			{
				hk.update(hakkimda);
				return RedirectToAction(nameof(Index));
			}
			return View(hakkimda);

			
		}

		

	}
}

