using Microsoft.AspNetCore.Mvc;

namespace RazorPagesDemo.Models
{
    public class Calculator
    {
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public int Add() => Number1 + Number2;
        public int Subtract() => Number1 - Number2;
        public int Multiply() => Number1 * Number2;
        public double Divide() => Number1 / Number2;
    }
}
