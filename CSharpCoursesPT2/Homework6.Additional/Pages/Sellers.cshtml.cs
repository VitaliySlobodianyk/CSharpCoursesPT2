using Common.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Homework6.Additional.Pages
{
    public class SellersModel : PageModel
    {
        private AppDBContext _dbContext;
        public SellersRepository SellersRepository { get; set; }

        public SellersModel(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
        }

        public async Task OnGet()
        {
            SellersRepository = new SellersRepository(await _dbContext.Sellers.ToListAsync());
        }
    }
}
