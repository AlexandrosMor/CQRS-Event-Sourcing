using System;

namespace CQRSEventSourcing
{
    public class Command : EventArgs
    {
        public bool Register = true;
    }
}