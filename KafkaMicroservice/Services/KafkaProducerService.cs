using Confluent.Kafka;


namespace KafkaMicroService.Services;

/// <summary>
/// Service responsible for the publishing of message to a kafka topic. 
/// For a more production ready I would probably implement the kafka settings via appsettings.json and add all as properties instead
/// </summary>
public class KafkaProducerService
{
    private readonly string bootStrapServers = "localhost:9092";
    private readonly string _topic = "orders";

    /// <summary>
    /// Look at this beautiful ASYNC task, it will Asyncronously send a message to the Kafka topic.
    /// Uses the built in partioning strategy of Kafka for message distr.
    /// </summary>
    /// <param name="message">The message content</param>
    public async Task SendMessageAsync(string message)
    {
        var config = new ProducerConfig { BootstrapServers = bootStrapServers };

        using var producers = new ProducerBuilder<Null, string>(config).Build();

        try
        {
            // ProduceAsync sends the message to Kafka and returns a delivery report. (The null key means Kafka will use Round-robin partitioning)
            var result = await producers.ProduceAsync(_topic, new Message<Null, string> { Value = message, });
            Console.WriteLine($"Send message {message}, Partition: {result.Partition}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sending message {ex.Message}");
        }

    }
}
