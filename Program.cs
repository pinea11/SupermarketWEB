using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;

namespace SupermarketWEB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddAuthentication("MyCookieAuth")
                .AddCookie("MyCookieAuth", config =>
                {
                    config.Cookie.Name = "MyCookieAuth";
                    config.LoginPath = "/Account/Login";
                });

            //Agregando el contexto SupermarketContext a la aplicacion
            builder.Services.AddDbContext<SupermarketContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("SupermarketDB"))
            );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication(); // <-- �Muy importante!
            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapRazorPages().WithStaticAssets();

            app.Run();
        }
    }
}
