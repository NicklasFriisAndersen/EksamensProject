using ServerAPI.Repositories;

namespace ServerAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddSingleton<ILoginRepository, LoginRepository>();
        builder.Services.AddSingleton<IUserrepository, UserRepository>();
        builder.Services.AddSingleton<IU18VolunteerRepository, U18VolunteerRepository>();

        builder.Services.AddControllers();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("policy",
                              policy =>
                              {
                                  policy.AllowAnyOrigin();
                                  policy.AllowAnyMethod();
                                  policy.AllowAnyHeader();
                              });
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();

        app.UseAuthorization();
        
        app.UseCors("policy");

        app.MapControllers();

        app.Run();
    }
}

