using BusinessLayer.Managment;
using DataAccess.Context;
using DataAccessLayer.EntittyFramework;
using EFLayer.Class;
using IKBlok.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IKBlok.Controllers
{
    public class HomeController : Controller
    {
        KategoryManagment kt = new KategoryManagment(new EfKategoryRepo());
        IKBlokContex _context = new IKBlokContex();
        GonderiManagement gm = new GonderiManagement(new EfGonderiRepo());
        public IActionResult Index()
        {
            TempData["kategoriler"]=kt.getAllList();
            return View(gm.getAllListWithKategori());
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}