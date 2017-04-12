// <copyright file="LocatorExtensions.cs" company="ELTE">
// Copyright (c) 2017, ELTE. All rights reserved.
// Licensed under the MIT license.
// </copyright>

namespace EnvironmentTracker
{
    using System;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Extension methods for automatical service resolution.
    /// </summary>
    public static class LocatorExtensions
    {
        /// <summary>
        /// Attempts to resolve services based on the specified configuration.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="registerTransient">If set to <c>true</c> the service gets registered in transient mode; otherwise singleton mode is used.</param>
        /// <returns>
        /// The extended services.
        /// </returns>
        public static IServiceCollection AutoResolveServices(this IServiceCollection services, IConfiguration configuration, bool registerTransient = false)
        {
            foreach (var serviceSection in configuration.GetChildren())
            {
                var serviceType = Type.GetType(serviceSection.Key);

                if (serviceSection.Value != null)
                {
                    if (registerTransient)
                        services.AddTransient(serviceType, Type.GetType(serviceSection.Value));
                    else
                        services.AddSingleton(serviceType, Type.GetType(serviceSection.Value));

                    continue;
                }

                var instance = Activator.CreateInstance(serviceType);
                serviceSection.Bind(instance);

                services.AddSingleton(serviceType, instance);
            }

            return services;
        }
    }
}
