using System;

namespace CStrahan
{
    public delegate void SelfApplicable(SelfApplicable r);
    public delegate TResult SelfApplicable<TResult>(SelfApplicable<TResult> r);
}