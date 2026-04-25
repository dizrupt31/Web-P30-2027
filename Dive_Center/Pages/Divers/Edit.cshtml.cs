using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dive_Center.Data;
using Dive_Center.Models;

namespace Dive_Center.Pages.Divers
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Diver Diver { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            var diver = await _context.Divers.FirstOrDefaultAsync(m => m.Id == id);
            if (diver == null)
                return NotFound();

            Diver = diver;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Attach(Diver).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiverExists(Diver.Id))
                    return NotFound();
                else
                    throw;
            }

            return RedirectToPage("./Index");
        }

        private bool DiverExists(int id)
        {
            return _context.Divers.Any(e => e.Id == id);
        }
    }
}