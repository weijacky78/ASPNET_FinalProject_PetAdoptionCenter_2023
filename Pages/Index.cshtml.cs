using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    // place to put list of pets
    //1st step, need a list to store shit in
    public List<Pet> slideshowPets = default!;

    // 2nd step, need a reference to the database / EF framework
    private ProjectContext petsContext;

    // 3rd step, in constructor setting ProjectContext to petsContext, petsContext is now dbContext
    public IndexModel(ILogger<IndexModel> logger, ProjectContext context)
    {
        petsContext = context; // added this step 3
        _logger = logger;
    }

    // 4th step, run some code when get OnGet request happens (upon page load)
    public async Task<IActionResult> OnGetAsync()
    {
        // part of 4th step, loading pets from petsContext, putting into list
        slideshowPets = await petsContext.Pets.ToListAsync();

        return Page();
    }
}
