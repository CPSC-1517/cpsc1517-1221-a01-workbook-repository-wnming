using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesDemo.Models;

namespace RazorPagesDemo.Pages
{
    public class MultiplicationTableModel : PageModel
    {
        [BindProperty]
        public int DigitsVertically { get; set; } = 9;

        [BindProperty]
        public int DigitsHorizontally { get; set; } = 9;

        public TableType? TableTypeToGenerate { get; private set; }

        public void OnGet()
        {
        }

        public void OnPostMultiply()
        {
            TableTypeToGenerate = TableType.Multiplication;
        }

        public void OnPostAdd()
        {
            TableTypeToGenerate = TableType.Addition;
        }

        public void OnPostSubtract()
        {
            TableTypeToGenerate = TableType.Subtraction;
        }
    }
}
