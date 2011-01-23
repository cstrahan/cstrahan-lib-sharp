using System;
using System.Collections.Generic;

namespace CStrahan.Combinators
{
    public class Lambda
    {
        public static Action Fix(Func<Action, Action> functional)
        {
            return functional(() => Fix(functional));
        }

        public static Action<T1> Fix<T1>(Func<Action<T1>, Action<T1>> functional)
        {
            return functional(arg1 => Fix(functional)(arg1));
        }

        public static Action<T1, T2> Fix<T1, T2>(Func<Action<T1, T2>, Action<T1, T2>> functional)
        {
            return functional((arg1, arg2) => Fix(functional)(arg1, arg2));
        }

        public static Action<T1, T2, T3> Fix<T1, T2, T3>(Func<Action<T1, T2, T3>, Action<T1, T2, T3>> functional)
        {
            return functional((arg1, arg2, arg3) => Fix(functional)(arg1, arg2, arg3));
        }

        public static Action<T1, T2, T3, T4> Fix<T1, T2, T3, T4>(Func<Action<T1, T2, T3, T4>, Action<T1, T2, T3, T4>> functional)
        {
            return functional((arg1, arg2, arg3, arg4) => Fix(functional)(arg1, arg2, arg3, arg4));
        }

        public static Action<T1, T2, T3, T4, T5> Fix<T1, T2, T3, T4, T5>(Func<Action<T1, T2, T3, T4, T5>, Action<T1, T2, T3, T4, T5>> functional)
        {
            return functional((arg1, arg2, arg3, arg4, arg5) => Fix(functional)(arg1, arg2, arg3, arg4, arg5));
        }



        public static Func<TReturn> Fix<TReturn>(Func<Func<TReturn>, Func<TReturn>> functional)
        {
            return functional(() => Fix(functional)());
        }

        public static Func<T1, TReturn> Fix<T1, TReturn>(Func<Func<T1, TReturn>, Func<T1, TReturn>> functional)
        {
            return functional(arg1 => Fix(functional)(arg1));
        }

        public static Func<T1, T2, TReturn> Fix<T1, T2, TReturn>(Func<Func<T1, T2, TReturn>, Func<T1, T2, TReturn>> functional)
        {
            return functional((arg1, arg2) => Fix(functional)(arg1, arg2));
        }

        public static Func<T1, T2, T3, TReturn> Fix<T1, T2, T3, TReturn>(Func<Func<T1, T2, T3, TReturn>, Func<T1, T2, T3, TReturn>> functional)
        {
            return functional((arg1, arg2, arg3) => Fix(functional)(arg1, arg2, arg3));
        }

        public static Func<T1, T2, T3, T4, TReturn> Fix<T1, T2, T3, T4, TReturn>(Func<Func<T1, T2, T3, T4, TReturn>, Func<T1, T2, T3, T4, TReturn>> functional)
        {
            return functional((arg1, arg2, arg3, arg4) => Fix(functional)(arg1, arg2, arg3, arg4));
        }

        public static Func<T1, T2, T3, T4, T5, TReturn> Fix<T1, T2, T3, T4, T5, TReturn>(Func<Func<T1, T2, T3, T4, T5, TReturn>, Func<T1, T2, T3, T4, T5, TReturn>> functional)
        {
            return functional((arg1, arg2, arg3, arg4, arg5) => Fix(functional)(arg1, arg2, arg3, arg4, arg5));
        }



        public static Func<Func<T1, TReturn>, Func<T1, TReturn>> Memoize<T1, TReturn>(Func<Func<T1, TReturn>, Func<T1, TReturn>> functional)
        {
            var cache = new Dictionary<T1, TReturn>();
            Func<Func<T1, TReturn>, Func<T1, TReturn>> wrapper =
                f => arg1 =>
                {
                    TReturn result;
                    if (!cache.TryGetValue(arg1, out result))
                    {
                        result = cache[arg1] = functional(f)(arg1);
                    }

                    return result;
                };
            return wrapper;
        }

        public static Func<Func<T1, T2, TReturn>, Func<T1, T2, TReturn>> Memoize<T1, T2, TReturn>(Func<Func<T1, T2, TReturn>, Func<T1, T2, TReturn>> functional)
        {
            var cache = new Dictionary<Tuple<T1, T2>, TReturn>();
            Func<Func<T1, T2, TReturn>, Func<T1, T2, TReturn>> wrapper =
                f => (arg1, arg2) =>
                {
                    var key = Tuple.Create(arg1, arg2);
                    TReturn result;
                    if (!cache.TryGetValue(key, out result))
                    {
                        result = cache[key] = functional(f)(arg1, arg2);
                    }

                    return result;
                };
            return wrapper;
        }

        public static Func<Func<T1, T2, T3, TReturn>, Func<T1, T2, T3, TReturn>> Memoize<T1, T2, T3, TReturn>(Func<Func<T1, T2, T3, TReturn>, Func<T1, T2, T3, TReturn>> functional)
        {
            var cache = new Dictionary<Tuple<T1, T2, T3>, TReturn>();
            Func<Func<T1, T2, T3, TReturn>, Func<T1, T2, T3, TReturn>> wrapper =
                f => (arg1, arg2, arg3) =>
                {
                    var key = Tuple.Create(arg1, arg2, arg3);
                    TReturn result;
                    if (!cache.TryGetValue(key, out result))
                    {
                        result = cache[key] = functional(f)(arg1, arg2, arg3);
                    }

                    return result;
                };
            return wrapper;
        }

        public static Func<Func<T1, T2, T3, T4, TReturn>, Func<T1, T2, T3, T4, TReturn>> Memoize<T1, T2, T3, T4, TReturn>(Func<Func<T1, T2, T3, T4, TReturn>, Func<T1, T2, T3, T4, TReturn>> functional)
        {
            var cache = new Dictionary<Tuple<T1, T2, T3, T4>, TReturn>();
            Func<Func<T1, T2, T3, T4, TReturn>, Func<T1, T2, T3, T4, TReturn>> wrapper =
                f => (arg1, arg2, arg3, arg4) =>
                {
                    var key = Tuple.Create(arg1, arg2, arg3, arg4);
                    TReturn result;
                    if (!cache.TryGetValue(key, out result))
                    {
                        result = cache[key] = functional(f)(arg1, arg2, arg3, arg4);
                    }

                    return result;
                };
            return wrapper;
        }

        public static Func<Func<T1, T2, T3, T4, T5, TReturn>, Func<T1, T2, T3, T4, T5, TReturn>> Memoize<T1, T2, T3, T4, T5, TReturn>(Func<Func<T1, T2, T3, T4, T5, TReturn>, Func<T1, T2, T3, T4, T5, TReturn>> functional)
        {
            var cache = new Dictionary<Tuple<T1, T2, T3, T4, T5>, TReturn>();
            Func<Func<T1, T2, T3, T4, T5, TReturn>, Func<T1, T2, T3, T4, T5, TReturn>> wrapper =
                f => (arg1, arg2, arg3, arg4, arg5) =>
                {
                    var key = Tuple.Create(arg1, arg2, arg3, arg4, arg5);
                    TReturn result;
                    if (!cache.TryGetValue(key, out result))
                    {
                        result = cache[key] = functional(f)(arg1, arg2, arg3, arg4, arg5);
                    }

                    return result;
                };
            return wrapper;
        }



        public static void U(SelfApplicable r)
        {
            r(r);
        }

        public static TReturn U<TReturn>(SelfApplicable<TReturn> r)
        {
            return r(r);
        }



        public static Func<Action, Action> Functional(Func<Action, Action> functional)
        {
            return functional;
        }

        public static Func<Action<T1>, Action<T1>> Functional<T1>(Func<Action<T1>, Action<T1>> functional)
        {
            return functional;
        }

        public static Func<Action<T1, T2>, Action<T1, T2>> Functional<T1, T2>(Func<Action<T1, T2>, Action<T1, T2>> functional)
        {
            return functional;
        }

        public static Func<Action<T1, T2, T3>, Action<T1, T2, T3>> Functional<T1, T2, T3>(Func<Action<T1, T2, T3>, Action<T1, T2, T3>> functional)
        {
            return functional;
        }

        public static Func<Action<T1, T2, T3, T4>, Action<T1, T2, T3, T4>> Functional<T1, T2, T3, T4>(Func<Action<T1, T2, T3, T4>, Action<T1, T2, T3, T4>> functional)
        {
            return functional;
        }

        public static Func<Action<T1, T2, T3, T4, T5>, Action<T1, T2, T3, T4, T5>> Functional<T1, T2, T3, T4, T5>(Func<Action<T1, T2, T3, T4, T5>, Action<T1, T2, T3, T4, T5>> functional)
        {
            return functional;
        }



        public static Func<Func<TReturn>, Func<TReturn>> Functional<TReturn>(Func<Func<TReturn>, Func<TReturn>> functional)
        {
            return functional;
        }

        public static Func<Func<T1, TReturn>, Func<T1, TReturn>> Functional<T1, TReturn>(Func<Func<T1, TReturn>, Func<T1, TReturn>> functional)
        {
            return functional;
        }

        public static Func<Func<T1, T2, TReturn>, Func<T1, T2, TReturn>> Functional<T1, T2, TReturn>(Func<Func<T1, T2, TReturn>, Func<T1, T2, TReturn>> functional)
        {
            return functional;
        }

        public static Func<Func<T1, T2, T3, TReturn>, Func<T1, T2, T3, TReturn>> Functional<T1, T2, T3, TReturn>(Func<Func<T1, T2, T3, TReturn>, Func<T1, T2, T3, TReturn>> functional)
        {
            return functional;
        }

        public static Func<Func<T1, T2, T3, T4, TReturn>, Func<T1, T2, T3, T4, TReturn>> Functional<T1, T2, T3, T4, TReturn>(Func<Func<T1, T2, T3, T4, TReturn>, Func<T1, T2, T3, T4, TReturn>> functional)
        {
            return functional;
        }

        public static Func<Func<T1, T2, T3, T4, T5, TReturn>, Func<T1, T2, T3, T4, T5, TReturn>> Functional<T1, T2, T3, T4, T5, TReturn>(Func<Func<T1, T2, T3, T4, T5, TReturn>, Func<T1, T2, T3, T4, T5, TReturn>> functional)
        {
            return functional;
        }



        public static Action Action(Action action)
        {
            return action;
        }

        public static Action<T1> Action<T1>(Action<T1> action)
        {
            return action;
        }

        public static Action<T1, T2> Action<T1, T2>(Action<T1, T2> action)
        {
            return action;
        }

        public static Action<T1, T2, T3> Action<T1, T2, T3>(Action<T1, T2, T3> action)
        {
            return action;
        }

        public static Action<T1, T2, T3, T4> Action<T1, T2, T3, T4>(Action<T1, T2, T3, T4> action)
        {
            return action;
        }

        public static Action<T1, T2, T3, T4, T5> Action<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> action)
        {
            return action;
        }



        public static Func<TReturn> Func<TReturn>(Func<TReturn> func)
        {
            return func;
        }

        public static Func<T1, TReturn> Func<T1, TReturn>(Func<T1, TReturn> func)
        {
            return func;
        }

        public static Func<T1, T2, TReturn> Func<T1, T2, TReturn>(Func<T1, T2, TReturn> func)
        {
            return func;
        }

        public static Func<T1, T2, T3, TReturn> Func<T1, T2, T3, TReturn>(Func<T1, T2, T3, TReturn> func)
        {
            return func;
        }

        public static Func<T1, T2, T3, T4, TReturn> Func<T1, T2, T3, T4, TReturn>(Func<T1, T2, T3, T4, TReturn> func)
        {
            return func;
        }

        public static Func<T1, T2, T3, T4, T5, TReturn> Func<T1, T2, T3, T4, T5, TReturn>(Func<T1, T2, T3, T4, T5, TReturn> func)
        {
            return func;
        }
    }
}