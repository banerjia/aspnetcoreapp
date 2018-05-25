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
    public class IndexModel : PageModel
    {
        private readonly BloggingContext _db;

        public IndexModel(BloggingContext db)
        {
            _db = db;
        }
        
        [BindProperty]
        public IList<Blog> Blogs { get; private set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Blogs = await _db.Blogs.AsNoTracking().ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(Guid id)
        {
            var blogToDelete = _db.Blogs.Find(id);

            if (blogToDelete != null)
            {
                _db.Blogs.Remove(blogToDelete);
                await _db.SaveChangesAsync();
            }

            return RedirectToPage();
             
        }
    }
}