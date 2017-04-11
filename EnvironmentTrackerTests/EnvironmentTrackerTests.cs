// <copyright file="EnvironmentTrackerTests.cs" company="ELTE">
// Copyright (c) 2017, ELTE. All rights reserved.
// Licensed under the MIT license.
// </copyright>

namespace EnvironmentTrackerTests
{
    using EnvironmentInfoProvider;
    using Microsoft.Extensions.Logging;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Storage;

    /// <summary>
    /// Represents unit test cases for the <see cref="EnvironmentTracker.EnvironmentTracker"/> class.
    /// </summary>
    [TestClass]
    public class EnvironmentTrackerTests
    {
        private Mock<IEnvironmentInfoProvider> environmentInfoProviderMock;
        private Mock<IStorage<EnvironmentInfo>> storageMock;
        private Mock<ILoggerFactory> loggerFactoryMock;
        private Mock<ILogger<EnvironmentTracker.EnvironmentTracker>> loggerMock;
        private EnvironmentTracker.EnvironmentTracker tracker;

        /// <summary>
        /// Initializes this instance before each test case execution.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            this.environmentInfoProviderMock = new Mock<IEnvironmentInfoProvider>(MockBehavior.Strict);
            this.storageMock = new Mock<IStorage<EnvironmentInfo>>(MockBehavior.Strict);
            this.loggerFactoryMock = new Mock<ILoggerFactory>(MockBehavior.Strict);
            this.loggerMock = new Mock<ILogger<EnvironmentTracker.EnvironmentTracker>>(MockBehavior.Loose);

            this.loggerFactoryMock
                .Setup(factory => factory.CreateLogger(It.IsAny<string>()))
                .Returns(this.loggerMock.Object);

            this.tracker = new EnvironmentTracker.EnvironmentTracker(
                this.environmentInfoProviderMock.Object,
                this.storageMock.Object,
                this.loggerFactoryMock.Object);
        }

        /// <summary>
        /// Tests whether the tracker executes the proper executions with the proper arguments on its dependant services.
        /// </summary>
        [TestMethod]
        public void InvocationsHappen()
        {
            const string
                runtime = "TEST_RUNTIME",
                os = "TEST_OS",
                processor = "TEST_PROCESSOR";

            var testData = new EnvironmentInfo(runtime, os, processor);

            this.environmentInfoProviderMock
                .Setup(provider => provider.GetEnvironmentInfo())
                .Returns(testData)
                .Verifiable("Provider needs to be invoked.");

            this.storageMock
                .Setup(storage => storage.AppendData(testData))
                .Verifiable("Received environment info needs to be stored.");

            this.tracker.Process();

            this.environmentInfoProviderMock.VerifyAll();
            this.storageMock.VerifyAll();
        }
    }
}
