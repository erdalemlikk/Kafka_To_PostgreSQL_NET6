namespace KafkaToPsql.Jobs.KafkaProducerJob
{
    public class ProduceJob : IProduceJob
    {
        private readonly IProduceService _produceService;
        public ProduceJob(IProduceService _produceService)
        {
            this._produceService = _produceService;
        }
        public void Produce()
            =>  _produceService.Produce();
    }
}
