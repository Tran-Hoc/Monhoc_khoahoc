using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Monhoc_khoahoc.DataContext;
using Monhoc_khoahoc.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Monhoc_khoahoc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HocphanContext _context;

        public HomeController(ILogger<HomeController> logger, HocphanContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.KhoaHocs.ToListAsync());

        }
        [HttpPost, ActionName("Details")]
        public JsonResult Details(int id)
        {
            if (_context.KhoaHocs == null)
            {
                //return Problem("Entity set 'WebBanHangContext.TbCategories'  is null.");
                return Json(new { success = false });
            }
           
            var monhoc = _context.MonHocs.Where(o=>o.Idkhoahoc == id).ToList();
            if (monhoc != null)
            {
               var  data = JsonConvert.SerializeObject(monhoc);
                return Json( new { success = true, data });
            }
            return Json(new { success = false });
          

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