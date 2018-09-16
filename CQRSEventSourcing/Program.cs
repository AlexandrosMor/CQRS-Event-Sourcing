using System;

namespace CQRSEventSourcing
{
    public class Program
    {
        static void Main(string[] args)
        {
            var eventBroker = new EventBroker();

            var cart = new Cart(eventBroker);

            Console.WriteLine($"Initial cart amount is {cart.Amount}");
            eventBroker.Command(new ChangeAmountCommand(cart, 120));
            eventBroker.Command(new ChangeAmountCommand(cart, 150));
            eventBroker.Command(new ChangeAmountCommand(cart, 220));
            eventBroker.Command(new ChangeAmountCommand(cart, 227));

            foreach (var e in eventBroker.AllEvents)
            {
                Console.WriteLine(e);
            }

            int amount = eventBroker.Query<int>(new AmountQuery{Target = cart});
            Console.WriteLine($"Last cart amount {amount}");
            Console.WriteLine("Exit application");
            Console.ReadLine();
        }
    }
}
