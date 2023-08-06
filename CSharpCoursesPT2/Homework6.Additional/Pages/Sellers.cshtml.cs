using Common;
using Common.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Homework6.Additional.Pages
{
    public class SellersModel : PageModel
    {
        public SellersRepository SellersRepository { get; set; }

        public SellersModel(AppDBContext appDBContext, SellersRepository sellersRepository)
        {
            SellersRepository = sellersRepository;
        }

        public async Task OnGet()
        {
            await SellersRepository.DownloadData();
        }
    }
}
