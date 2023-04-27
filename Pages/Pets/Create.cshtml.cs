using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FinalProject.Models;
using System.Security.Claims;

namespace FinalProject.Pages_Pets
{
    public class CreateModel : PageModel
    {
        private readonly FinalProject.Models.ProjectContext _context;

        private readonly ILogger<CreateModel> _logger;

        public CreateModel(ProjectContext context, ILogger<CreateModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                var id = (ClaimsIdentity)User.Identity; // get the claims identity of the user
                var email = id.FindFirst(ClaimTypes.Email)?.Value; // get the email claim

                _logger.LogInformation($"user with email {email} is on the create game page");
            }
            return Page();
        }

        [BindProperty]
        public Pet Pet { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                if (!ModelState.IsValid || _context.Pets == null || Pet == null)
                {
                    return Page();
                }

                _context.Pets.Add(Pet);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }
            else
            {
                return RedirectToPage("./Index");
            }
        }
    }
}


// add code to to use file instead of text