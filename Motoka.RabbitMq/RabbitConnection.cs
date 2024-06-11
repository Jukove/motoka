using Microsoft.Extensions.Options;
using Motoka.RabbitMq.Interfaces;
using Motoka.RabbitMq.ObjectValues;
using RabbitMQ.Client;
using System;

namespace Motoka.RabbitMq
{
    public class RabbitConnection : IRabbitConnection
    {
        private readonly IConnectionFactory _connectionFactory;
        private IConnection _connection;
        public bool IsConnected => _connection != null && _connection.IsOpen;
        public RabbitConnection(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public bool TryConnection()
        {

            _connection = _connectionFactory.CreateConnection();
            return IsConnected;
        }

        public IModel CreateModel()
        {
            if (!IsConnected)
            {
                throw new InvalidOperationException("No RabbitMQ connections are available to perform this action");
            }

            return _connection.CreateModel();
        }
    }
}
