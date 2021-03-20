using MessagingService.API.Context;
using MessagingService.API.Filters;
using MessagingService.API.Services.MessageServices;
using MessagingService.API.Services.UserServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MessagingService.API.Infrastructure;
using Microsoft.AspNetCore.Mvc;
namespace MessagingService.API
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
            services.AddControllers(options =>
           {
               options.Filters.Add(typeof(JsonExceptionFilters));

           });

            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddSwaggerDocument();

            services.AddDbContext<MessagingServiceDbContext>(options =>
           {
               options.UseInMemoryDatabase("MessagingServiceDB");
           });


            services.AddScoped<MessagingServiceDbContext>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMessageService, MessageService>();

            
           // services.AddAutoMapper(option =>
           //{
           //    option.AddProfile<MappingProfile>();
           //});
            
            
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerUi3();
                app.UseOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
