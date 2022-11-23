namespace KafkaToPsql.Jobs.KafkaConsumerJob
{
    public class ConsumeJob : IConsumeJob
    {
        private readonly IConsumeService _consumeService;
        private readonly TestDbContext _dbContext;
        public ConsumeJob(IConsumeService _consumeService,
                          TestDbContext _dbContext)
        {
            this._consumeService= _consumeService;
            this._dbContext= _dbContext;
        }
        public void Consume()
        {
            var valueList = _consumeService.Consume();
            var dbList = new List<TestModel>();
            if (valueList.Count != 0)
            {
                valueList.ForEach(kafkaVal => dbList.Add(new TestModel
                {
                    Id = Guid.NewGuid().ToString(),KafkaValue = kafkaVal
                }));
                _dbContext.TestModels.AddRange(dbList);
                _dbContext.SaveChanges();   
            }
        }
    }
}
