using UnityEngine;

namespace GB_Asteroids.MessageBroker
{
    public class MessageBase
    {
        public MonoBehaviour sender { get; private set; } 
        public int id { get; private set; } 
        public object data { get; private set; } 

        public MessageBase(MonoBehaviour sender, int id, object data)
        {
            this.sender = sender;
            this.id = id;
            this.data = data;

        }

        public static MessageBase Create(MonoBehaviour sender,int id, object data)
        {
            return new MessageBase(sender, id, data);
        }
    }
}
