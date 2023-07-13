namespace Company.Application1;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddHealthChecks();

        var app = builder.Build();

        // app.UseHttpsRedirection();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseAuthorization();

        app.UseWelcomePage("/");

        app.UseHealthChecks("/api/health");

        app.MapControllers();
        app.Run();
    }
}
