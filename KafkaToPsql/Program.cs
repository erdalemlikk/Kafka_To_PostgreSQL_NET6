
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IConsumeService,ConsumeService>();
builder.Services.AddSingleton<IProduceService,ProduceService>();

// PSQL
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<TestDbContext>(opt =>
opt.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionStringPSQL")));

// Hangfire
builder.Services.AddHangfire(opt => opt.UsePostgreSqlStorage(builder.Configuration.GetConnectionString("ConnectionStringHangfire")));
builder.Services.AddHangfireServer();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Hangfire
app.UseHangfireDashboard("/hangfire");
HangfireScheduler.RecurringJobs();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
