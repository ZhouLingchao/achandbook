using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalCrossing.Db;
using AnimalCrossing.GraphQL;
using GraphQL;
using GraphQL.Server;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AnimalCrossing
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
            services.Configure<KestrelServerOptions>(options=>options.AllowSynchronousIO=true);
            #if !DEBUG
            services.AddDbContext<ApiDbContext>(opt => opt.UseMySql(Configuration.GetSection(nameof(AppOption)).GetValue<string>(nameof(AppOption.DbConnection))).EnableRetryOnFailure());
            #endif
            #if DEBUG
            services.AddDbContext<ApiDbContext>(opt => opt.UseInMemoryDatabase(nameof(AnimalCrossing)));
            #endif
            services.AddControllers();
            services.AddTransient<IDocumentExecuter, DocumentExecuter>();
            services.AddTransient<AnimalCrossingQuery>();
            services.AddTransient<ISchema, AnimalCrossingSchema>();
            services.AddGraphQL().AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ApiDbContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseGraphQL<ISchema>();
            app.UseGraphQLPlayground();
            db.EnsureSeedData();
        }
    }
}
