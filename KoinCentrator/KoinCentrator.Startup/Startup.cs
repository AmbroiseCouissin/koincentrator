using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using KoinCentrator.MarketData.Providers;
using KoinCentrator.MarketData.Providers.Cryptonator;
using KoinCentrator.MarketData.Providers.CryptoCompare;
using Swashbuckle.AspNetCore.Swagger;
using KoinCentrator.Tools.Web;
using KoinCentrator.MarketData.Providers.Coinigy;
using KoinCentrator.MarketData.Controllers;
using System.Reflection;

namespace KoinCentrator.Startup
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    "v1",
                    new Info
                    {
                        Title = "KoinCentrator",
                        Version = "v1",
                        Contact = new Contact
                        {
                            Email = "ambroise.couissin@gmail.com",
                            Name = "Ambroise Couissin",
                            Url = "https://github.com/AmbroiseCouissin/koincentrator"
                        }, 
                        Description = "Just a little experience of a crypto-currency data aggregator and maybe trading models later.",
                        License = new License
                        {
                            Name = "MIT License",
                            Url = "https://github.com/AmbroiseCouissin/koincentrator/blob/master/LICENSE"
                        },
                    });
            });

            services
                .AddMvc(o =>
                {
                    o.Conventions.Add(new CommaSeparatedQueryStringConvention());
                })
                .AddApplicationPart(Assembly.Load(new AssemblyName(typeof(QuotesController).Namespace))); // because TestServer bug when controller in other project;

            // DI of quote providers
            services.AddTransient<IQuoteProvider, CryptonatorQuoteProvider>();
            services.AddTransient<IQuoteProvider, CryptoCompareQuoteProvider>();
            services.AddTransient<IQuoteProvider, CoinigyQuoteProvider>();

            // DI of exchange data providers
            services.AddTransient<IExchangeDataProvider, CoinigyExchangeDataProvider>();

            // DI of coin data providers
            services.AddTransient<ICoinDataProvider, CoinigyCoinDataProvider>();
            services.AddTransient<ICoinDataProvider, CryptoCompareCoinDataProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "KoinCentrator V1");
            });

            app.UseMvc();
        }
    }
}
