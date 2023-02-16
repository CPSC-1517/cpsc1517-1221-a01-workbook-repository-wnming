using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesDemo.Models;

namespace RazorPagesDemo.Pages
{
    public class SimpleCalculatorModel : PageModel
    {
        [BindProperty]
        public Calculator CurrentCalculator { get; set; }
        [BindProperty]
        public string? InfoMessage { get; private set; }
        [BindProperty]
        public string? ErrorMessage { get; private set; }

        public void OnPostAdd()
        {
            InfoMessage = $"{CurrentCalculator.Number1} + {CurrentCalculator.Number2} = {CurrentCalculator.Add()}";
        }
        public void OnPostSubtract()
        {
            InfoMessage = $"{CurrentCalculator.Number1} - {CurrentCalculator.Number2} = {CurrentCalculator.Subtract()}";
        }
        public void OnPostMultiply()
        {
            InfoMessage = $"{CurrentCalculator.Number1} * {CurrentCalculator.Number2} = {CurrentCalculator.Multiply()}";
        }
        public void OnPostDivide()
        {
            try
            {
                InfoMessage = $"{CurrentCalculator.Number1} / {CurrentCalculator.Number2} = {CurrentCalculator.Divide()}";
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
        public void OnGet()
        {

        }
    }
}
