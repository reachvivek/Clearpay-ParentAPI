var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors((options) =>
{
    options.AddPolicy("Cors", (corsBuilder) =>
    {
        corsBuilder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("Cors");
// app.UseHttpsRedirection();

var configuration = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json")
           .Build();

app.Urls.Add(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("URL")["CURRENTURL"]!);

app.UseAuthorization();

app.MapControllers();

app.Run();
