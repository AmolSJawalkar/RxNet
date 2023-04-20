using System.Reactive.Disposables;

namespace MyRxNet;

public class Where<T> : IObservable<T>, IObserver<T>
{
    private readonly IObservable<T> _src;
    private readonly Func<T, bool> _filter;
    private IObserver<T>? _observer;
    public Where(IObservable<T> src, Func<T, bool> filter)
    {
        _src = src;
        _filter = filter;
    }

    public void OnCompleted() => _observer?.OnCompleted();

    public void OnError(Exception error) => _observer?.OnError(error);

    public void OnNext(T value)
    {
        if (_filter(value))
        {
            _observer?.OnNext(value);
        }
    }

    public IDisposable Subscribe(IObserver<T> observer)
    {
        _observer = observer;
        return new CompositeDisposable()
        {
            _src.Subscribe(this),
            Disposable.Create(() => {_observer=null; })
        };
    }
}
