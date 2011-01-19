using System;

namespace CStrahan
{
    delegate Action RecursiveAction(RecursiveAction r);
    delegate Action<TArg1> RecursiveAction<TArg1>(RecursiveAction<TArg1> r);
    delegate Action<TArg1, TArg2> RecursiveAction<TArg1, TArg2>(RecursiveAction<TArg1, TArg2> r);
    delegate Action<TArg1, TArg2, TArg3> RecursiveAction<TArg1, TArg2, TArg3>(RecursiveAction<TArg1, TArg2, TArg3> r);
    delegate Action<TArg1, TArg2, TArg3, TArg4> RecursiveAction<TArg1, TArg2, TArg3, TArg4>(RecursiveAction<TArg1, TArg2, TArg3, TArg4> r);
    delegate Action<TArg1, TArg2, TArg3, TArg4, TArg5> RecursiveAction<TArg1, TArg2, TArg3, TArg4, TArg5>(RecursiveAction<TArg1, TArg2, TArg3, TArg4, TArg5> r);

    delegate Func<TReturn> RecursiveFunc<TReturn>(RecursiveFunc<TReturn> r);
    delegate Func<TArg1, TReturn> RecursiveFunc<TArg1, TReturn>(RecursiveFunc<TArg1, TReturn> r);
    delegate Func<TArg1, TArg2, TReturn> RecursiveFunc<TArg1, TArg2, TReturn>(RecursiveFunc<TArg1, TArg2, TReturn> r);
    delegate Func<TArg1, TArg2, TArg3, TReturn> RecursiveFunc<TArg1, TArg2, TArg3, TReturn>(RecursiveFunc<TArg1, TArg2, TArg3, TReturn> r);
    delegate Func<TArg1, TArg2, TArg3, TArg4, TReturn> RecursiveFunc<TArg1, TArg2, TArg3, TArg4, TReturn>(RecursiveFunc<TArg1, TArg2, TArg3, TArg4, TReturn> r);
    delegate Func<TArg1, TArg2, TArg3, TArg4, TArg5, TReturn> RecursiveFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(RecursiveFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TReturn> r);
}