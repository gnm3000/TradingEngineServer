using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using TradingEngineServer.Core.Configuration;
namespace TradingEngineServer.Core
{
    public sealed class TradingEngineServerHostBuilder // sealed so nobody can overwrite.
    {
        public static IHost BuildTradingEngineServer()
            => Host.CreateDefaultBuilder().ConfigureServices((context,services) => 
            {
                // lambda function
                // Start with configuration
                services.AddOptions();
                services.Configure<TradingEngineServerConfiguration>(context.Configuration.GetSection(nameof(TradingEngineServerConfiguration)));

                // add signeton objects
                services.AddSingleton<ITradingEngineServer, TradingEngineServer>();
                //services.AddScoped<ITradingEngineServer, TradingEngineServer>();

                services.AddHostedService<TradingEngineServer>();


            }).Build();
    }
}
