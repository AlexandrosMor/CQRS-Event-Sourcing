namespace CQRSEventSourcing
{
    public class Cart
    {
        public int Amount { get; set; }
        private readonly EventBroker _eventBroker;

        public Cart(EventBroker eventBroker)
        {
            _eventBroker = eventBroker;
            _eventBroker.Commands += EventBrokerOnCommands;
            _eventBroker.Queries += EventBrokerOnQueries;
        }

        private void EventBrokerOnQueries(object sender, Query query)
        {
            var amountQuery = (AmountQuery)query;
            if (amountQuery != null && amountQuery.Target == this)
            {
                amountQuery.Result = Amount;
            }
        }

        private void EventBrokerOnCommands(object sender, Command command)
        {
            var changeAmountCommand = (ChangeAmountCommand)command;
            if (changeAmountCommand != null && changeAmountCommand.Target == this)
            {
                if (changeAmountCommand.Register)
                {
                    _eventBroker.AllEvents.Add(new CartChangeEvent(this, Amount, changeAmountCommand.Amount));
                }
                Amount = changeAmountCommand.Amount;
            }
        }
    }
}