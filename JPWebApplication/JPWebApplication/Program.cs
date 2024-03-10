using JPWebApplication.CustomMiddelware;
using JPWebApplication.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddTransient<CustomMiddleware>();
        builder.Services.AddTransient<ErrorMessageMiddleware>();
        builder.Services.AddControllers();
        //builder.Services.AddSingleton<IEmployeeModel, EmployeeModel>();
        //builder.Services.AddScoped<IEmployeeModel, EmployeeModel>();
        builder.Services.AddTransient<IEmployeeModel, EmployeeModel>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();

        app.UseDeveloperExceptionPage();

        app.Map("/errorX", CallErrorMiddleware);
        app.Map("/jptest", CustomMap);
        //app.UseMiddleware<CustomMiddleware>();
        app.Use(async (context, next) =>
        {
            //await context.Response.WriteAsync("middeleware 1 \n");

            if (context.Request.Path == "/Hello")
                context.Request.Path = "/test/WeatherForecast/Get";
            string myString = "Hello, this is a string.";
            await next.Invoke();
        });

        //app.Use(async (context, next) =>
        //{
        //    await context.Response.WriteAsync("middeleware 2 \n");
        //    await next();
        //});

        //app.Use(async (context, next) =>
        //{
        //    await context.Response.WriteAsync("middeleware 3 \n");
        //    await next();
        //});

        //app.Use(async (context, next) =>
        //{
        //    await context.Response.WriteAsync("hey there");

        //    await next();
        //});


        void CallErrorMiddleware(IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorMessageMiddleware>();
            app.Run(async context => { });
        }

        void CustomMap(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("jptest is not implemented");
                await next();
            });
        }

        app.UseRouting();
        app.MapControllers();
        app.MapDefaultControllerRoute();
        app.MapFallbackToController("GetError", "ErrorHandler");
        app.Run();
    }
}