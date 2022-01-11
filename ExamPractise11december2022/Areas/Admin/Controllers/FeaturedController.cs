using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamPractise11december2022.DAL;
using ExamPractise11december2022.Models;
using ExamPractise11december2022.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ExamPractise11december2022.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeaturedController : Controller
    {
        public AppDbContext _context { get; }

        public FeaturedController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Featured> featured = await _context.Featureds.Where(p => p.Isdeleted == false).ToListAsync();
            return View(featured);
        }
        public async Task<IActionResult> Delete(int id)
        {
           var featured= await _context.Featureds.FindAsync(id);
           featured.Isdeleted = true;
           await  _context.SaveChangesAsync();
           return Redirect(nameof(Index));
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Featured featured)
        {
            var feature = new Featured
            {
                Title = featured.Title,
                Content = featured.Content,
                IconLink = featured.IconLink
            };
            await _context.Featureds.AddAsync(feature);
           await _context.SaveChangesAsync();

           return Redirect(nameof(Index));
        }
    }
}
