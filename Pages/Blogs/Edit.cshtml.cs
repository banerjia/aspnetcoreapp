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
    public class EditModel : PageModel
    {
        private readonly BloggingContext _db;

        public EditModel(BloggingContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Blog Blog { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            Blog = await _db.Blogs.FindAsync(id);

            if (Blog == null)
                RedirectToPage("./Index");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            _db.Attach(Blog).State = EntityState.Modified;

            try
            {
                _db.Blogs.Update(Blog);
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception($"Blog {Blog.Id} not found");
            }

            return RedirectToPage("./Index");
        }
    }
}