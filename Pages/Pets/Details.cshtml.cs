using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;

namespace FinalProject.Pages_Pets
{
    public class DetailsModel : PageModel
    {
        private readonly FinalProject.Models.ProjectContext _context;

        public DetailsModel(FinalProject.Models.ProjectContext context)
        {
            _context = context;
        }

        public Pet Pet { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(uint? id)
        {
            if (id == null || _context.Pets == null)
            {
                return NotFound();
            }

            var pet = await _context.Pets.FirstOrDefaultAsync(m => m.PetId == id);
            if (pet == null)
            {
                return NotFound();
            }
            else
            {
                Pet = pet;
            }
            return Page();
        }
    }
}
