using System;

namespace EventExample
{
    public class Calculation : EventArgs
    {
        public int Result { get; set; }
    }

    public class Calculator
    {
        public delegate void AdditionCompEventHandler(object sender, Calculation e);
        public event AdditionCompEventHandler Finished;

        public void Addition(int num1, int num2)
        {
            int result = num1 + num2;
            OnCompleted(result);
        }

        protected virtual void OnCompleted(int result)
        {
            Finished?.Invoke(this, new Calculation { Result = result });
        }
    }

    public class Program
    {
        public static void Main()
        {
            Calculator calculator = new Calculator();
            calculator.Finished += CalculationCompleted;
            calculator.Addition(2, 2);
        }

        private static void CalculationCompleted(object sender, Calculation e)
        {
            Console.WriteLine($"Sum: {e.Result}");
        }
    }
}