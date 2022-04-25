using Cartridges.Repo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Cartridges.Repo.BuildingRepo;
using Cartridges.Repo.CartridgeIncomeRepo;
using Cartridges.Repo.CartridgeModelRepo;
using Cartridges.Repo.PrinterCompanyRepo;
using Cartridges.Repo.PrinterModelRepo;
using Cartridges.Repo.RequestRepo;
using Cartridges.Repo.DepartmentRepo;
using Cartridges.Ser.BuildingSer;
using Cartridges.Ser.CartridgeIncomeSer;
using Cartridges.Ser.CartridgeModelSer;
using Cartridges.Ser.DepartmentSer;
using Cartridges.Ser.PrinterCompanySer;
using Cartridges.Ser.PrinterModelSer;
using Cartridges.Ser.RequestSer;
using Cartridges.Repo.CartridgeModelPrinterModelRepo;
using Cartridges.Ser.CartridgeModelPrinterModelSer;
using Microsoft.AspNetCore.Http;
using System;
using Cartridges.Data;
using Microsoft.AspNetCore.Identity;
using Cartridges.Ser.BillSer;
using Cartridges.Repo.BillRepo;

namespace Cartridges
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddHsts(options =>
            {
                options.Preload = true;
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(60);
            });

            services.AddDataProtection();
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            services.AddIdentity<User, IdentityRole>(opts => {
                opts.Password.RequiredLength = 6;   // минимальная длина
                opts.Password.RequireNonAlphanumeric = true;   // требуются ли не алфавитно-цифровые символы
                opts.Password.RequireLowercase = true; // требуются ли символы в нижнем регистре
                opts.Password.RequireUppercase = true; // требуются ли символы в верхнем регистре
                opts.Password.RequireDigit = true; // требуются ли цифры
            }).AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();

            services.AddControllersWithViews();
            services.AddSession();

            //Repositories
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IBillRepo), typeof(BillRepo));
            services.AddScoped(typeof(IBuildingRepo), typeof(BuildingRepo));
            services.AddScoped(typeof(ICartridgeIncomeRepo), typeof(CartridgeIncomeRepo));
            services.AddScoped(typeof(ICartridgeModelRepo), typeof(CartridgeModelRepo));
            services.AddScoped(typeof(IDepartmentRepo), typeof(DepartmentRepo));
            services.AddScoped(typeof(IPrinterCompanyRepo), typeof(PrinterCompanyRepo));
            services.AddScoped(typeof(IPrinterModelRepo), typeof(PrinterModelRepo));
            services.AddScoped(typeof(IRequestRepo), typeof(RequestRepo));
            services.AddScoped(typeof(ICartridgeModelPrinterModelRepo), typeof(CartridgeModelPrinterModelRepo));

            //Servises
            services.AddTransient<IBillService, BillService>();
            services.AddTransient<IBuildingService, BuildingService>();
            services.AddTransient<ICartridgeIncomeService, CartridgeIncomeService>();
            services.AddTransient<ICartridgeModelService, CartridgeModelService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IPrinterCompanyService, PrinterCompanyService>();
            services.AddTransient<IPrinterModelService, PrinterModelService>();
            services.AddTransient<IRequestService, RequestService>();
            services.AddTransient<ICartridgeModelPrinterModelService, CartridgeModelPrinterModelService>();

            services.AddControllersWithViews();

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = ".AspNetCore.Identity.Application";
                options.ExpireTimeSpan = TimeSpan.FromDays(14);
                options.SlidingExpiration = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSession();

            //app.UseBrowserLink();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
