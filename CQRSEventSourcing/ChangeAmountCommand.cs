namespace CQRSEventSourcing
{
    public class ChangeAmountCommand : Command
    {
        public Cart Target;
        public int Amount;

        public ChangeAmountCommand(Cart target, int amount)
        {
            Target = target;
            Amount = amount;
        }
    }
}