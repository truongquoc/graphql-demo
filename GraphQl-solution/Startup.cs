using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using GraphQl_solution.Database;
using GraphQl_solution.GraphQL;
using GraphQl_solution.Infrastructure;
using GraphQl_solution.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace GraphQl_solution
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
            //services.AddControllers();
            services.AddMvc();
            services.AddDbContext<ApplicationDbContext>(context =>
            {
                context.UseInMemoryDatabase("database");
            });
            //services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            //services.AddSingleton<AuthorRepository>();
            //services.AddSingleton<AuthorService>();
            services.AddSingleton<AuthorType>();
            services.AddSingleton<AuthorQuery>();
            //services.AddScoped<IDependenc>
            // services.AddGraphQL(o => {}).AddGraphTypes(ServiceLifetime.Scoped);
            //services.AddSingleton<ISchema>(new FuncDependencyResolver))
            //services.AddGraphQL(o => { o.ExposeExceptions = false; })
            //   .AddGraphTypes(ServiceLifetime.Scoped);
            services.AddSingleton<ISchema, AuthorSchema>();
            services.AddGraphQL(options =>
            {
                options.EnableMetrics = true;
            })
             .AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = true).
             AddSystemTextJson();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            //app.UseRouting();

            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
            app.UseGraphQL<ISchema>();

            app.UseGraphQLPlayground(new PlaygroundOptions());
        }
    }
}
