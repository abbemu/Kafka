using KafkaMicroService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. Would use an interface for production code
builder.Services.AddSingleton<KafkaProducerService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

