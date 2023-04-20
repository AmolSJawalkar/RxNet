namespace MyRxNet;

public static class ObservableExt
{
    public static IObservable<T> ToObservable<T>(this IEnumerable<T> values)
    {
        return new ToObservable<T>(values);
    }

    public static IObservable<T> Where<T>(this IObservable<T> src, Func<T, bool> filter)
    {
        return new Where<T>(src, filter);
    }
}
