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
        public static int Id = 0;
        [HttpGet]
        public IActionResult AnaSayfa(int? id)
        {
            
            var kisiler = dbContext.Kisis.ToList();
            var dtos = new SliderDto();
            ViewBag.kisiler = kisiler;
            var siteAyarlari = dbContext.SiteAyarlars.FirstOrDefault();
            
            if(id!=null)
            {
                Id = (int)id;
            }
            ViewBag.Ids = Id;
            var dd = new List<SliderDto>();
            foreach(var item in kisiler)
            {
                dtos = new SliderDto()
                {
                    KisiId = item.Id,
                    Image = dbContext.Kisis.FirstOrDefault(k => k.Id == item.Id).ResimYolu,
                    Duyurular = dbContext.Duyurus.Where(k => k.KisiId == item.Id).ToList(),
                    DersProgramlari = dbContext.DersProgramis.Where(k => k.KisiId == item.Id).ToList(),
                    OfisSaatleri = dbContext.OfisSaatis.Where(k => k.KisiId == item.Id).ToList()
                };
                dd.Add(dtos);
            }
           
            ViewBag.dtos = dd;
            return View(dd);

        }

        //public IActionResult Getir(int id)
        //{
        //    var modal = dbContext.Duyurus.Where(x => x.KisiId == id).ToList();
        //    return Json(modal);

        //}

    }
}
