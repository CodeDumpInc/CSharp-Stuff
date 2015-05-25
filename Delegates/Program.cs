using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class Program
    {
        public delegate void Calculation(List<int> numbers);

        static void square(List<int> numbers)
        {
            Func<int, int> sqr = p => p * p;

            for( int i=0; i < numbers.Count; ++i )
            {
                numbers[i] = sqr(numbers[i]);
            }
        }

        static void twice(List<int> numbers)
        {
            Func<int, int> twice = p => p * 2;

            for (int i = 0; i < numbers.Count; ++i)
            {
                numbers[i] = twice(numbers[i]);
            }
        }

        static void Main(string[] args)
        {
            //The following example would be better handled with ConvertAll...
            List<int> numbers = Enumerable.Range(0, 10).ToList();

            Calculation c = null;

            c += Program.square;
            c += Program.twice;

            c(numbers);

            numbers.ForEach(x => Console.WriteLine(x));

            Console.WriteLine();

            //... as seen here:
            numbers = numbers.ConvertAll(x => x + 10);
            numbers.ForEach(x => Console.WriteLine(x));
        }
    }
}
