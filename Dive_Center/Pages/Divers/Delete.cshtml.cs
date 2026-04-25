using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dive_Center.Data;
using Dive_Center.Models;

namespace Dive_Center.Pages.Divers
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public DeleteModel(ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
                return NotFound();

            var diver = await _context.Divers.FindAsync(id);
            if (diver != null)
            {
                _context.Divers.Remove(diver);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}