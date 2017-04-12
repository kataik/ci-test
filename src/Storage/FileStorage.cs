// <copyright file="FileStorage.cs" company="ELTE">
// Copyright (c) 2017, ELTE. All rights reserved.
// Licensed under the MIT license.
// </copyright>

namespace Storage
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents a file base storage.
    /// </summary>
    /// <typeparam name="T">The type of the data stored in this storage.</typeparam>
    /// <seealso cref="Storage.IStorage{T}" />
    public class FileStorage<T> : IStorage<T>
        where T : class
    {
        private readonly FileStorageConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileStorage{T}" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public FileStorage(FileStorageConfiguration configuration)
        {
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public FileStorageConfiguration Configuration => this.configuration;

        /// <summary>
        /// Retreives all data in the storage.
        /// </summary>
        /// <returns>The data in the storage.</returns>
        public IEnumerable<T> RetreiveData()
        {
            return File.Exists(this.configuration.Path) ? JsonConvert.DeserializeObject<IEnumerable<T>>(File.ReadAllText(this.configuration.Path)) : Enumerable.Empty<T>();
        }

        /// <summary>
        /// Appends the specified data into the storage.
        /// </summary>
        /// <param name="data">The data.</param>
        public void AppendData(T data)
        {
            var items = this.RetreiveData().ToList();
            items.Add(data);

            File.WriteAllText(this.configuration.Path, JsonConvert.SerializeObject(items));
        }
    }
}
