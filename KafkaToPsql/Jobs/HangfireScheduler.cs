namespace KafkaToPsql.Jobs;

public static class HangfireScheduler
{
    public static void RecurringJobs()
    {
        RecurringJob.RemoveIfExists(nameof(ProduceJob));
        RecurringJob.AddOrUpdate<ProduceJob>(nameof(ProduceJob), job => job.Produce(), "10 * * * *");

        RecurringJob.RemoveIfExists(nameof(ConsumeJob));
        RecurringJob.AddOrUpdate<ConsumeJob>(nameof(ConsumeJob), job => job.Consume(), "20 * * * *");
    }
}
