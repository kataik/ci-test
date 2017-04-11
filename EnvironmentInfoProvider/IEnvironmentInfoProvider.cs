// <copyright file="IEnvironmentInfoProvider.cs" company="ELTE">
// Copyright (c) 2017, ELTE. All rights reserved.
// Licensed under the MIT license.
// </copyright>

namespace EnvironmentInfoProvider
{
    /// <summary>
    /// Provides environment information.
    /// </summary>
    public interface IEnvironmentInfoProvider
    {
        /// <summary>
        /// Gets the environment information.
        /// </summary>
        /// <returns>The environment information.</returns>
        EnvironmentInfo GetEnvironmentInfo();
    }
}
