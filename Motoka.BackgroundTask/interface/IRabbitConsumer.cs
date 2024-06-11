namespace Motoka.BackgroundTask.Interface
{
    public interface IRabbitConsumer
    {
        void Start(string queueName);

    }
}
