using System;
using System.Collections.Generic;
using System.Linq;

namespace CQRSEventSourcing
{
    public class EventBroker
    {
        //1. All events that happened
        public IList<Event> AllEvents = new List<Event>();
        //2. Commands
        public event EventHandler<Command> Commands;
        //3. Query
        public event EventHandler<Query> Queries;

        public void Command(Command c)
        {
            Commands?.Invoke(this,c);
        }

        public T Query<T>(Query q)
        {
            Queries?.Invoke(this,q);
            return (T)q.Result;
        }
    }
}