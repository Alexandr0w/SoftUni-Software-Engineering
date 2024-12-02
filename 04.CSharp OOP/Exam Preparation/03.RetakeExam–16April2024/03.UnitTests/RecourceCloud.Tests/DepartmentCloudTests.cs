using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

namespace RecourceCloud.Tests
{
    public class Tests
    {
        private DepartmentCloud _departmentCloud;

        [SetUp]
        public void Setup()
        {
            _departmentCloud = new DepartmentCloud();
        }

        [Test]
        public void LogTask_ValidInput_TaskLoggedSuccessfully()
        {
            var args = new[] { "1", "HighPriority", "Resource1" };
            string result = _departmentCloud.LogTask(args);

            Assert.AreEqual("Task logged successfully.", result);
            Assert.AreEqual(1, _departmentCloud.Tasks.Count);
        }

        [Test]
        public void LogTask_DuplicateTask_ReturnsAlreadyLoggedMessage()
        {
            var args = new[] { "1", "HighPriority", "Resource1" };
            _departmentCloud.LogTask(args);
            string result = _departmentCloud.LogTask(args);

            Assert.AreEqual("Resource1 is already logged.", result);
            Assert.AreEqual(1, _departmentCloud.Tasks.Count);
        }

        [Test]
        public void LogTask_NullArguments_ThrowsArgumentException()
        {
            var args = new[] { "1", null, "Resource1" };
            var ex = Assert.Throws<ArgumentException>(() => _departmentCloud.LogTask(args));
            Assert.AreEqual("Arguments values cannot be null.", ex.Message);
        }

        [Test]
        public void LogTask_InvalidArgumentLength_ThrowsArgumentException()
        {
            var args = new[] { "1", "HighPriority" };
            var ex = Assert.Throws<ArgumentException>(() => _departmentCloud.LogTask(args));
            Assert.AreEqual("All arguments are required.", ex.Message);
        }

        [Test]
        public void CreateResource_TaskExists_ReturnsTrueAndMovesTaskToResources()
        {
            var args = new[] { "1", "HighPriority", "Resource1" };
            _departmentCloud.LogTask(args);

            bool result = _departmentCloud.CreateResource();

            Assert.IsTrue(result);
            Assert.AreEqual(0, _departmentCloud.Tasks.Count);
            Assert.AreEqual(1, _departmentCloud.Resources.Count);
        }

        [Test]
        public void CreateResource_NoTask_ReturnsFalse()
        {
            bool result = _departmentCloud.CreateResource();
            Assert.IsFalse(result);
        }

        [Test]
        public void TestResource_ExistingResource_MarksAsTestedAndReturnsResource()
        {
            var args = new[] { "1", "HighPriority", "Resource1" };
            _departmentCloud.LogTask(args);
            _departmentCloud.CreateResource();

            var resource = _departmentCloud.TestResource("Resource1");

            Assert.IsNotNull(resource);
            Assert.IsTrue(resource.IsTested);
            Assert.AreEqual("Resource1", resource.Name);
        }

        [Test]
        public void TestResource_NonExistingResource_ReturnsNull()
        {
            var resource = _departmentCloud.TestResource("NonExistingResource");
            Assert.IsNull(resource);
        }
    }
}