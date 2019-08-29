using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AkkaOrder.Pages
{
    public class HelloModel : PageModel
    {
        public string Username { get; set; }
        public void OnGet()
        {
            this.Username = "asdf";
        }

    }
}