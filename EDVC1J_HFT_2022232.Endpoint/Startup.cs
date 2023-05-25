using EDVC1J_HFT_2022232.Data;
using EDVC1J_HFT_2022232.Logic;
using EDVC1J_HFT_2022232.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDVC1J_HFT_2022232.Endpoint
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddTransient<IRestaurantLogic, RestaurantLogic>();
            services.AddTransient<IChefLogic, ChefLogic>();
            services.AddTransient<IReceiptLogic, ReceiptLogic>();

            services.AddTransient<IChefRepository, ChefRepository>();
            services.AddTransient<IRestaurantRepository, RestaurantRepository>();
            services.AddTransient<IReceiptRepository, ReceiptRepository>();

            services.AddTransient<RestaurantDbContext, RestaurantDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
