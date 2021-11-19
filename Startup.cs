using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.SpaServices.AngularCli;

// using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
// using ReceivableSecurity.Services;
using ClaroTechTest1.Models;
using ClaroTechTest1.Services;

namespace ClaroTechTest1
{
    public class Startup
    {
        private readonly string _Cors = "Cors";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "wwwroot";
            });
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                    Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.XForwardedFor | Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.XForwardedProto;
            });
        
            string sqlConnection = Configuration["Data:ConnectionString"];
            string serverVersion = Configuration["Data:ServerVersion"];
            // Entity Framework
            services.AddDbContext<XorDbContext>(options => options.UseSqlServer(sqlConnection));
            services.AddControllers();
            services.AddTransient<IGeneralService, GeneralService>();
            // services.AddTransient<IReportService, ReportService>();
            // services.AddTransient<IGuReportService, GuReportService>();
            // services.AddTransient<IToolService, ToolService>();
            services.AddTransient<IProdService, ProdService>();
            // services.AddTransient<IResiService, ResiService>();
            // services.AddTransient<IReceivableService, ReceivableService>();


            // services.AddEntityFrameworkMySql();
            services.AddCors(option => {
                option.AddPolicy(name: _Cors, builder => {
                    // builder.WithOrigins("http://www.donorencio8.com/session/login");
                    builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost").AllowAnyHeader().AllowAnyMethod();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseForwardedHeaders();
            
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //https://forums.asp.net/t/2156516.aspx?Serve+multiple+angular+spa+from+a+single+core+web+application

            /*
            * Default file
            */
            var options = new DefaultFilesOptions();
            // options.DefaultFileNames.Clear();
            // options.DefaultFileNames.Add("session/index.html");
            // // options.
            app.UseDefaultFiles(options);
            app.UseSpaStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"))
            });
            app.UseCors(_Cors);

            // app.Map("/session", client =>
            // {
            //     client.UseSpa(spa =>
            //     {
            //         spa.Options.SourcePath = "wwwroot/session";
            //         spa.Options.DefaultPageStaticFileOptions = new StaticFileOptions
            //         {
            //             FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/session"))
            //         };
            //     });
            // }).Map("/rs", client =>
            // {
            //     client.UseSpa(spa =>
            //     {
            //         spa.Options.SourcePath = "wwwroot/rs";
            //         spa.Options.DefaultPageStaticFileOptions = new StaticFileOptions
            //         {
            //             FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/rs"))
            //         };
            //     });
            // });




        }
    }
}