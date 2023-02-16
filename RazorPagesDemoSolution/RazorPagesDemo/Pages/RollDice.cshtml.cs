using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesDemo.Pages
{
    public class RollDiceModel : PageModel
    {
        public void OnGet()
        {
            DiceFaceImage = "/img/icons/ffffff/000000/1x1/delapouite/dice-shield.png";
        }
        
        public int DiceFaceValue { get; private set; }
        public string DiceFaceImage { get; private set; }

        public string[] DiceImage =
        {
            "/img/icons/ffffff/000000/1x1/delapouite/dice-six-faces-one.png",
            "/img/icons/ffffff/000000/1x1/delapouite/dice-six-faces-two.png",
            "/img/icons/ffffff/000000/1x1/delapouite/dice-six-faces-three.png",
            "/img/icons/ffffff/000000/1x1/delapouite/dice-six-faces-four.png",
            "/img/icons/ffffff/000000/1x1/delapouite/dice-six-faces-five.png",
            "/img/icons/ffffff/000000/1x1/delapouite/dice-six-faces-six.png"
        };
        [BindProperty]
        public int BetAmount { get; set; }
        [BindProperty]
        public int SelectedDiceSide { get; set; }
        public string? InfoMessage { get; private set; }

        public void OnPost()
        {
            Random random = new Random();
            DiceFaceValue = random.Next(1, 7);
            DiceFaceImage = DiceImage[DiceFaceValue - 1];

            if (DiceFaceValue == SelectedDiceSide)
            {
                InfoMessage = $"Congrats, you won {BetAmount:c}";
            }
            else
            {
                InfoMessage = $"I am happy but you lost {BetAmount:c}";
            }
        }
    }
}
