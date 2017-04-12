// <copyright file="FileStorageTests.cs" company="ELTE">
// Copyright (c) 2017, ELTE. All rights reserved.
// Licensed under the MIT license.
// </copyright>

namespace StorageTests
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Storage;

    /// <summary>
    /// Represents unit test cases for the <see cref="FileStorage{T}"/> class.
    /// </summary>
    [TestClass]
    public class FileStorageTests
    {
        private const string TestPath = "test.json";
        private FileStorage<TestData> storage;

        /// <summary>
        /// Initializes this instance before each test case execution.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            this.storage = new FileStorage<TestData>(new FileStorageConfiguration { Path = TestPath });
        }

        /// <summary>
        /// Restores the clean state of the test subject.
        /// </summary>
        [TestCleanup]
        public void Cleanup()
        {
            File.Delete(TestPath);
        }

        /// <summary>
        /// Tests whether the storage is initially empty.
        /// </summary>
        [TestMethod]
        public void InitiallyEmpty()
        {
            Assert.IsFalse(this.storage.RetreiveData().Any(), "The new storage must be empty.");
        }

        /// <summary>
        /// Tests whether a new item can be added and retreived from the storage.
        /// </summary>
        [TestMethod]
        public void AddOne()
        {
            var testData = new TestData
            {
                Name = "Test Name",
                Age = 12
            };

            this.storage.AppendData(testData);

            Assert.IsFalse(this.storage.RetreiveData().Skip(1).Any(), "The storage should not contain more than one item if only one was added.");
            AreEqual(this.storage.RetreiveData().FirstOrDefault(), testData, "The items should be equal.");
        }

        /// <summary>
        /// Checks whether multiple items can be added and retreived from the storage.
        /// </summary>
        [TestMethod]
        public void GrowsIncrementally()
        {
            var testData = this.GenerateTestData(5).ToArray();

            for (int i = 0; i < testData.Length; ++i)
            {
                this.storage.AppendData(testData[i]);

                Assert.IsFalse(this.storage.RetreiveData().Skip(i + 1).Any(), "The storage should not contain more items than was added.");

                for (int j = 0; j < i; ++j)
                    AreEqual(this.storage.RetreiveData().Skip(j).FirstOrDefault(), testData[j], "The items should be equal.");
            }
        }

        private static void AreEqual(TestData expected, TestData actual, string message = null)
        {
            Assert.AreEqual(expected.Name, actual.Name, message);
            Assert.AreEqual(expected.Age, actual.Age, message);
        }

        private IEnumerable<TestData> GenerateTestData(int count)
        {
            for (int i = 0; i < count; ++i)
                yield return new TestData
                {
                    Name = $"Test Name {i}",
                    Age = i
                };
        }

        private class TestData
        {
            public string Name { get; set; }

            public int Age { get; set; }
        }
    }
}
