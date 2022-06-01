using eBookShopping.MessageBus;

namespace eBookShopping.OrderAPI.RabbitMQSender
{
    public interface IRabbitMQMessageSender
    {

        void SendMessage(BaseMessage message, string queueName);

    }
}
