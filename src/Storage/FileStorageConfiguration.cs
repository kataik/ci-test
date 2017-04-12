// <copyright file="FileStorageConfiguration.cs" company="ELTE">
// Copyright (c) 2017, ELTE. All rights reserved.
// Licensed under the MIT license.
// </copyright>

namespace Storage
{
    /// <summary>
    /// Configuration object for the <see cref="FileStorage{T}"/> class.
    /// </summary>
    public class FileStorageConfiguration
    {
        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        /// <value>
        /// The path.
        /// </value>
        public string Path { get; set; }
    }
}
