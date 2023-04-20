// See https://aka.ms/new-console-template for more information
using MyRxNet;

Console.WriteLine("Hello, World!");

var observable = new List<int> { 1, 2,1, 3 }.ToObservable();
var consoleObserver = new ConsoleObserver<double>();

//Where
observable = observable.Where(val => val > 0);

//Select
var observable1 = observable.Select(val => Convert.ToDouble(val));

observable1.Subscribe(consoleObserver);
