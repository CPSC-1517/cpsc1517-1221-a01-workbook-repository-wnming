using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesDemo.Models;

namespace RazorPagesDemo.Pages
{
    public class LottoQuickPicksModel : PageModel
    {
        [BindProperty]
        public string? Name { get; set; }

        [BindProperty]
        public LottoType? Type { get; set; } = LottoType.Lotto649;

        [BindProperty]
        public int QuickPicks { get; set; } = 3;

        public List<int[]> QuickPicksNumbers { get; private set; } = new();

        public string? InfoMessage { get; private set; }
        public string? ErrorMessage { get; private set; }

        public void OnGet()
        {
        }

        public void OnPostGenerateNumbers()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                ErrorMessage = "Name is required and cannot be blank.";
            }
            else
            {
                //Remove any previous QuickPicksNumbers
                QuickPicksNumbers.Clear();
                //random
                Random random = new();
                //create a new array of int for each quick pick
                for(int quickCount = 1; quickCount <= QuickPicks; quickCount++)
                {
                    //generate 6 numbers bewteen 1 and 49 for Lotto649
                    if(Type == LottoType.Lotto649)
                    {
                        int[] currentLottoQuickPicks = new int[6];
                        for(int count = 1; count <= 6; count++)
                        {
                            currentLottoQuickPicks[count - 1] = random.Next(1, 50);
                        }
                        //sort the contents of the array
                        Array.Sort(currentLottoQuickPicks);
                        //Add the array of int to our list
                        QuickPicksNumbers.Add(currentLottoQuickPicks);
                    }
                    else
                    {
                        //generate 7 numbers bewteen 1 and 50 for LottoMax
                        if (Type == LottoType.LottoMax)
                        {

                        }
                    }
                }
                InfoMessage = $"Hello {Name}";
            }
        }

        public IActionResult OnPostClear()
        {
            Name = null;
            InfoMessage = null;
            ErrorMessage = null;  
            return RedirectToPage();
        }
    }
}
