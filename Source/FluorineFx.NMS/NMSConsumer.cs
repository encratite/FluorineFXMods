using System;
using Apache.NMS;

namespace FluorineFx.NMS
{
    public delegate void messageHandler(String clientId, String subscriptionId, IMessage message);

    class NMSConsumer
    {
        public event messageHandler MessageHandler;

        private IMessageConsumer consumer;
        private String clientId;
        private String subscriptionId;

        public NMSConsumer(IMessageConsumer consumer, String clientId, String subscriptionId)
        {
            this.consumer = consumer;
            this.clientId = clientId;
            this.subscriptionId = subscriptionId;

            consumer.Listener += onMessage;
        }

        private void onMessage(IMessage message)
        {
            if (MessageHandler != null)
            {
                MessageHandler(clientId, subscriptionId, message);
            }
        }

        public void stop()
        {
            consumer.Listener -= onMessage;
            consumer.Close();
        }
    }
}
