using System;
using System.Linq;
using CStrahan;
using CStrahan.Combinators;
using CStrahan.Combinators.Extensions;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var fibFunctional = Lambda.Functional<long, long>(fibo => n => n < 2 ? n : fibo(n - 1) + fibo(n - 2));
            var fib = fibFunctional.Fix();
            var fibMemo = fibFunctional.Memoize().Fix();

            var range = Enumerable.Range(0, 50);

            Console.WriteLine("With memoization:");
            foreach (var n in range)
            {
                Console.WriteLine("fib({0}) = {1}", n, fibMemo(n));
            }

            //Console.WriteLine("Without memoization:");
            //foreach (var n in range)
            //{
            //    Console.WriteLine("fib({0}) = {1}", n, fib(n));
            //}

            
            Console.WriteLine(".......");
            Console.ReadKey(true);
        }
    }
}
