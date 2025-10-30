
using API.Middlewares;
using Application.Extensions;
using Infrastructure;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            builder.Services.AddControllers();
            
            builder.Services.AddApplication();
            
            builder.Services.AddInfrastructure(builder.Configuration);
          
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddTransient<ErrorHandelingMiddeware>();

            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowClient", policy =>
                {
                    policy.WithOrigins("http://localhost:4200") // your Angular app URL
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });


            var app = builder.Build();
            app.UseCors("AllowClient");
            app.UseMiddleware<ErrorHandelingMiddeware>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
