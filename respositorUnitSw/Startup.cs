using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using NLog.Web;
using respositorUnitSw.Implementation;
using respositorUnitSw.Interface;
using respositorUnitSw.Model;
using respositorUnitSw.Service;

namespace respositorUnitSw
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
            var connection = @"Server=localhost\sqlexpress;Database=testsw;Trusted_Connection=True;ConnectRetryCount=0";

            services.AddDbContext<DatabaseContext>(context => { context.UseInMemoryDatabase("ConferencePlanner"); });
            //services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connection));

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IPersonService, PersonService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        private void AddTestData(DatabaseContext context)
        {
            int k = 23;

            Order o = new Order();
            o.Name = "Order name";
            o.Person = new Person() { Age = 11, Name = "Perso Name" };
            context.Orders.Add(o);
            context.SaveChanges();
        }

        private string RandomString(int v)
        {
            string r = System.Guid.NewGuid().ToString();
            return r.Substring(0, v);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            env.ConfigureNLog("nlog.config");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            loggerFactory.AddNLog();

            //add NLog.Web
            app.AddNLogWeb();
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DatabaseContext>();
                AddTestData(context);
                // Seed the database.
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
