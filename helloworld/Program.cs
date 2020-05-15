using System;

namespace helloworld
{
    class Program
    {
        static void Main(string[] args)
        {
            var c1 = new MyClass();
            Console.WriteLine($"Hello World {c1.returnMessage()}");
        }
    }
}
