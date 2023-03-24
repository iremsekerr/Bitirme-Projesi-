using bitirmeSonProje.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeSon.Controllers
{
    public class AnaSayfaController : Controller
    {
        dbContext dbContext = new dbContext();
        public IActionResult AnaSayfa()
        
        {
            var siteAyarlari = dbContext.SiteAyarlars.FirstOrDefault();
            var kisiler = dbContext.Kisis.Where(x => x.Id == siteAyarlari.SecilenKisiId).ToList();
            ViewBag.kisiler = kisiler;
            ViewBag.duyurular = dbContext.Duyurus.Where(x => x.KisiId == kisiler.FirstOrDefault().Id).ToList();
           

            return View();

        }

        public IActionResult Getir(int id)
        {

            var modal = dbContext.Duyurus.Where(x => x.Id == id).ToList();

            ViewBag.modal = modal;
            return View(modal);

        }

    }
}
