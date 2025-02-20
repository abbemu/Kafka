
using Confluent.Kafka;

namespace KafkaMicroService.Services;
public class KafkaConsumerService
{
    // Some configurations values for the Kafka Consumer, the bootstrap servers represent the initial entry points for the cluster.
    private readonly string bootstrapServers = "localhost:9092";
    // The topic is where the messages will be consumed from, from my understanding topics are the feed where messages are published.
    private readonly string _topic = "orders";
    // The groupId is a way to manage message distribution through multiple consumers. Consumers with the same groupId load through the same partition. 
    // One could use the topic and distribute and then replicate it in a cluster which contain multiple servers called Brokers. 
    private readonly string groupId = "order-consumers";
    private readonly IConsumer<Ignore, string> _consumer;

    public KafkaConsumerService()
    {
        // Configuration for the consumer with the base settings.
        var config = new ConsumerConfig
        {
            BootstrapServers = bootstrapServers,
            GroupId = groupId,
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        _consumer = new ConsumerBuilder<Ignore, string>(config).Build();
    }

    /// <summary>
    /// Starts consuming messages from the Kafka topic in a continous loop
    /// </summary>
    /// <param name="cancellationToken">Token to control the lifetime of the consumptions</param>
    public void StartConsuming(CancellationToken cancellationToken = default)
    {
        // Start the partition assignment
        _consumer.Subscribe(_topic);
        Console.WriteLine("Listening to Kafka Messages");

        try
        {

            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    // Consumes method polls from the broker for new messages
                    var consumerResult = _consumer.Consume(cancellationToken);
                    Console.WriteLine($"Recieving order: {consumerResult.Message.Value}");
                }
                catch (OperationCanceledException)
                {
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error when listening {e.Message}");
                }
            }

        }
        finally
        {
            _consumer.Close();
        }
    }
}