using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InitialWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        //Define an auto-implemented property for username
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public int? Age { get; set; }
        [BindProperty]
        public string? Stream { get; set; } = "GP";

        //Define an auto-implemented property for feedback message
        public string? InfoMessage { get; private set; }

        public void OnPost()
        {
            //generate a lucky number between 1 and 50 (inclusive)
            //and send a feedback message with format:
            //"Hello {username}. Your lucky number is {luckyNumber}"
            var random = new Random();
            int num = random.Next(1, 51);
            InfoMessage = $"Hello {Username}. Your lucky number is {num}. <br />";
            InfoMessage += ($"You are {Age} years old. <br />");
            InfoMessage += ($"You are in {Stream} stream. <br />");
        }

        public void OnGet()
        {

        }
    }
}