using System;

namespace GB_Asteroids.MessageBroker
{
    public class MessageBase<T>
    {
        public object Sender { get; private set; }
        public T Data { get; private set; }
        public DateTime When { get; private set; }
        public MessageBase(T data, object source)
        {
            Sender = source; Data = data; When = DateTime.UtcNow;
        }
    }
}
