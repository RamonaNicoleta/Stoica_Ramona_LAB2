using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Stoica_Ramona_Lab2.Data;
using Stoica_Ramona_Lab2.Models;

namespace Stoica_Ramona_Lab2.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly Stoica_Ramona_Lab2.Data.Stoica_Ramona_Lab2Context _context;

        public CreateModel(Stoica_Ramona_Lab2.Data.Stoica_Ramona_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID",
"PublisherName");
            ViewData["AuthorID"] = new SelectList(_context.Set<Author>(), "ID", "FirstName");

            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Book == null || Book == null)
            {
               
                return Page();
            }

            _context.Book.Add(Book);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
