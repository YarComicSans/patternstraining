using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns.Structure
{
    public class FacadePattern
    {
        public class Facade
        {
            protected Subsystem1 _subsystem1;
            protected Subsystem2 _subsystem2;

            public Facade(Subsystem1 subsystem1, Subsystem2 subsystem2)
            {
                _subsystem1 = subsystem1;
                _subsystem2 = subsystem2;
            }

            public string Operation()
            {
                string result = "Facade initializes subsystems:\n";
                result += _subsystem1.Operation1();
                result += _subsystem2.Operation1();
                result += "Facade orders subsystems to perform the action:\n";
                result += _subsystem1.OperationN();
                result += _subsystem2.OperationN();
                return result;
            }
        }

        public class Subsystem1
        {
            public string Operation1()
            {
                return "Subsystem1: Operation 1\n";
            }

            public string OperationN()
            {
                return "Subsystem1: Operation N\n";
            }
        }

        public class Subsystem2
        {
            public string Operation1()
            {
                return "Subsystem2: Operation 1\n";
            }

            public string OperationN()
            {
                return "Subsystem2: Operation N\n";
            }
        }

        class Client
        {
            public static void ClientCode(Facade facade)
            {
                Console.WriteLine(facade.Operation());
            }
        }

        public void Main()
        {
            Subsystem1 subsystem1 = new Subsystem1();
            Subsystem2 subsystem2 = new Subsystem2();
            Facade facade = new Facade(subsystem1, subsystem2);
            Client.ClientCode(facade);
        }
    }
}
