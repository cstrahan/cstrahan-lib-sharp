using System;

namespace CStrahan
{
    public class Lambda
    {
        public static Action Y(Func<Action, Action> f)
        {
            return U<Action>(r => () => f(U(r))());
        }

        public static Action<TArg1> Y<TArg1>(Func<Action<TArg1>, Action<TArg1>> f)
        {
            return U<Action<TArg1>>(r => arg1 => f(U(r))(arg1));
        }

        public static Action<TArg1, TArg2> Y<TArg1, TArg2>(Func<Action<TArg1, TArg2>, Action<TArg1, TArg2>> f)
        {
            return U<Action<TArg1, TArg2>>(r => (arg1, arg2) => f(U(r))(arg1, arg2));
        }

        public static Action<TArg1, TArg2, TArg3> Y<TArg1, TArg2, TArg3>(Func<Action<TArg1, TArg2, TArg3>, Action<TArg1, TArg2, TArg3>> f)
        {
            return U<Action<TArg1, TArg2, TArg3>>(r => (arg1, arg2, arg3) => f(U(r))(arg1, arg2, arg3));
        }

        public static Action<TArg1, TArg2, TArg3, TArg4> Y<TArg1, TArg2, TArg3, TArg4>(Func<Action<TArg1, TArg2, TArg3, TArg4>, Action<TArg1, TArg2, TArg3, TArg4>> f)
        {
            return U<Action<TArg1, TArg2, TArg3, TArg4>>(r => (arg1, arg2, arg3, arg4) => f(U(r))(arg1, arg2, arg3, arg4));
        }

        public static Action<TArg1, TArg2, TArg3, TArg4, TArg5> Y<TArg1, TArg2, TArg3, TArg4, TArg5>(Func<Action<TArg1, TArg2, TArg3, TArg4, TArg5>, Action<TArg1, TArg2, TArg3, TArg4, TArg5>> f)
        {
            return U<Action<TArg1, TArg2, TArg3, TArg4, TArg5>>(r => (arg1, arg2, arg3, arg4, arg5) => f(U(r))(arg1, arg2, arg3, arg4, arg5));
        }



        public static Func<TReturn> Y<TReturn>(Func<Func<TReturn>, Func<TReturn>> f)
        {
            return U<Func<TReturn>>(r => () => f(U(r))());
        }

        public static Func<TArg1, TReturn> Y<TArg1, TReturn>(Func<Func<TArg1, TReturn>, Func<TArg1, TReturn>> f)
        {
            return U<Func<TArg1, TReturn>>(r => arg1 => f(U(r))(arg1));
        }

        public static Func<TArg1, TArg2, TReturn> Y<TArg1, TArg2, TReturn>(Func<Func<TArg1, TArg2, TReturn>, Func<TArg1, TArg2, TReturn>> f)
        {
            return U<Func<TArg1, TArg2, TReturn>>(r => (arg1, arg2) => f(U(r))(arg1, arg2));
        }

        public static Func<TArg1, TArg2, TArg3, TReturn> Y<TArg1, TArg2, TArg3, TReturn>(Func<Func<TArg1, TArg2, TArg3, TReturn>, Func<TArg1, TArg2, TArg3, TReturn>> f)
        {
            return U<Func<TArg1, TArg2, TArg3, TReturn>>(r => (arg1, arg2, arg3) => f(U(r))(arg1, arg2, arg3));
        }

        public static Func<TArg1, TArg2, TArg3, TArg4, TReturn> Y<TArg1, TArg2, TArg3, TArg4, TReturn>(Func<Func<TArg1, TArg2, TArg3, TArg4, TReturn>, Func<TArg1, TArg2, TArg3, TArg4, TReturn>> f)
        {
            return U<Func<TArg1, TArg2, TArg3, TArg4, TReturn>>(r => (arg1, arg2, arg3, arg4) => f(U(r))(arg1, arg2, arg3, arg4));
        }

        public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TReturn> Y<TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(Func<Func<TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>> f)
        {
            return U<Func<TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>>(r => (arg1, arg2, arg3, arg4, arg5) => f(U(r))(arg1, arg2, arg3, arg4, arg5));
        }



        public static void U(SelfApplicable r)
        {
            r(r);
        }

        public static TResult U<TResult>(SelfApplicable<TResult> r)
        {
            return r(r);
        }

    }
}