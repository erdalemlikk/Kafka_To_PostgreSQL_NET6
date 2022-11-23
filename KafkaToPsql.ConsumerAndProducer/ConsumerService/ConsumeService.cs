using Confluent.Kafka;

namespace KafkaToPsql.ConsumerAndProducer.ConsumerService;

public class ConsumeService : IConsumeService
{
    public List<string> Consume()
    {
        List<string> valueList = new();
        var config = new ConsumerConfig
        {
            GroupId = "kafkaTestTopicGroup",
            BootstrapServers = "localhost:9092",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };
        using var consume = new ConsumerBuilder<Ignore, string>(config).Build();
        consume.Subscribe("testTopic");
        while (true)
        {
            try
            {
                var cr = consume.Consume();
                Console.WriteLine($"{cr.Value} consumed at {DateTime.Now}");
                valueList.Add(cr.Value);
                if (valueList.Count == 10)
                    return valueList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured. Error is : {ex.Message}");
                consume.Close();
                return valueList;
            }
        }
    }
}
