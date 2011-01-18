using System;

namespace CStrahan
{
    public class Lambda
    {
        static Action Y(Func<Action, Action> f)
        {
            Recursive rec = r => () => f(r(r))();
            return rec(rec);
        }

        static Func<TReturn> Y<TReturn>(Func<Func<TReturn>, Func<TReturn>> f)
        {
            Recursive<TReturn> rec = r => () => f(r(r))();
            return rec(rec);
        }

        static Func<TArg1, TReturn> Y<TArg1, TReturn>(Func<Func<TArg1, TReturn>, Func<TArg1, TReturn>> f)
        {
            Recursive<TArg1, TReturn> rec = r => arg1 => f(r(r))(arg1);
            return rec(rec);
        }

        static Func<TArg1, TArg2, TReturn> Y<TArg1, TArg2, TReturn>(Func<Func<TArg1, TArg2, TReturn>, Func<TArg1, TArg2, TReturn>> f)
        {
            Recursive<TArg1, TArg2, TReturn> rec = r => (arg1, arg2) => f(r(r))(arg1, arg2);
            return rec(rec);
        }

        static Func<TArg1, TArg2, TArg3, TReturn> Y<TArg1, TArg2, TArg3, TReturn>(Func<Func<TArg1, TArg2, TArg3, TReturn>, Func<TArg1, TArg2, TArg3, TReturn>> f)
        {
            Recursive<TArg1, TArg2, TArg3, TReturn> rec = r => (arg1, arg2, arg3) => f(r(r))(arg1, arg2, arg3);
            return rec(rec);
        }

        static Func<TArg1, TArg2, TArg3, TArg4, TReturn> Y<TArg1, TArg2, TArg3, TArg4, TReturn>(Func<Func<TArg1, TArg2, TArg3, TArg4, TReturn>, Func<TArg1, TArg2, TArg3, TArg4, TReturn>> f)
        {
            Recursive<TArg1, TArg2, TArg3, TArg4, TReturn> rec = r => (arg1, arg2, arg3, arg4) => f(r(r))(arg1, arg2, arg3, arg4);
            return rec(rec);
        }

        static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TReturn> Y<TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(Func<Func<TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>> f)
        {
            Recursive<TArg1, TArg2, TArg3, TArg4, TArg5, TReturn> rec = r => (arg1, arg2, arg3, arg4, arg5) => f(r(r))(arg1, arg2, arg3, arg4, arg5);
            return rec(rec);
        }
    }
}