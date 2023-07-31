using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Homework4.Pages
{
    public class AboutMeModel : PageModel
    {
        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Profession { get; private set; }

        public double Experience { get; private set; }

        public void OnGet()
        {
            Name = "Vitalii";
            Age = 23;
            Profession = "QA Engineer";
            Experience = 4;

        }
    }
}
