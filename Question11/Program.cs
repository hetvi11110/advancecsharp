using System;
using System.Threading.Tasks;

namespace Question11
{
    public class Program
    {
        public Func<int> GenerateNumber = () =>
        {
            Random number = new Random();
            return number.Next(1, 10001);
        };

        public string PrintNumber(int numGenerate)
        {
            int number = GenerateNumber();
            return $"The generated number is: {number}";
        }

        public static void Main()
        {
            Program program = new Program();

            Task task = Task.Factory.StartNew(program.GenerateNumber)
                .ContinueWith(taskResult =>
                {
                    string result = program.PrintNumber(taskResult.Result);
                    Console.WriteLine(result);
                });

            task.Wait();
        }
    }
}
