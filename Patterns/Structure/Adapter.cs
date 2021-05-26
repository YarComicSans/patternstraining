using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns.Structure
{
    public interface ITarget
    {
        string GetRequest();
    }

    class Adaptee
    {
        public string GetSpecificRequest()
        {
            return "Specific request";
        }
    }

    class Adapter : ITarget
    {
        private readonly Adaptee _adaptee;

        public Adapter(Adaptee adaptee)
        {
            this._adaptee = adaptee;
        }

        public string GetRequest()
        {
            return $"This is '{this._adaptee.GetSpecificRequest()}'";
        }
    }

    public class AdapterPattern
    {
        public void Main()
        {
            Adaptee adaptee = new Adaptee();
            ITarget target = new Adapter(adaptee);

            Console.WriteLine("Adaptee interface is incompatible with the client.");
            Console.WriteLine("But with adapter client can call it's method.");

            Console.WriteLine(target.GetRequest());
        }
    }
}
