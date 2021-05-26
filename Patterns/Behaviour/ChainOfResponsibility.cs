using System;
using System.Collections.Generic;

namespace Patterns.Behaviour
{
    public class ChainOfResponsibility
    {
        public interface IHandler
        {
            IHandler SetNext(IHandler handler);

            object Handle(object request);
        }

        abstract class AbstractHandler: IHandler
        {
            private IHandler _nextHandler;
            
            public IHandler SetNext(IHandler hanlder)
            {
                this._nextHandler = hanlder;

                return hanlder;
            }

            public virtual object Handle(object request)
            {
                if(this._nextHandler != null)
                {
                    return this._nextHandler.Handle(request);
                }
                else
                {
                    return null;
                }
            }
        }

        class MonkeyHanlder: AbstractHandler
        {
            public override object Handle(object request)
            {
                if((request as string) == "Banana")
                {
                    return $"Monkey: I'll eat the ${request.ToString()}.\n";
                }
                else
                {
                    return base.Handle(request);
                }
            }
        }

        class SquirrelHanlder: AbstractHandler
        {
            public override object Handle(object request)
            {
                if((request as string) == "Nut")
                {
                    return $"Squirrel: I'll eat the {request.ToString()}.\n";
                }
                else
                {
                    return base.Handle(request);
                }
            }
        }

        class DogHanlder : AbstractHandler
        {
            public override object Handle(object request)
            {
                if((request as string) == "Meat")
                {
                    return $"Dog: I'll eat the {request.ToString()}.\n";
                }
                else
                {
                    return base.Handle(request);
                }
            }
        }

        class Client
        {
            public static void ClientCode(AbstractHandler handler)
            {
                foreach(var food in new List<string> { "Banana", "Meat", "Cup of coffee" })
                {
                    Console.WriteLine($"Client: Who wants a {food}?");

                    var result = handler.Handle(food);

                    if(result != null)
                    {
                        Console.WriteLine($"{result}");
                    }
                    else
                    {
                        Console.WriteLine($"{food} was left untouched. No matter how tempting that was...\n");
                    }
                }
            }
        }
        public void Main()
        {
            var monkey = new MonkeyHanlder();
            var squirrel = new SquirrelHanlder();
            var dog = new DogHanlder();

            monkey.SetNext(squirrel).SetNext(dog);

            Console.WriteLine("Chain: Monkey => Squirrel => Dog\n");
            Client.ClientCode(monkey);
            Console.WriteLine();

            Console.WriteLine("Chain: Squirrel => Dog\n");
            Client.ClientCode(squirrel);
        }
    }
}
