namespace MyRxNet;

internal class ConsoleObserver<T> : IObserver<T>
{
    public void OnCompleted()
    {
        Console.WriteLine("Complete");
    }

    public void OnError(Exception error)
    {
        Console.WriteLine(error.ToString());
    }

    public void OnNext(T value)
    {
        Console.WriteLine($"{value}");
    }
}
