// <copyright file="DefaultEnvironmentInfoProvider.cs" company="ELTE">
// Copyright (c) 2017, ELTE. All rights reserved.
// Licensed under the MIT license.
// </copyright>

namespace EnvironmentInfoProvider
{
    using System.Runtime.InteropServices;

    /// <summary>
    /// Provides environment information about the machine it is executed on.
    /// </summary>
    /// <seealso cref="EnvironmentInfoProvider.IEnvironmentInfoProvider" />
    public class DefaultEnvironmentInfoProvider : IEnvironmentInfoProvider
    {
        /// <summary>
        /// Gets the environment information.
        /// </summary>
        /// <returns>
        /// The environment information.
        /// </returns>
        public EnvironmentInfo GetEnvironmentInfo()
        {
            return new EnvironmentInfo(RuntimeInformation.FrameworkDescription, RuntimeInformation.OSDescription, RuntimeInformation.OSArchitecture.ToString());
        }
    }
}
