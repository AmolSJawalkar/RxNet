// See https://aka.ms/new-console-template for more information
using MyRxNet;

Console.WriteLine("Hello, World!");

var observable = new List<int> { 1, 2,1, 3 }.ToObservable();
var consoleObserver = new ConsoleObserver<int>();
observable.Subscribe(consoleObserver);
