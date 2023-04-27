using System.ComponentModel.DataAnnotations;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Pages;

public class AdoptModel : PageModel
{
    private readonly ILogger<AdoptModel> _logger;

    public List<Pet> adoptPets = default!;

    private ProjectContext listContext;

    [BindProperty]
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = "";

    // 1st step, create a place to store a selected pet
    // grabbing an empty pet object from the model
    [BindProperty]
    public Pet Pet { get; set; } = default!;

    // 2nd step, create a place to store a list of pets
    // That the user can choose from
    // SelectList is used to represent a list of items with a value and text that goes into the option
    public SelectList? SelectItems { get; set; }

    // 
    public async Task<IActionResult> OnGetAsync()
    {
        // part of 4th step, loading pets from petsContext, putting into list
        adoptPets = await listContext.Pets.ToListAsync();
        // 3rd Step
        // Populate list of choices, 2nd and 3rd arguments are value (PetId), and the Text representation (Name)
        SelectItems = new SelectList(adoptPets, nameof(Pet.PetId), nameof(Pet.Name));
        return Page();
    }

    [BindProperty]
    [Required]
    [MinLength(10), MaxLength(1000)]
    public string Message { get; set; } = "";

    // [BindProperty]
    // public AdoptPetFormModel AdoptForm { get; set; } = default!;

    public AdoptModel(ILogger<AdoptModel> logger, ProjectContext context)
    {
        listContext = context; // added this step 3
        _logger = logger;
    }

    public bool FormSubmitted { get; set; } = false;





    // for when form is submitted, using HTTPPost as in the form method=post
    //This runs instead of on Get because of the form method 
    public async Task<IActionResult> OnPostAsync()
    {
        // part of 4th step, loading pets from petsContext, putting into list
        // not necessary right now
        // adoptPets = await listContext.Pets.ToListAsync();

        // After form is submitted (Step 5),
        // PetId is populated by the select, and only finds PetIds higher than 0
        // Can also check if model is valid here
        // similar code in other pet pages that deal with db
        if (Pet.PetId > 0)
        {
            FormSubmitted = true; // form is submitted
            var pet = await listContext.Pets.FindAsync(Pet.PetId); //Finding pet for given ID
            if (pet == null) //check to see if pet exists
            {
                return BadRequest(); // doesn't exist :(
            }
            // if we wanted to insert this stuff into the DB,
            // it would be done here
            // Make adoption request Model, use SaveChanges, etc,
        }
        return Page();
    }
}