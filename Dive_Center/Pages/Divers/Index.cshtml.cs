using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dive_Center.Data;
using Dive_Center.Models;

namespace Dive_Center.Pages.Divers
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Diver> Divers { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Divers = await _context.Divers.ToListAsync();
        }
    }
}
