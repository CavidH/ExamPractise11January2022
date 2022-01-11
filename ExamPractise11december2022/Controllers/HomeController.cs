using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamPractise11december2022.DAL;
using ExamPractise11december2022.Models;
using ExamPractise11december2022.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ExamPractise11december2022.Controllers
{
    public class HomeController : Controller
    {
        public AppDbContext _context { get; }

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Featured> featured= await _context.Featureds.Where(p=>p.Isdeleted==false).Take(4).ToListAsync();
            FeaturedHomeVM homeVm = new FeaturedHomeVM
            {
                FeaturedHomeVms = featured
            };

            return View(homeVm);
        }
    }
}
