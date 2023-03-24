using bitirmeSonProje.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace bitirmeSonProje.Controllers
{
    public class AdminController : Controller
    {
        dbContext liste = new dbContext();
       
        string fileName;
        public IActionResult DuyuruList()
        {
            var aka = liste.Duyurus.ToList();
            var tur = liste.DuyuruTurus.ToList();

            return View(aka);
        }
        [HttpGet]
        public IActionResult DuyuruEkle()
        {

            return View();

        }
        [HttpPost]
        public IActionResult DuyuruEkle(IFormFile ResimYolu, [FromServices] IHostingEnvironment oHostingEnvironment, Duyuru a)
        {

            fileName = $"{oHostingEnvironment.WebRootPath}/Image{ResimYolu.FileName}";
            using (FileStream fileStream = System.IO.File.Create(fileName))
            {
                ResimYolu.CopyTo(fileStream);
                fileStream.Flush();
                int ilk = fileName.IndexOf("/");
                a.ResimYolu = fileName.Substring(ilk);
            }
            liste.Duyurus.Add(a);
            liste.SaveChanges();
            return RedirectToAction("DuyuruList");
        }
        public IActionResult DuyuruSil(int id)
        {
            var duyuru = liste.Duyurus.Find(id);
            liste.Duyurus.Remove(duyuru);
            liste.SaveChanges();
            return RedirectToAction("DuyuruList");
        }
        public  IActionResult DuyuruGuncelle(int id) {




            return RedirectToAction("DuyuruList");
        }
    }
}
