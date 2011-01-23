using System;

namespace CStrahan.Combinators.Extensions
{
    public static class LambdaExtensions
    {
        public static Action Fix(this Func<Action, Action> functional)
        {
            return Lambda.Fix(functional);
        }

        public static Action<TArg1> Fix<TArg1>(this Func<Action<TArg1>, Action<TArg1>> functional)
        {
            return Lambda.Fix(functional);
        }

        public static Action<TArg1, TArg2> Fix<TArg1, TArg2>(this Func<Action<TArg1, TArg2>, Action<TArg1, TArg2>> functional)
        {
            return Lambda.Fix(functional);
        }

        public static Action<TArg1, TArg2, TArg3> Fix<TArg1, TArg2, TArg3>(this Func<Action<TArg1, TArg2, TArg3>, Action<TArg1, TArg2, TArg3>> functional)
        {
            return Lambda.Fix(functional);
        }

        public static Action<TArg1, TArg2, TArg3, TArg4> Fix<TArg1, TArg2, TArg3, TArg4>(this Func<Action<TArg1, TArg2, TArg3, TArg4>, Action<TArg1, TArg2, TArg3, TArg4>> functional)
        {
            return Lambda.Fix(functional);
        }

        public static Action<TArg1, TArg2, TArg3, TArg4, TArg5> Fix<TArg1, TArg2, TArg3, TArg4, TArg5>(this Func<Action<TArg1, TArg2, TArg3, TArg4, TArg5>, Action<TArg1, TArg2, TArg3, TArg4, TArg5>> functional)
        {
            return Lambda.Fix(functional);
        }



        public static Func<TReturn> Fix<TReturn>(this Func<Func<TReturn>, Func<TReturn>> functional)
        {
            return Lambda.Fix(functional);
        }

        public static Func<TArg1, TReturn> Fix<TArg1, TReturn>(this Func<Func<TArg1, TReturn>, Func<TArg1, TReturn>> functional)
        {
            return Lambda.Fix(functional);
        }

        public static Func<TArg1, TArg2, TReturn> Fix<TArg1, TArg2, TReturn>(this Func<Func<TArg1, TArg2, TReturn>, Func<TArg1, TArg2, TReturn>> functional)
        {
            return Lambda.Fix(functional);
        }

        public static Func<TArg1, TArg2, TArg3, TReturn> Fix<TArg1, TArg2, TArg3, TReturn>(this Func<Func<TArg1, TArg2, TArg3, TReturn>, Func<TArg1, TArg2, TArg3, TReturn>> functional)
        {
            return Lambda.Fix(functional);
        }

        public static Func<TArg1, TArg2, TArg3, TArg4, TReturn> Fix<TArg1, TArg2, TArg3, TArg4, TReturn>(this Func<Func<TArg1, TArg2, TArg3, TArg4, TReturn>, Func<TArg1, TArg2, TArg3, TArg4, TReturn>> functional)
        {
            return Lambda.Fix(functional);
        }

        public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TReturn> Fix<TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(this Func<Func<TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>> functional)
        {
            return Lambda.Fix(functional);
        }



        public static Func<Func<TArg1, TReturn>, Func<TArg1, TReturn>> Memoize<TArg1, TReturn>(this Func<Func<TArg1, TReturn>, Func<TArg1, TReturn>> functional)
        {
            return Lambda.Memoize(functional);
        }

        public static Func<Func<TArg1, TArg2, TReturn>, Func<TArg1, TArg2, TReturn>> Memoize<TArg1, TArg2, TReturn>(this Func<Func<TArg1, TArg2, TReturn>, Func<TArg1, TArg2, TReturn>> functional)
        {
            return Lambda.Memoize(functional);
        }

        public static Func<Func<TArg1, TArg2, TArg3, TReturn>, Func<TArg1, TArg2, TArg3, TReturn>> Memoize<TArg1, TArg2, TArg3, TReturn>(this Func<Func<TArg1, TArg2, TArg3, TReturn>, Func<TArg1, TArg2, TArg3, TReturn>> functional)
        {
            return Lambda.Memoize(functional);
        }

        public static Func<Func<TArg1, TArg2, TArg3, TArg4, TReturn>, Func<TArg1, TArg2, TArg3, TArg4, TReturn>> Memoize<TArg1, TArg2, TArg3, TArg4, TReturn>(this Func<Func<TArg1, TArg2, TArg3, TArg4, TReturn>, Func<TArg1, TArg2, TArg3, TArg4, TReturn>> functional)
        {
            return Lambda.Memoize(functional);
        }

        public static Func<Func<TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>> Memoize<TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(this Func<Func<TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>> functional)
        {
            return Lambda.Memoize(functional);
        }
    }
}