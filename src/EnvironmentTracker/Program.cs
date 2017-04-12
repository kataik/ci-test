// <copyright file="Program.cs" company="ELTE">
// Copyright (c) 2017, ELTE. All rights reserved.
// Licensed under the MIT license.
// </copyright>

namespace EnvironmentTracker
{
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Contains the entry point of the application.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        private static void Main(string[] args)
        {
            var services = new ServiceCollection();
            var startup = new Startup();

            startup.ConfigureServices(services);

            var provider = services.BuildServiceProvider();

            provider.GetService<EnvironmentTracker>().Process();
        }
    }
}