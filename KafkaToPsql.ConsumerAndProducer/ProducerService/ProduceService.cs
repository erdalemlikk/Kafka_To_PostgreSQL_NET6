using Confluent.Kafka;
namespace KafkaToPsql.ConsumerAndProducer.ProducerService;

public class ProduceService : IProduceService
{
    public void Produce()
    {
        var config = new ProducerConfig() { BootstrapServers = "localhost:9092" };
        using var producer = new ProducerBuilder<Null, string>(config).Build();
        var dateTime = DateTime.Now.ToString("MMdd");
        try
		{
			for (int i = 0; i <= 10; i++)
			{
                var dr = producer.ProduceAsync("testTopic", new Message<Null, string> { Value = $"kafka_{dateTime}_{i}" }).GetAwaiter().GetResult();
                i++;
            }
        }
		catch (Exception ex)
		{
			Console.WriteLine($"Error occured at produceService : {ex.Message}");
			throw;
		}
    }
}
