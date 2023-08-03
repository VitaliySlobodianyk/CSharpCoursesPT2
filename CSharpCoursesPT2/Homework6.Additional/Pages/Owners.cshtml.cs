using Common;
using Common.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Homework6.Additional.Pages
{
    public class OwnersModel : PageModel
    {
        private AppDBContext _dbContext;
        
        public OwnersRepository OwnersRepository { get; set; }


        public OwnersModel(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
        }

        public async Task OnGet()
        {
            OwnersRepository = new OwnersRepository(await _dbContext.Owners.ToListAsync());
        }
    }
}
