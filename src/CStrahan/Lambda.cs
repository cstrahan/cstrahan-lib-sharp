using System;

namespace CStrahan
{
    public class Lambda
    {
        static Action Y(Func<Action, Action> f)
        {
            RecursiveAction rec = r => () => f(r(r))();
            return rec(rec);
        }
        
        static Action<TArg1> Y<TArg1>(Func<Action<TArg1>, Action<TArg1>> f)
        {
            RecursiveAction<TArg1> rec = r => arg1 => f(r(r))(arg1);
            return rec(rec);
        }

        static Action<TArg1, TArg2> Y<TArg1, TArg2>(Func<Action<TArg1, TArg2>, Action<TArg1, TArg2>> f)
        {
            RecursiveAction<TArg1, TArg2> rec = r => (arg1, arg2) => f(r(r))(arg1, arg2);
            return rec(rec);
        }

        static Action<TArg1, TArg2, TArg3> Y<TArg1, TArg2, TArg3>(Func<Action<TArg1, TArg2, TArg3>, Action<TArg1, TArg2, TArg3>> f)
        {
            RecursiveAction<TArg1, TArg2, TArg3> rec = r => (arg1, arg2, arg3) => f(r(r))(arg1, arg2, arg3);
            return rec(rec);
        }

        static Action<TArg1, TArg2, TArg3, TArg4> Y<TArg1, TArg2, TArg3, TArg4>(Func<Action<TArg1, TArg2, TArg3, TArg4>, Action<TArg1, TArg2, TArg3, TArg4>> f)
        {
            RecursiveAction<TArg1, TArg2, TArg3, TArg4> rec = r => (arg1, arg2, arg3, arg4) => f(r(r))(arg1, arg2, arg3, arg4);
            return rec(rec);
        }

        static Action<TArg1, TArg2, TArg3, TArg4, TArg5> Y<TArg1, TArg2, TArg3, TArg4, TArg5>(Func<Action<TArg1, TArg2, TArg3, TArg4, TArg5>, Action<TArg1, TArg2, TArg3, TArg4, TArg5>> f)
        {
            RecursiveAction<TArg1, TArg2, TArg3, TArg4, TArg5> rec = r => (arg1, arg2, arg3, arg4, arg5) => f(r(r))(arg1, arg2, arg3, arg4, arg5);
            return rec(rec);
        }

        

        static Func<TReturn> Y<TReturn>(Func<Func<TReturn>, Func<TReturn>> f)
        {
            RecursiveFunc<TReturn> rec = r => () => f(r(r))();
            return rec(rec);
        }

        static Func<TArg1, TReturn> Y<TArg1, TReturn>(Func<Func<TArg1, TReturn>, Func<TArg1, TReturn>> f)
        {
            RecursiveFunc<TArg1, TReturn> rec = r => arg1 => f(r(r))(arg1);
            return rec(rec);
        }

        static Func<TArg1, TArg2, TReturn> Y<TArg1, TArg2, TReturn>(Func<Func<TArg1, TArg2, TReturn>, Func<TArg1, TArg2, TReturn>> f)
        {
            RecursiveFunc<TArg1, TArg2, TReturn> rec = r => (arg1, arg2) => f(r(r))(arg1, arg2);
            return rec(rec);
        }

        static Func<TArg1, TArg2, TArg3, TReturn> Y<TArg1, TArg2, TArg3, TReturn>(Func<Func<TArg1, TArg2, TArg3, TReturn>, Func<TArg1, TArg2, TArg3, TReturn>> f)
        {
            RecursiveFunc<TArg1, TArg2, TArg3, TReturn> rec = r => (arg1, arg2, arg3) => f(r(r))(arg1, arg2, arg3);
            return rec(rec);
        }

        static Func<TArg1, TArg2, TArg3, TArg4, TReturn> Y<TArg1, TArg2, TArg3, TArg4, TReturn>(Func<Func<TArg1, TArg2, TArg3, TArg4, TReturn>, Func<TArg1, TArg2, TArg3, TArg4, TReturn>> f)
        {
            RecursiveFunc<TArg1, TArg2, TArg3, TArg4, TReturn> rec = r => (arg1, arg2, arg3, arg4) => f(r(r))(arg1, arg2, arg3, arg4);
            return rec(rec);
        }

        static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TReturn> Y<TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(Func<Func<TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>> f)
        {
            RecursiveFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TReturn> rec = r => (arg1, arg2, arg3, arg4, arg5) => f(r(r))(arg1, arg2, arg3, arg4, arg5);
            return rec(rec);
        }
    }
}