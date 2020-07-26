using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using MessagePack.AspNetCoreMvcFormatter;
using MessagePack.Resolvers;
using MessagePack;
using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;

namespace Greetings {
 
    public class Startup {
        public void ConfigureServices (IServiceCollection services) {
            services.AddControllers ();
          
            services.AddMvc().AddMvcOptions(option =>
            {
                 option.OutputFormatters.Add(new MessagePackOutputFormatter(ContractlessStandardResolver.Options));
                 option.InputFormatters.Add(new MessagePackInputFormatter(ContractlessStandardResolver.Options));
            });

            services.AddResponseCompression();

            //services.Configure<BrotliCompressionProviderOptions>(options => options.Level = CompressionLevel.Optimal);
            services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Optimal);
            services.AddResponseCompression(options => {
                options.MimeTypes = new string[]{
                    "text/html",
                    "text/css",
                    "application/javascript",
                    "application/json",
                    "application/x-msgpack"
                };
            });

        }

        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }

            app.UseResponseCompression();

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