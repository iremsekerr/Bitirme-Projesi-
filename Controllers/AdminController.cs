using bitirmeSonProje.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            ViewBag.kisiler = liste.Kisis.Select(k => new SelectListItem()
            {
                Value = k.Id.ToString(),
                Text = k.Adi + " " + k.Soyadi
            }).ToList();
            return View(aka);
        }
        [HttpGet]
        public IActionResult DuyuruEkle(int? Id)
        {
            ViewBag.Kisiler = liste.Kisis.Select(k => new SelectListItem()
            {
                Value = k.Id.ToString(),
                Text = k.Adi + " " + k.Soyadi
            }).ToList();
            var days = new List<SelectListItem>();
            days.Add(new SelectListItem() { Value = "Pazatesi", Text = "Pazartesi" });
            days.Add(new SelectListItem() { Value = "Salı", Text = "Salı" });
            days.Add(new SelectListItem() { Value = "Çarşamba", Text = "Çarşamba" });
            days.Add(new SelectListItem() { Value = "Perşembe", Text = "Perşembe" });
            days.Add(new SelectListItem() { Value = "Cuma", Text = "Cuma" });
            days.Add(new SelectListItem() { Value = "Cumartesi", Text = "Cumartesi" });
            days.Add(new SelectListItem() { Value = "Pazar", Text = "Pazar" });
            ViewBag.Days = days;
            if (Id is null)
            {
                return View();
            }
            else
                return View(liste.Duyurus.FirstOrDefault(k => k.Id == Id));

        }
        [HttpPost]
        public IActionResult DuyuruEkle(IFormFile ResimYolu, [FromServices] IHostingEnvironment oHostingEnvironment, Duyuru a)
        {

            if (ResimYolu != null)
            {
                fileName = $"{oHostingEnvironment.WebRootPath}/Image{ResimYolu.FileName}";
                using (FileStream fileStream = System.IO.File.Create(fileName))
                {
                    ResimYolu.CopyTo(fileStream);
                    fileStream.Flush();
                    int ilk = fileName.IndexOf("/");
                    a.ResimYolu = fileName.Substring(ilk);
                }
            }

            liste.Duyurus.Update(a);
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

        public IActionResult DuyuruGuncelle(int id)
        {




            return RedirectToAction("DuyuruList");
        }

        public IActionResult OfisSaatiList()
        {
            ViewBag.Kisiler = liste.Kisis.Select(k => new SelectListItem()
            {
                Value = k.Id.ToString(),
                Text = k.Adi + " " + k.Soyadi
            }).ToList();
            var aka = liste.OfisSaatis.ToList();
            return View(aka);
        }
        [HttpGet]
        public IActionResult OfisSaatiEkle(int? Id)
        {
            ViewBag.Kisiler = liste.Kisis.Select(k => new SelectListItem()
            {
                Value = k.Id.ToString(),
                Text = k.Adi + " " + k.Soyadi
            }).ToList();
            var days = new List<SelectListItem>();
            days.Add(new SelectListItem() { Value = "Pazatesi", Text = "Pazartesi" });
            days.Add(new SelectListItem() { Value = "Salı", Text = "Salı" });
            days.Add(new SelectListItem() { Value = "Çarşamba", Text = "Çarşamba" });
            days.Add(new SelectListItem() { Value = "Perşembe", Text = "Perşembe" });
            days.Add(new SelectListItem() { Value = "Cuma", Text = "Cuma" });
            days.Add(new SelectListItem() { Value = "Cumartesi", Text = "Cumartesi" });
            days.Add(new SelectListItem() { Value = "Pazar", Text = "Pazar" });
            ViewBag.Days = days;
            if (Id is null)
            {
                return View();
            }
            else
                return View(liste.OfisSaatis.FirstOrDefault(k => k.Id == Id));
        }
        [HttpPost]
        public IActionResult OfisSaatiEkle(OfisSaati os)
        {
            liste.OfisSaatis.Update(os);
            liste.SaveChanges();
            return RedirectToAction("OfisSaatiList");
        }
        public IActionResult OfisSaatiSil(int Id)
        { 
            var ofisSaati = liste.OfisSaatis.FirstOrDefault(k=>k.Id==Id);
            liste.OfisSaatis.Remove(ofisSaati);
            liste.SaveChanges();
            return RedirectToAction("OfisSaatiList");
        }
        public IActionResult DersProgramiList()
        {
            var aka = liste.DersProgramis.ToList();
            return View(aka);
        }
        [HttpGet]
        public IActionResult DersProgramiEkle(int? Id)
        {
            ViewBag.Kisiler = liste.Kisis.Select(k => new SelectListItem()
            {
                Value = k.Id.ToString(),
                Text = k.Adi + " " + k.Soyadi
            }).ToList();

            var days = new List<SelectListItem>();
            days.Add(new SelectListItem() { Value = "Pazatesi", Text = "Pazartesi" });
            days.Add(new SelectListItem() { Value = "Salı", Text = "Salı" });
            days.Add(new SelectListItem() { Value = "Çarşamba", Text = "Çarşamba" });
            days.Add(new SelectListItem() { Value = "Perşembe", Text = "Perşembe" });
            days.Add(new SelectListItem() { Value = "Cuma", Text = "Cuma" });
            days.Add(new SelectListItem() { Value = "Cumartesi", Text = "Cumartesi" });
            days.Add(new SelectListItem() { Value = "Pazar", Text = "Pazar" });
            ViewBag.Days = days;
            if (Id is null)
            {
                return View();
            }
            else
                return View(liste.DersProgramis.FirstOrDefault(k=>k.Id==Id));
        }
        [HttpPost]
        public IActionResult DersProgramiEkle(DersProgrami os)
        {
            liste.DersProgramis.Update(os);
            liste.SaveChanges();
            return RedirectToAction("DersProgramiList");
        }
        public IActionResult DersProgramiSil(int Id)
        {
            var DersProgramis = liste.DersProgramis.FirstOrDefault(k => k.Id == Id);
            liste.DersProgramis.Remove(DersProgramis);
            liste.SaveChanges();
            return RedirectToAction("DersProgramiList");
        }
    }
}
