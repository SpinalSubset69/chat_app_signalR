using Microsoft.AspNetCore.SignalR;
using SignalRDemoChat.Application;
using SignalRDemoChat.Application.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAppUnitOfWork();
builder.Services.AddMediatRAppHandlers();
builder.Services.AddAppDbContext(builder.Configuration.GetConnectionString("Database") ?? "");
builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: "chatCors",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("chatCors");

app.UseAuthorization();

app.MapControllers();
app.MapHub<ChatHub>("/chat-hub");

app.Run();
