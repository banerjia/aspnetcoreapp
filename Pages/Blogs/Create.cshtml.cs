using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using aspnetcoreapp.Models;

namespace aspnetcoreapp.Pages.Blogs
{
    public class CreateModel : PageModel
    {
        private readonly BloggingContext _db;

        public CreateModel(BloggingContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Blog Blog { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            _db.Blogs.Add(Blog);
            await _db.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}