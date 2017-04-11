// <copyright file="EnvironmentTracker.cs" company="ELTE">
// Copyright (c) 2017, ELTE. All rights reserved.
// Licensed under the MIT license.
// </copyright>

namespace EnvironmentTracker
{
    using System;
    using EnvironmentInfoProvider;
    using Microsoft.Extensions.Logging;
    using Storage;

    /// <summary>
    /// Executes and stores the environment tracking process.
    /// </summary>
    public class EnvironmentTracker
    {
        private readonly IEnvironmentInfoProvider environmentInfoProvider;
        private readonly IStorage<EnvironmentInfo> storage;
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="EnvironmentTracker" /> class.
        /// </summary>
        /// <param name="environmentInfoProvider">The environment information provider.</param>
        /// <param name="storage">The storage.</param>
        /// <param name="loggerFactory">The logger factory.</param>
        public EnvironmentTracker(
                    IEnvironmentInfoProvider environmentInfoProvider,
                    IStorage<EnvironmentInfo> storage,
                    ILoggerFactory loggerFactory)
        {
            this.environmentInfoProvider = environmentInfoProvider ?? throw new ArgumentNullException(nameof(environmentInfoProvider));
            this.storage = storage ?? throw new ArgumentNullException(nameof(storage));
            this.logger = loggerFactory?.CreateLogger<EnvironmentTracker>() ?? throw new ArgumentNullException(nameof(loggerFactory));
        }

        /// <summary>
        /// Executes the tracking process.
        /// </summary>
        public void Process()
        {
            var info = this.environmentInfoProvider.GetEnvironmentInfo();

            this.logger.LogInformation($"Writing os: {info.Os}, processor: {info.ProcessorArchitecture}, runtime: {info.Runtime} to storage...");

            this.storage.AppendData(info);

            this.logger.LogInformation("Done.");
        }
    }
}
