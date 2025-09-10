using EmployeeManager.RazorPages.Models;
using EmployeeManager.RazorPages.Security;
using EmployeeManager.Security;
using Microsoft.EntityFrameworkCore;



namespace EmployeeManager.RazorPages
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
            services.AddRazorPages()
              .AddRazorPagesOptions(options =>
              {
                  options.Conventions.AddPageRoute("/EmployeeManager/List", "");
              });
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("AppDb")));

      services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("AppDb")));

      services.AddIdentity<AppIdentityUser, AppIdentityRole>()
        .AddEntityFrameworkStores<AppIdentityDbContext>();

      services.ConfigureApplicationCookie(options =>
      {
        options.LoginPath = "/Security/SignIn";
        options.AccessDeniedPath = "/Security/AccessDenied";
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseStaticFiles();

      app.UseRouting();

      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {

          endpoints.MapRazorPages();
        //endpoints.MapControllerRoute(
        //          name: "default",
        //          pattern: "{controller=EmployeeManager}/{action=List}/{id?}");
      });
    }
  }
}
