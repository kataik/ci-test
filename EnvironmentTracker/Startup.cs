﻿// <copyright file="Startup.cs" company="ELTE">
// Copyright (c) 2017, ELTE. All rights reserved.
// Licensed under the MIT license.
// </copyright>

namespace EnvironmentTracker
{
    using System.IO;
    using EnvironmentInfoProvider;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Storage;

    /// <summary>
    /// Spins up and configures the CLI application services.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true);

            this.Configuration = builder.Build();
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public IConfigurationRoot Configuration { get; }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSingleton(
                    new LoggerFactory()
                    .AddConsole()
                    .AddDebug())
                .AddLogging()
                .AddSingleton<IEnvironmentInfoProvider, DefaultEnvironmentInfoProvider>()
                .AddSingleton(typeof(IStorage<>), typeof(FileStorage<>))
                .AddSingleton(this.GetConfiguration())
                .AddSingleton<EnvironmentTracker>();
        }

        private FileStorageConfiguration GetConfiguration()
        {
            var result = new FileStorageConfiguration();
            this.Configuration.Bind(result);

            return result;
        }
    }
}
