// <copyright file="IStorage.cs" company="ELTE">
// Copyright (c) 2017, ELTE. All rights reserved.
// Licensed under the MIT license.
// </copyright>

namespace Storage
{
    /// <summary>
    /// Represents a storage.
    /// </summary>
    /// <typeparam name="T">The type of the data stored in this storage.</typeparam>
    public interface IStorage<T>
        where T : class
    {
        /// <summary>
        /// Appends the specified data into the storage.
        /// </summary>
        /// <param name="data">The data.</param>
        void AppendData(T data);
    }
}
