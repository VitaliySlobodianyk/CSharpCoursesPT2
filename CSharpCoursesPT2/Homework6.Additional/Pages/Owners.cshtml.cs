using Common;
using Common.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Homework6.Additional.Pages
{
    public class OwnersModel : PageModel
    {
        public OwnersRepository OwnersRepository { get; set; }

        public OwnersModel( OwnersRepository ownersRepository)
        {
            OwnersRepository = ownersRepository;
        }

        public async Task OnGet()
        {
            await OwnersRepository.DownloadData();
        }
    }
}
