namespace SmartDevice.Tests
{
    using NUnit.Framework;
    using System;
    using System.Text;

    public class Tests
    {
        private Device device;
        private int memoryCapacity = 2048;

        [SetUp]
        public void Setup()
        {
            device = new Device(memoryCapacity);
        }

        [Test]
        public void Device_Constructor_ShouldInitializePropertiesCorrectly()
        {
            Assert.That(memoryCapacity, Is.EqualTo(device.MemoryCapacity));
            Assert.That(memoryCapacity, Is.EqualTo(device.AvailableMemory));
            Assert.That(0, Is.EqualTo(device.Photos));
            Assert.That(0, Is.EqualTo(device.Applications.Count));
        }

        [Test]
        public void Device_TakePhoto_ShouldReduceAvailableMemoryAndIncrementPhotos()
        {
            int photoSize = 100;

            bool photoTaken = device.TakePhoto(photoSize);

            Assert.IsTrue(photoTaken);
            Assert.That(memoryCapacity - photoSize, Is.EqualTo(device.AvailableMemory));
            Assert.That(1, Is.EqualTo(device.Photos));
        }

        [Test]
        public void Device_TakePhoto_ShouldreturnFalseIfNotEnoughMemory()
        {
            int photoSize = 3000;

            bool photoTaken = device.TakePhoto(photoSize);

            Assert.IsFalse(photoTaken);
            Assert.That(memoryCapacity, Is.EqualTo(device.AvailableMemory));
            Assert.That(0, Is.EqualTo(device.Photos));
        }

        [Test]
        public void Device_InstallApp_ShouldReduceAvailableMemoryAndAddAppToList()
        {
            int appSize = 500;
            string appName = "MyApp";

            string result = device.InstallApp(appName, appSize);

            Assert.That(result, Is.EqualTo($"{appName} is installed successfully. Run application?"));
            Assert.That(memoryCapacity - appSize, Is.EqualTo(device.AvailableMemory));
            Assert.That(1, Is.EqualTo(device.Applications.Count));
            Assert.IsTrue(device.Applications.Contains(appName));
        }

        [Test]
        public void Device_InstallApp_ShouldThrowExceptionIfNotEnoughMemory()
        {
            int appSize = 3000;
            string appName = "MyApp";

            Assert.Throws<InvalidOperationException>(() => device.InstallApp(appName, appSize));
            Assert.That(memoryCapacity, Is.EqualTo(device.AvailableMemory));
            Assert.That(0, Is.EqualTo(device.Applications.Count));
        }

        [Test]
        public void Device_FormatDevice_ShouldResetProperties()
        {
            int photoSize = 100;
            device.TakePhoto(photoSize);
            device.InstallApp("MyApp", 500);

            device.FormatDevice();

            Assert.That(memoryCapacity, Is.EqualTo(device.AvailableMemory));
            Assert.That(0, Is.EqualTo(device.Photos));
            Assert.That(0, Is.EqualTo(device.Applications.Count));
        }

        [Test]
        public void Device_GetDeviceStatus_ShouldReturnStatusString()
        {
            int photoSize = 100;
            device.TakePhoto(photoSize);
            device.InstallApp("MyFirstApp", 500);
            device.InstallApp("MySecondApp", 300);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Memory Capacity: {memoryCapacity} MB, Available Memory: {memoryCapacity - photoSize - 500 - 300} MB");
            sb.AppendLine($"Photos Count: 1");
            sb.AppendLine($"Applications Installed: MyFirstApp, MySecondApp");

            string result = sb.ToString().Trim();
            string status = device.GetDeviceStatus();

            Assert.That(result, Is.EqualTo(status));
        }
    }
}