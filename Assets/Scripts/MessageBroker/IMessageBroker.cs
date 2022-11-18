using System;

namespace GB_Asteroids.MessageBroker
{
    public interface IMessageBroker : IDisposable
    {
        void Publish(object id);
        void Subscribe(object id, Action subscription);
        void Unsubscribe(object id, Action subscription);
    }
}
