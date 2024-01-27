
using JPWebApplication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<CustomMiddleware>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseDeveloperExceptionPage();

app.UseMiddleware<CustomMiddleware>();

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("middeleware 1 \n");
    await next();
});

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("middeleware 2 \n");
    await next();
});

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("middeleware 3 \n");
    await next();
});

app.Map("/jptest", CustomMap);

void CustomMap(IApplicationBuilder app)
{
    app.Use(async (context, next) =>
    {
        await context.Response.WriteAsync("jptest is not implemented");
        await next();
    });
}

app.Run();
