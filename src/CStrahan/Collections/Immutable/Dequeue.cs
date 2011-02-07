using System;

namespace CStrahan.Collections.Immutable
{
    public sealed class Deque<T> : IDeque<T>
    {
        private sealed class EmptyDeque : IDeque<T>
        {
            public bool IsEmpty { get { return true; } }
            public IDeque<T> EnqueueLeft(T value) { return new SingleDeque(value); }
            public IDeque<T> EnqueueRight(T value) { return new SingleDeque(value); }
            public IDeque<T> DequeueLeft() { throw new Exception("empty deque"); }
            public IDeque<T> DequeueRight() { throw new Exception("empty deque"); }
            public T PeekLeft() { throw new Exception("empty deque"); }
            public T PeekRight() { throw new Exception("empty deque"); }
        }

        private sealed class SingleDeque : IDeque<T>
        {
            public SingleDeque(T t)
            {
                item = t;
            }
            private readonly T item;
            public bool IsEmpty { get { return false; } }
            public IDeque<T> EnqueueLeft(T value)
            {
                return new Deque<T>(new One(value), Deque<Dequelette>.Empty, new One(item));
            }
            public IDeque<T> EnqueueRight(T value)
            {
                return new Deque<T>(new One(item), Deque<Dequelette>.Empty, new One(value));
            }
            public IDeque<T> DequeueLeft() { return Empty; }
            public IDeque<T> DequeueRight() { return Empty; }
            public T PeekLeft() { return item; }
            public T PeekRight() { return item; }
        }

        private abstract class Dequelette
        {
            public abstract int Size { get; }
            public virtual bool Full { get { return false; } }
            public abstract T PeekLeft();
            public abstract T PeekRight();
            public abstract Dequelette EnqueueLeft(T t);
            public abstract Dequelette EnqueueRight(T t);
            public abstract Dequelette DequeueLeft();
            public abstract Dequelette DequeueRight();
        }

        private class One : Dequelette
        {
            public One(T t1)
            {
                v1 = t1;
            }
            public override int Size { get { return 1; } }
            public override T PeekLeft() { return v1; }
            public override T PeekRight() { return v1; }
            public override Dequelette EnqueueLeft(T t) { return new Two(t, v1); }
            public override Dequelette EnqueueRight(T t) { return new Two(v1, t); }
            public override Dequelette DequeueLeft() { throw new Exception("Impossible"); }
            public override Dequelette DequeueRight() { throw new Exception("Impossible"); }
            private readonly T v1;
        }

        private class Two : Dequelette
        {
            public Two(T t1, T t2)
            {
                v1 = t1;
                v2 = t2;
            }
            public override int Size { get { return 2; } }
            public override T PeekLeft() { return v1; }
            public override T PeekRight() { return v2; }
            public override Dequelette EnqueueLeft(T t) { return new Three(t, v1, v2); }
            public override Dequelette EnqueueRight(T t) { return new Three(v1, v2, t); }
            public override Dequelette DequeueLeft() { return new One(v2); }
            public override Dequelette DequeueRight() { return new One(v1); }
            private readonly T v1;
            private readonly T v2;
        }

        private class Three : Dequelette
        {
            public Three(T t1, T t2, T t3)
            {
                v1 = t1;
                v2 = t2;
                v3 = t3;
            }
            public override int Size { get { return 3; } }
            public override T PeekLeft() { return v1; }
            public override T PeekRight() { return v3; }
            public override Dequelette EnqueueLeft(T t) { return new Four(t, v1, v2, v3); }
            public override Dequelette EnqueueRight(T t) { return new Four(v1, v2, v3, t); }
            public override Dequelette DequeueLeft() { return new Two(v2, v3); }
            public override Dequelette DequeueRight() { return new Two(v1, v2); }
            private readonly T v1;
            private readonly T v2;
            private readonly T v3;
        }

        private class Four : Dequelette
        {
            public Four(T t1, T t2, T t3, T t4)
            {
                v1 = t1;
                v2 = t2;
                v3 = t3;
                v4 = t4;
            }
            public override int Size { get { return 4; } }
            public override bool Full { get { return true; } }
            public override T PeekLeft() { return v1; }
            public override T PeekRight() { return v4; }
            public override Dequelette EnqueueLeft(T t) { throw new Exception("Impossible"); }
            public override Dequelette EnqueueRight(T t) { throw new Exception("Impossible"); }
            public override Dequelette DequeueLeft() { return new Three(v2, v3, v4); }
            public override Dequelette DequeueRight() { return new Three(v1, v2, v3); }
            private readonly T v1;
            private readonly T v2;
            private readonly T v3;
            private readonly T v4;
        }

        private static readonly IDeque<T> empty = new EmptyDeque();
        public static IDeque<T> Empty { get { return empty; } }

        public bool IsEmpty { get { return false; } }

        private Deque(Dequelette left, IDeque<Dequelette> middle, Dequelette right)
        {
            this.left = left;
            this.middle = middle;
            this.right = right;
        }

        private readonly Dequelette left;
        private readonly IDeque<Dequelette> middle;
        private readonly Dequelette right;

        public IDeque<T> EnqueueLeft(T value)
        {
            if (!left.Full)
                return new Deque<T>(left.EnqueueLeft(value), middle, right);
            return new Deque<T>(
                new Two(value, left.PeekLeft()),
                middle.EnqueueLeft(left.DequeueLeft()),
                right);
        }

        public IDeque<T> EnqueueRight(T value)
        {
            if (!right.Full)
                return new Deque<T>(left, middle, right.EnqueueRight(value));
            return new Deque<T>(
                left,
                middle.EnqueueRight(right.DequeueRight()),
                new Two(right.PeekRight(), value));
        }

        public IDeque<T> DequeueLeft()
        {
            if (left.Size > 1)
                return new Deque<T>(left.DequeueLeft(), middle, right);
            if (!middle.IsEmpty)
                return new Deque<T>(middle.PeekLeft(), middle.DequeueLeft(), right);
            if (right.Size > 1)
                return new Deque<T>(new One(right.PeekLeft()), middle, right.DequeueLeft());
            return new SingleDeque(right.PeekLeft());
        }

        public IDeque<T> DequeueRight()
        {
            if (right.Size > 1)
                return new Deque<T>(left, middle, right.DequeueRight());
            if (!middle.IsEmpty)
                return new Deque<T>(left, middle.DequeueRight(), middle.PeekRight());
            if (left.Size > 1)
                return new Deque<T>(left.DequeueRight(), middle, new One(left.PeekRight()));
            return new SingleDeque(left.PeekRight());
        }

        public T PeekLeft() { return left.PeekLeft(); }
        public T PeekRight() { return right.PeekRight(); }
    }
}