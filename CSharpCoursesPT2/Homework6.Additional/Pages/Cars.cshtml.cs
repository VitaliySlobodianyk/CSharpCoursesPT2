using Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Homework6.Additional.Pages
{
    public class CarsModel : PageModel
    {
        [BindProperty]
        public CarsRepository CarsRepository { get; set; }

        public CarsModel( CarsRepository carsRepository)
        {         
            CarsRepository = carsRepository;
        }

        public async Task OnGet()
        {
           await CarsRepository.DownloadData();
        }
    }
}
