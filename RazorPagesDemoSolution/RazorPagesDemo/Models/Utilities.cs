using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorPagesDemo.Models
{
    public class Utilities
    {
        static public bool IsPositiveOrZero(int value)
        {
            return value >= 0;
        }
    }
}