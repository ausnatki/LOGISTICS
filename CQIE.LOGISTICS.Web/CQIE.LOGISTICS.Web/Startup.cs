using CQIE.LOG.Models.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQIE.LOGISTICS.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.

        //���÷���
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddRazorPages();

            services.AddControllersWithViews();
            //LOGDB���ݿ���
            services.AddDbContext<CQIE.LOG.DBManager.LOGDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("LOGDB")));

            services.AddDefaultIdentity<CQIE.LOG.Models.Identity.SysUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddRoles<SysRole>()
                    .AddEntityFrameworkStores<CQIE.LOG.DBManager.LOGDbContext>();

            services.AddRazorPages().AddRazorRuntimeCompilation();//���ʵʱԤ��

            #region ע��ORM�����
            services.AddSingleton(typeof(CQIE.LOG.Utility.ConfigService));//singleton��ʽת��Ҫ��typeof
            services.AddScoped(typeof(CQIE.LOG.DBManager.LOGDbContext));
            services.AddScoped<CQIE.LOG.DBManager.IDbManager, CQIE.LOG.DBManager.DbManagerImp>();
            //services.AddScoped(typeof())
            #endregion

            services.AddScoped<CQIE.LOG.Services.ISystemMenuService, CQIE.LOG.Services.ISystemMenuServiceImp>();
            services.AddScoped<CQIE.LOG.Services.IUserService, CQIE.LOG.Services.UserServiceImp>();
            services.AddScoped<CQIE.LOG.Services.IRoleService, CQIE.LOG.Services.RoleServiceImp>();
            services.AddScoped<CQIE.LOG.Services.ITool, CQIE.LOG.Services.IToolImp>();
            services.AddScoped<CQIE.LOG.Services.ISysWayBill, CQIE.LOG.Services.SysWayBillImp>();
            services.AddScoped<CQIE.LOG.Services.ISysDelivery, CQIE.LOG.Services.SysDeliveryImp>();
            services.AddScoped<CQIE.LOG.Services.ISysExpenses, CQIE.LOG.Services.SysExpensesImp>();
            services.AddScoped<CQIE.LOG.Services.ISysCar, CQIE.LOG.Services.SysCarImp>();


            //�����ڴ滺��
            services.AddDistributedMemoryCache();

            services.AddSession(config =>
            {
                config.Cookie.IsEssential = true;
                config.Cookie.Name = ".CQIE.LOG.Web.session";
                config.Cookie.HttpOnly = true;
                config.IdleTimeout = System.TimeSpan.FromMinutes(30);
            });
            services.AddScoped(typeof(CQIE.LOG.Models.SessionService));

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.Configure<IdentityOptions>(options =>
            {
                //�����趨
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                //�����趨
                options.Lockout.DefaultLockoutTimeSpan = System.TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                //�û��趨
                options.User.AllowedUserNameCharacters = "qwertyuiopasdfghjklzxcvbnm-._@+QWERTYUIOPASDFGHJKLZXCVBNM";
                options.User.RequireUniqueEmail = false;
            });
            services.ConfigureApplicationCookie(option =>
            {
                //cookie�趨
                option.Cookie.HttpOnly = true;
                option.ExpireTimeSpan = System.TimeSpan.FromMinutes(5);
                option.LoginPath = "/Account/Login";
                option.AccessDeniedPath = "/Account/AccessDenied";
                option.SlidingExpiration = true;
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCookiePolicy();
            app.UseSession();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default2",
                    pattern: "{controller}/{action}/{id?}");
            });
        }
    }
}
