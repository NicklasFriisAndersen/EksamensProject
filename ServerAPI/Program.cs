using ServerAPI.Repositories;

namespace ServerAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddSingleton<IRegisteredChildRepository, RegisteredChildRepository>();

        builder.Services.AddSingleton<ILoginRepository, LoginRepository>();
        builder.Services.AddSingleton<IUserrepository, UserRepository>();
        builder.Services.AddSingleton<IU18VolunteerRepository, U18VolunteerRepository>();
        builder.Services.AddSingleton<IPeriodRepository, PeriodRepository>();


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

        app.UseHttpsRedirection();

        app.UseCors("policy");

        app.UseAuthorization();
        
        app.UseCors("policy");

        app.MapControllers();

        app.Run();
    }
}

