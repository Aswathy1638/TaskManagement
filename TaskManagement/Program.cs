using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Controllers;
using TaskManagement.Data;
using static TaskManagement.Controllers.NotificationsController;

public class Program
{
        
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer("Data source=task.db");
            });
        builder.Services.AddAuthorization();
        builder.Services.AddControllers();


        builder.Services.AddScoped<TaskManagement.Controllers.UsersController>();
        builder.Services.AddScoped<TaskManagement.Controllers.TaskController>();
       builder.Services.AddScoped<TaskManagement.Controllers.CommentsController>();
        builder.Services.AddScoped<TaskManagement.Controllers.NotificationsController.NotificationController>();

        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.Name = "YourAppCookieName";
                    options.LoginPath = "/Account/Login";
                    options.LogoutPath = "/Account/Logout";
                });

            var app = builder.Build();

            app.UseMiddleware<ErrorHandlingMiddleware>();

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });


        app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run(async context =>
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsync("Page not found.");
            });

            app.Run();
        }
}
   