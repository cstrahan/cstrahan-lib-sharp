using System;
using System.Linq;
using CStrahan;
using CStrahan.Combinators;
using CStrahan.Combinators.Extensions;
using System.Numerics;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {

            //var fib = Lambda.Functional<BigInteger, BigInteger>(fibo => n => n < 2 ? n : fibo(n - 1) + fibo(n - 2));

            var fib = Lambda.Functional<BigInteger, BigInteger>(fibo => n => n < 2 ? n : fibo(n - 1) + fibo(n - 2))
                            .Trace()
                            .Memoize()
                            .Fix();


            //var range = Enumerable.Range(0, 2000);

            //Console.WriteLine("With memoization:");
            //foreach (var n in range)
            //{
            //    Console.WriteLine("fib({0}) = {1}", n, fib(n));
            //}

            Console.WriteLine("fib({0}) = {1}", 8, fib(8));

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
