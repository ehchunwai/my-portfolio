using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using myportfolio.Database;
using myportfolio.Modules;
using System;
using System.Collections.Generic;
using System.IO;

namespace myportfolio
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
            services.AddCors(o => o.AddPolicy("AllowAnyCorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddControllersWithViews();
            ////to enable runtime compile razor view required by browese link
            services.AddRazorPages().AddRazorRuntimeCompilation();

            services.AddSingleton<SkillsService>();
            services.AddSingleton<TestimonialService>();
            services.AddSingleton<WorkExperienceService>();
            services.AddSingleton<AboutService>();
            services.AddSingleton<ProjectService>();

            ConfigureDbStore(services);
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCors("AllowAnyCorsPolicy");
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Views")),
                RequestPath = new PathString("/Views"),
                ContentTypeProvider = new FileExtensionContentTypeProvider(
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                                { ".js", "application/javascript" },
                                { ".css", "text/css" }
            })
            });
        }

        private void ConfigureDbStore(IServiceCollection services)
        {
            services.AddSingleton(typeof(IStoreSkills), typeof(StoreSkills));
            services.AddSingleton(typeof(IStoreTestimonial), typeof(StoreTestimonial));
            services.AddSingleton(typeof(IStoreWorkExperience), typeof(StoreWorkExperience));
            services.AddSingleton(typeof(IStoreProfile), typeof(StoreProfile));
            services.AddSingleton(typeof(IStoreProject), typeof(StoreProject));
        }
    }
}
