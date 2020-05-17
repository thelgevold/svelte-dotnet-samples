using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace Greetings {
    public class Startup {
        public void ConfigureServices (IServiceCollection services) {
            services.AddControllers ();
        }

        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }

            app.UseDefaultFiles ();
            app.UseStaticFiles (new StaticFileOptions {
                FileProvider = new PhysicalFileProvider (Path.Combine (env.ContentRootPath, ".")), RequestPath = "/static"
            });
 
            app.UseRouting ();

            app.UseEndpoints (endpoints => {
                endpoints.MapControllers ();
            });
        }
    }
}