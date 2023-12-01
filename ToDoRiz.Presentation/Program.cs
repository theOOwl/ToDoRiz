using Application.Service.ServiceImplementation;
using Application.Service.ServiceInterface;
using Domain.RepoInterface;
using Infrastructure.RepoImplementation;
using Infrastructure.ToDoRiz;

namespace ToDoRiz.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add Repositories to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ToDoRizDb>();
            builder.Services.AddScoped<ITasksRepo, TasksRepo>();
            builder.Services.AddScoped<IUsersRepo, UserRepo>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<ITaskService, TaskService>();
            builder.Services.AddScoped<IUserService, UserService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=Login}/{id?}");

            app.Run();
        }
    }
}