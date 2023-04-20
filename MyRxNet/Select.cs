using System.Reactive.Disposables;

namespace MyRxNet
{
    internal class Select<TIn, TOut> : IObservable<TOut>, IObserver<TIn>
    {
        private readonly IObservable<TIn> _src;
        private readonly Func<TIn, TOut> _selector;
        private IObserver<TOut>? _observer;
        public Select(IObservable<TIn> src, Func<TIn, TOut> selector)
        {
            _src = src;
            _selector = selector;
        }

        public void OnCompleted() => _observer?.OnCompleted();

        public void OnError(Exception error) => _observer?.OnError(error);

        public void OnNext(TIn value) => _observer?.OnNext(_selector(value));

        public IDisposable Subscribe(IObserver<TOut> observer)
        {
            _observer = observer;

            return new CompositeDisposable()
            {
                _src.Subscribe(this),
                Disposable.Create(() => _observer = null)
            };
        }
    }
}