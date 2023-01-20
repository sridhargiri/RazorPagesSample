using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     https://www.dofactory.com/net/chain-of-responsibility-design-pattern#:~:text=The%20Chain%20of%20Responsibility%20design,until%20an%20object%20handles%20it.
    The Chain of Responsibility design pattern avoids coupling the sender of a request to its receiver by giving more than one object a chance to handle the request. 
    This pattern chains the receiving objects and passes the request along the chain until an object handles it
     */
    public class ChainResponsibility
    {
        public static void Main(string[] args)
        {
            // Setup Chain of Responsibility
            Handler h1 = new ConcreteHandler1();
            Handler h2 = new ConcreteHandler2();
            Handler h3 = new ConcreteHandler3();
            h1.SetSuccessor(h2);
            h2.SetSuccessor(h3);
            // Generate and process request
            int[] requests = { 2, 5, 14, 22, 18, 3, 27, 20 };
            foreach (int request in requests)
            {
                h1.HandleRequest(request);
            }
            // Wait for user
            Console.ReadKey();
        }
    }
    /// <summary>
    /// The 'Handler' abstract class
    /// </summary>
    public abstract class Handler
    {
        protected Handler successor;
        public void SetSuccessor(Handler successor)
        {
            this.successor = successor;
        }
        public abstract void HandleRequest(int request);
    }
    /// <summary>
    /// The 'ConcreteHandler1' class
    /// </summary>
    public class ConcreteHandler1 : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request >= 0 && request < 10)
            {
                Console.WriteLine("{0} handled request {1}",
                    this.GetType().Name, request);
            }
            else if (successor != null)
            {
                successor.HandleRequest(request);
            }
        }
    }
    /// <summary>
    /// The 'ConcreteHandler2' class
    /// </summary>
    public class ConcreteHandler2 : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request >= 10 && request < 20)
            {
                Console.WriteLine("{0} handled request {1}",
                    this.GetType().Name, request);
            }
            else if (successor != null)
            {
                successor.HandleRequest(request);
            }
        }
    }
    /// <summary>
    /// The 'ConcreteHandler3' class
    /// </summary>
    public class ConcreteHandler3 : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request >= 20 && request < 30)
            {
                Console.WriteLine("{0} handled request {1}",
                    this.GetType().Name, request);
            }
            else if (successor != null)
            {
                successor.HandleRequest(request);
            }
        }
    }
    /*
     https://refactoring.guru/design-patterns/chain-of-responsibility/csharp/example
    
     */
}
namespace ConsoleApp1
{

    // https://refactoring.guru/design-patterns/chain-of-responsibility/csharp/example
    // The Handler interface declares a method for building the chain of
    // handlers. It also declares a method for executing a request.
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);

        object Handle(object request);
    }

    // The default chaining behavior can be implemented inside a base handler class.
    public abstract class AbstractHandler : IHandler
    {
        private IHandler _nextHandler;

        public IHandler SetNext(IHandler handler)
        {
            this._nextHandler = handler;

            // Returning a handler from here will let us link handlers in a
            // convenient way like this:
            // monkey.SetNext(squirrel).SetNext(dog);
            return handler;
        }

        public virtual object Handle(object request)
        {
            if (this._nextHandler != null)
            {
                return this._nextHandler.Handle(request);
            }
            else
            {
                return null;
            }
        }
    }

    public class MonkeyHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
            if ((request as string) == "Banana")
            {
                return $"Monkey: I'll eat the {request.ToString()}.\n";
            }
            else
            {
                return base.Handle(request);
            }
        }
    }

    public class SquirrelHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
            if (request.ToString() == "Nut")
            {
                return $"Squirrel: I'll eat the {request.ToString()}.\n";
            }
            else
            {
                return base.Handle(request);
            }
        }
    }

    class DogHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
            if (request.ToString() == "MeatBall")
            {
                return $"Dog: I'll eat the {request.ToString()}.\n";
            }
            else
            {
                return base.Handle(request);
            }
        }
    }

    public class ClientCodeClass
    {
        // The client code is usually suited to work with a single handler. In
        // most cases, it is not even aware that the handler is part of a chain.
        public static void ClientCode(AbstractHandler handler)
        {
            foreach (var food in new List<string> { "Nut", "Banana", "Cup of coffee" })
            {
                Console.WriteLine($"Client: Who wants a {food}?");

                var result = handler.Handle(food);

                if (result != null)
                {
                    Console.Write($"   {result}");
                }
                else
                {
                    Console.WriteLine($"   {food} was left untouched.");
                }
            }
        }
    }

    public class ChainOfResponsibility
    {
        static void Main(string[] args)
        {
            // The other part of the client code constructs the actual chain.
            var monkey = new MonkeyHandler();
            var squirrel = new SquirrelHandler();
            var dog = new DogHandler();

            monkey.SetNext(squirrel).SetNext(dog);

            // The client should be able to send a request to any handler, not
            // just the first one in the chain.
            Console.WriteLine("Chain: Monkey > Squirrel > Dog\n");
            ClientCodeClass.ClientCode(monkey);
            Console.WriteLine();

            Console.WriteLine("Subchain: Squirrel > Dog\n");
            ClientCodeClass.ClientCode(squirrel);
        }
    }

}
namespace ConsoleApp1
{
    // https://dotnettutorials.net/lesson/chain-of-responsibility-design-pattern/
    public abstract class RupeeHandler
    {
        public RupeeHandler rsHandler;
        public RupeeHandler SetNextHandler(RupeeHandler rsHandler)
        {
            this.rsHandler = rsHandler;
            return rsHandler;
        }
        public abstract void DispatchRupees(long requestedAmount);
    }
    public class TwoThousandHandler : RupeeHandler
    {
        public override void DispatchRupees(long requestedAmount)
        {
            long numberofNotesToBeDispatched = requestedAmount / 2000;
            if (numberofNotesToBeDispatched > 0)
            {
                if (numberofNotesToBeDispatched > 1)
                {
                    Console.WriteLine(numberofNotesToBeDispatched + " Two Thousand notes are dispatched by TwoThousandHandler");
                }
                else
                {
                    Console.WriteLine(numberofNotesToBeDispatched + " Two Thousand note is dispatched by TwoThousandHandler");
                }
            }
            long pendingAmountToBeProcessed = requestedAmount % 2000;
            if (pendingAmountToBeProcessed > 0)
            {
                rsHandler.DispatchRupees(pendingAmountToBeProcessed);
            }
        }
    }
    public class FiveHundredHandler : RupeeHandler
    {
        public override void DispatchRupees(long requestedAmount)
        {
            long numberofNotesToBeDispatched = requestedAmount / 500;
            if (numberofNotesToBeDispatched > 0)
            {
                if (numberofNotesToBeDispatched > 1)
                {
                    Console.WriteLine(numberofNotesToBeDispatched + " Five Hundred notes are dispatched by FiveHundredHandler");
                }
                else
                {
                    Console.WriteLine(numberofNotesToBeDispatched + " Five Hundred note is dispatched by FiveHundredHandler");
                }
            }
            long pendingAmountToBeProcessed = requestedAmount % 500;
            if (pendingAmountToBeProcessed > 0)
            {
                rsHandler.DispatchRupees(pendingAmountToBeProcessed);
            }
        }
    }
    public class TwoHundredHandler : RupeeHandler
    {
        public override void DispatchRupees(long requestedAmount)
        {
            long numberofNotesToBeDispatched = requestedAmount / 200;
            if (numberofNotesToBeDispatched > 0)
            {
                if (numberofNotesToBeDispatched > 1)
                {
                    Console.WriteLine(numberofNotesToBeDispatched + " Two Hundred notes are dispatched by TwoHundredHandler");
                }
                else
                {
                    Console.WriteLine(numberofNotesToBeDispatched + " Two Hundred note is dispatched by TwoHundredHandler");
                }
            }
            long pendingAmountToBeProcessed = requestedAmount % 200;
            if (pendingAmountToBeProcessed > 0)
            {
                rsHandler.DispatchRupees(pendingAmountToBeProcessed);
            }
        }
    }
    public class HundredHandler : RupeeHandler
    {
        public override void DispatchRupees(long requestedAmount)
        {
            long numberofNotesToBeDispatched = requestedAmount / 100;
            if (numberofNotesToBeDispatched > 0)
            {
                if (numberofNotesToBeDispatched > 1)
                {
                    Console.WriteLine(numberofNotesToBeDispatched + " Hundred notes are dispatched by HundredHandler");
                }
                else
                {
                    Console.WriteLine(numberofNotesToBeDispatched + " Hundred note is dispatched by HundredHandler");
                }
            }
            long pendingAmountToBeProcessed = requestedAmount % 100;
            if (pendingAmountToBeProcessed > 0)
            {
                rsHandler.DispatchRupees(pendingAmountToBeProcessed);
            }
        }
    }
    public class ChainOfResponsibilityDesignPattern
    {

        private TwoThousandHandler twoThousandHandler = new TwoThousandHandler();
        private FiveHundredHandler fiveHundredHandler = new FiveHundredHandler();
        private TwoHundredHandler twoHundredHandler = new TwoHundredHandler();
        private HundredHandler hundredHandler = new HundredHandler();

        public ChainOfResponsibilityDesignPattern()
        {
            // Prepare the chain of Handlers
            twoThousandHandler.SetNextHandler(fiveHundredHandler).SetNextHandler(twoHundredHandler).SetNextHandler(hundredHandler);
        }

        public void Withdraw(long requestedAmount)
        {
            twoThousandHandler.DispatchRupees(requestedAmount);
        }
        static void Main(string[] args)
        {
            ChainOfResponsibilityDesignPattern atm = new ChainOfResponsibilityDesignPattern();
            Console.WriteLine("\n Requested Amount 4600");
            atm.Withdraw(4600);
            Console.WriteLine("\n Requested Amount 1900");
            atm.Withdraw(1900);
            Console.WriteLine("\n Requested Amount 600");
            atm.Withdraw(600);
            Console.WriteLine("\n Requested Amount 5000");
            atm.Withdraw(5000);
        }
    }
}
namespace ConsoleApp1
{
    public abstract class Employee
    {
        // next element in chain or responsibility
        protected Employee supervisor;
        public void setNextSupervisor(Employee supervisor)
        {
            this.supervisor = supervisor;
        }
        public abstract void applyLeave(string employeeName, int numberofDaysLeave);
    }
    public class TeamLeader : Employee
    {
        // TeamLeader can only approve upto 10 days of leave
        private int MAX_LEAVES_CAN_APPROVE = 10;
        public override void applyLeave(string employeeName, int numberofDaysLeave)
        {
            // check if TeamLeader can process this request
            if (numberofDaysLeave <= MAX_LEAVES_CAN_APPROVE)
            {
                ApproveLeave(employeeName, numberofDaysLeave);
            }
            // if TeamLeader can't process the LeaveRequest then pass on to the supervisor(ProjectLeader)
            // so that he can process
            else
            {
                supervisor.applyLeave(employeeName, numberofDaysLeave);
            }
        }
        private void ApproveLeave(string employeeName, int numberofDaysLeave)
        {
            Console.WriteLine("TeamLeader approved " + numberofDaysLeave + " days " + "Leave for the employee : " + employeeName);
        }
    }
    public class ProjectLeader : Employee
    {
        // ProjectLeader can only approve upto 20 days of leave
        private int MAX_LEAVES_CAN_APPROVE = 20;
        public override void applyLeave(string employeeName, int numberofDaysLeave)
        {
            // check if ProjectLeader can process this request
            if (numberofDaysLeave <= MAX_LEAVES_CAN_APPROVE)
            {
                ApproveLeave(employeeName, numberofDaysLeave);
            }
            // if ProjectLeader can't process the LeaveRequest then pass on to the supervisor(HR) 
            // so that he can process
            else
            {
                supervisor.applyLeave(employeeName, numberofDaysLeave);
            }
        }
        private void ApproveLeave(string employeeName, int numberofDaysLeave)
        {
            Console.WriteLine("ProjectLeader approved " + numberofDaysLeave + " days " + "Leave for the employee : " + employeeName);
        }
    }
    public class HR : Employee
    {
        // HR can only approve upto 30 days of leave
        private int MAX_LEAVES_CAN_APPROVE = 30;
        public override void applyLeave(string employeeName, int numberofDaysLeave)
        {
            if (numberofDaysLeave <= MAX_LEAVES_CAN_APPROVE)
            {
                ApproveLeave(employeeName, numberofDaysLeave);
            }
            else
            {
                Console.WriteLine("Leave application suspended, Please contact HR");
            }
        }
        private void ApproveLeave(string employeeName, int numberofDaysLeave)
        {
            Console.WriteLine("HR approved " + numberofDaysLeave + " days " + "Leave for the employee : "  + employeeName);
        }
    }
    public class ChainOfResponsibilityExample
    {
        static void Main(string[] args)
        {
            TeamLeader teamLeader = new TeamLeader();
            ProjectLeader projectLeader = new ProjectLeader();
            HR hr = new HR();
            teamLeader.setNextSupervisor(projectLeader);
            projectLeader.setNextSupervisor(hr);
            teamLeader.applyLeave("Anurag", 9);
            Console.WriteLine();
            teamLeader.applyLeave("Pranaya", 18);
            Console.WriteLine();
            teamLeader.applyLeave("Priyanka", 30);
            Console.WriteLine();
            teamLeader.applyLeave("Ramesh", 50);
        }
    }
}



