// <copyright file="EnvironmentInfo.cs" company="ELTE">
// Copyright (c) 2017, ELTE. All rights reserved.
// Licensed under the MIT license.
// </copyright>

namespace EnvironmentInfoProvider
{
    /// <summary>
    /// Represents an environment.
    /// </summary>
    public class EnvironmentInfo
    {
        private readonly string runtime;
        private readonly string os;
        private readonly string processorArchitecture;

        /// <summary>
        /// Initializes a new instance of the <see cref="EnvironmentInfo"/> class.
        /// </summary>
        /// <param name="runtime">The runtime.</param>
        /// <param name="os">The os.</param>
        /// <param name="processorArchitecture">The processor architecture.</param>
        public EnvironmentInfo(string runtime, string os, string processorArchitecture)
        {
            this.runtime = runtime;
            this.os = os;
            this.processorArchitecture = processorArchitecture;
        }

        /// <summary>
        /// Gets the runtime.
        /// </summary>
        public string Runtime => this.runtime;

        /// <summary>
        /// Gets the os.
        /// </summary>
        public string Os => this.os;

        /// <summary>
        /// Gets the processor architecture.
        /// </summary>
        public string ProcessorArchitecture => this.processorArchitecture;
    }
}
