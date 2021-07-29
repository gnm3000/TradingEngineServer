﻿using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using System;
using System.Threading;
using System.Threading.Tasks;

using TradingEngineServer.Core.Configuration;
namespace TradingEngineServer.Core
{
    sealed class TradingEngineServer : BackgroundService, ITradingEngineServer
    {
        private readonly ILogger<TradingEngineServer> _logger;
        private readonly TradingEngineServerConfiguration _tradingEngineServerConfig;

        public TradingEngineServer(ILogger<TradingEngineServer> logger,IOptions<TradingEngineServerConfiguration> config)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _tradingEngineServerConfig = config.Value ?? throw new ArgumentNullException(nameof(config)); // si es null ejecuta ArgumentNullException.
        }

        public Task Run(CancellationToken token) => ExecuteAsync(token);

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"started {nameof(TradingEngineServer)}");
            //throw new System.NotImplementedException();
            while (!stoppingToken.IsCancellationRequested) {
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                cancellationTokenSource.Cancel();
                cancellationTokenSource.Dispose();

            }
            _logger.LogInformation($"stopped {nameof(TradingEngineServer)}");
            return Task.CompletedTask;
        }
    }
}
