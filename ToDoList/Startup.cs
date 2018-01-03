using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace ToDoList
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.

        public void ConfigureServices(IServiceCollection services)
        {
			services.AddMvc();
			services.AddEntityFrameworkMySql()
			.AddDbContext<ToDoListContext>(options =>
									  options
										   .UseMySql(Configuration["ConnectionStrings:DefaultConnection"]));
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
			app.UseStaticFiles();
			app.UseMvc(routes =>
			{
				routes.MapRoute(
				  name: "default",
				  template: "{controller=Home}/{action=Index}/{id?}");
			});

            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
			  .SetBasePath(env.ContentRootPath)
			  .AddJsonFile("appsettings.json");
			Configuration = builder.Build();
		}
		
    }
}
