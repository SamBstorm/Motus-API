
using Motus_DataAccessLayer;
using Motus_DataAccessLayer.Services;

namespace Motus_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IMotusRepository,MotusService>();

            // Add services to the container.

            builder.Services.AddControllers()
                .AddXmlDataContractSerializerFormatters();

            builder.Services.AddCors(
                options => {
                    options.AddDefaultPolicy(policy =>
                    {
                        policy.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyHeader();
                    });
                });

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

            app.UseHttpsRedirection();

            app.UseCors("default");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
