namespace CStrahan.Collections.Immutable
{
    public interface IDeque<T>
    {
        T PeekLeft();
        T PeekRight();
        IDeque<T> EnqueueLeft(T value);
        IDeque<T> EnqueueRight(T value);
        IDeque<T> DequeueLeft();
        IDeque<T> DequeueRight();
        bool IsEmpty { get; }
    }
}