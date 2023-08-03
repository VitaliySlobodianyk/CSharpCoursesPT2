using Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Homework6.Additional.Pages
{
    public class CarsModel : PageModel
    {
        private AppDBContext _dbContext;
        [BindProperty]
        public CarsRepository CarsRepository { get; set; }

        public CarsModel(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
        }

        public async Task OnGet()
        {
            CarsRepository = new CarsRepository(await _dbContext.Cars.ToListAsync());
        }
    }
}
