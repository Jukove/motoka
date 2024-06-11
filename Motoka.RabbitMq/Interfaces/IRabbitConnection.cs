using RabbitMQ.Client;

namespace Motoka.RabbitMq.Interfaces
{
    public interface IRabbitConnection
    {
        bool TryConnection();
        IModel CreateModel();
        bool  IsConnected { get;}
    }
}
