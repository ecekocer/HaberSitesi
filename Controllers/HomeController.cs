using HaberSitesi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HaberSitesi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HaberSitesiContext _db;
        private readonly int _yas;

        public HomeController(ILogger<HomeController> logger, HaberSitesiContext context)
        {
            _db = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Giris()
        {
            return View();
        }

        public IActionResult HaberGetir()
        {
            List<Haber> haberler = _db.Habers.ToList();
            return View(haberler);
        }
        public IActionResult KategoriGetir() 
        {
            List<Kategori> Kategoriler = _db.Kategoris.ToList();
            return View(Kategoriler);
        }
        public IActionResult KullaniciGetir()
        {
            List<Kullanici> Kullanicilar = _db.Kullanicis.ToList();
            return View(Kullanicilar);
        }
        public IActionResult KullaniciTuruGetir()
        {
            List<KullaniciTuru> KullaniciTurleri = _db.KullaniciTurus.ToList();
            return View(KullaniciTurleri);
        }
        public IActionResult KullaniciTuruYetkiGetir() 
        {
            List<KullaniciTuruYetki> KullaniciYetkiTurleri = _db.KullaniciTuruYetkis.ToList();
            return View(KullaniciYetkiTurleri);
        }
        public IActionResult MenüGetir() 
        {
            List<Menu> Menu = _db.Menus.ToList();    
            return View(Menu);
        }
        public IActionResult MenuTuruGetir()
        {
            List<MenuTuru> MenuTurleri = _db.MenuTurus.ToList();
            return View(MenuTurleri);
        }
        public IActionResult YetkiGetir()
        {
            List<Yetki> Yetki = _db.Yetkis.ToList();
            return View(Yetki);
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
