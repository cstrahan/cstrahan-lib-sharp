using System;

namespace CStrahan
{
    delegate Action Recursive(Recursive r);
    delegate Func<TReturn> Recursive<TReturn>(Recursive<TReturn> r);
    delegate Func<TArg1, TReturn> Recursive<TArg1, TReturn>(Recursive<TArg1, TReturn> r);
    delegate Func<TArg1, TArg2, TReturn> Recursive<TArg1, TArg2, TReturn>(Recursive<TArg1, TArg2, TReturn> r);
    delegate Func<TArg1, TArg2, TArg3, TReturn> Recursive<TArg1, TArg2, TArg3, TReturn>(Recursive<TArg1, TArg2, TArg3, TReturn> r);
    delegate Func<TArg1, TArg2, TArg3, TArg4, TReturn> Recursive<TArg1, TArg2, TArg3, TArg4, TReturn>(Recursive<TArg1, TArg2, TArg3, TArg4, TReturn> r);
    delegate Func<TArg1, TArg2, TArg3, TArg4, TArg5, TReturn> Recursive<TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(Recursive<TArg1, TArg2, TArg3, TArg4, TArg5, TReturn> r);
}