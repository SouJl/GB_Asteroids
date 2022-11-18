using System;
using System.Collections.Generic;

namespace GB_Asteroids.MessageBroker
{
    public class MessageBrokerHandler: IMessageBroker
    {
        private static MessageBrokerHandler _instance;
        private readonly Dictionary<object, List<Action>> _subscribers;
        public static MessageBrokerHandler Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MessageBrokerHandler();
                return _instance;
            }
        }

        private MessageBrokerHandler()
        {
            _subscribers = new Dictionary<object, List<Action>>();
        }

        public void Publish(object id)
        {            
            if (!_subscribers.ContainsKey(id))
            {
                return;
            }
            
            var actions = _subscribers[id];
            
            if (actions == null || actions.Count == 0) return;
            
            foreach (var item in actions)
            {
                item.Invoke();
            }
        }

        public void Subscribe(object id, Action subscription)
        {
            var actions = _subscribers.ContainsKey(id) ?
                            _subscribers[id] : new List<Action>();
            if (!actions.Contains(subscription))
            {
                actions.Add(subscription);
            }
            _subscribers[id] = actions;
        }

        public void Unsubscribe(object id, Action subscription)
        {
            if (!_subscribers.ContainsKey(id)) return;
            
            var actions = _subscribers[id];
            
            if (actions.Contains(subscription))
                actions.Remove(subscription);
            
            if (actions.Count == 0)
                _subscribers.Remove(id);
        }

        public void Dispose()
        {
            _subscribers?.Clear();
        }
    }
}
