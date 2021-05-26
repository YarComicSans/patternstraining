using Patterns.Generating;
using Patterns.Structure;
using Patterns.Behaviour;

namespace Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            //new Client().Main(); //factory method
            //new ClientAbstractFactory().Main(); //abstract factory
            //new BuilderPattern().Main(); //builder
            //new PrototypePattern().Main(); //Prototype
            //new SingletonPattern().Main(); //Singleton

            //new AdapterPattern().Main(); //Adapter
            //new BridgePattern().Main(); //Bridge
            //new CompositePattern().Main(); //Composite
            //new DecoratorPattern().Main(); //Decorator
            //new FacadePattern().Main(); //Facade
            //new FlyweightPattern().Main(); //Flyweight
            //new ProxyPattern().Main(); //Proxy

            new ChainOfResponsibility().Main(); //Chain of responsibility
        }
    }
}
