namespace CQRSEventSourcing
{
    public class CartChangeEvent : Event
    {
        public Cart Target;
        public int OldValue, NewValue;

        public CartChangeEvent(Cart target, int oldValue, int newValue)
        {
            Target = target;
            OldValue = oldValue;
            NewValue = newValue;
        }

        public override string ToString()
        {
            return $"Cart amount changed from  {OldValue} to {NewValue}";
        }
    }
}