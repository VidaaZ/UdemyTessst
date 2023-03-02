using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UdemyWeb.Data;
using UdemyWeb.Model;

namespace UdemyWeb.Pages.Admin.Categories
{
    public class EditModel : PageModel
    {

        private readonly ApplicationDbContext _db;
       

        public Category Category { get; set; }
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
      

       
        public void OnGet(int id)
        {
            Category = _db.Category.Find(id);
        }
        public async Task<IActionResult> OnPost() //IActionResult is used because I want to return to page or redirect to a view
        {
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "The DisplayOrder cannot exactly match the Name");
            }
            if (ModelState.IsValid)
            {
                _db.Category.Update(Category);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
