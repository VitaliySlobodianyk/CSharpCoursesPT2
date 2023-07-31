using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Homework4.Pages
{
    public class MyHobbiesModel : PageModel
    {
        public IList<Hobby> Hobbies { get; set; }
        public void OnGet()
        {
            Hobbies = new List<Hobby>()
            {
                new Hobby("Cycling", 15){ Level = "Expert"},
                new Hobby("Programming", 2) { Level = "Medium"},
            };
        }
    }
}
