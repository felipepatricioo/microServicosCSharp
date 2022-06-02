using eBookShopping.MessageBus;

namespace eBookShopping.CartAPI.RabbitMQSender
{
    public interface IRabbitMQMessageSender
    {

        void SendMessage(BaseMessage message, string queueName);

    }
}
