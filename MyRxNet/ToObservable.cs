using System.Reactive.Disposables;

namespace MyRxNet;

public class ToObservable<T> : IObservable<T>
{
    private readonly IEnumerable<T> _values;

    public ToObservable(IEnumerable<T> values)
    {
        _values = values;
    }
    public IDisposable Subscribe(IObserver<T> observer)
    {
        foreach (var item in _values)
        {
            observer.OnNext(item);
        }

        observer.OnCompleted();

        return Disposable.Empty;
    }
}
