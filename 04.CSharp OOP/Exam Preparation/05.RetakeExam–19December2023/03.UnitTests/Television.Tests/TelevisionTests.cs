namespace Television.Tests
{
    using System;
    using NUnit.Framework;
    public class Tests
    {
        private TelevisionDevice tv;
        private string brand = "TestBrand";
        private double price = 499.99;
        private int screenWidth = 1920;
        private int screenHeigth = 1080;

        [SetUp]
        public void Setup()
        {
            this.tv = new TelevisionDevice(brand, price, screenWidth, screenHeigth);
        }

        [Test]
        public void Test_Assert_NewInstanceOfTvDevice_CreatedSuccessfully()
        {
            Assert.That(brand, Is.EqualTo(tv.Brand));
            Assert.That(price, Is.EqualTo(tv.Price));
            Assert.That(screenWidth, Is.EqualTo(tv.ScreenWidth));
            Assert.That(screenHeigth, Is.EqualTo(tv.ScreenHeigth));
        }
        [Test]
        public void Test_Assert_SwitchOn_ReturnsCorrectInformation()
        {
            string expectedOutput = "Cahnnel 0 - Volume 13 - Sound On";

            string output = tv.SwitchOn();

            Assert.That(expectedOutput, Is.EqualTo(output));
        }

        [Test]
        public void Test_Assert_SwitchOn_LastMuted_ReturnsCorrectInformation()
        {
            tv.MuteDevice();
            string expectedOutput = "Cahnnel 0 - Volume 13 - Sound Off";

            string output = tv.SwitchOn();

            Assert.That(expectedOutput, Is.EqualTo(output));
        }

        [Test]
        public void Test_Assert_ChangeChannel_NegativeChannelThrowsException()
        {
            Assert.Throws<ArgumentException>(() => tv.ChangeChannel(-1));
        }

        [Test]
        public void Test_Assert_ChangeChannel_ValidArgument_ReturnsPositiveChannel()
        {
            int newChannel = 5;

            int channel = tv.ChangeChannel(newChannel);

            Assert.That(newChannel, Is.EqualTo(channel));
        }

        [Test]
        public void Test_Assert_VolumeChange_Up_ChangesTheVolumeCorrectly()
        {
            string expectedOutput = "Volume: 23";

            string output = tv.VolumeChange("UP", 10);

            Assert.That(expectedOutput, Is.EqualTo(output));
        }
        [Test]
        public void Test_Assert_VolumeChange_Up_MoreThan100Volume()
        {
            string expectedOutput = "Volume: 100";

            string output = tv.VolumeChange("UP", 100);

            Assert.That(expectedOutput, Is.EqualTo(output));
        }

        [Test]
        public void Test_Assert_VolumeChange_Down_ChangesTheVolumeCorrectly()
        {
            string expectedOutput = "Volume: 3";

            string output = tv.VolumeChange("DOWN", 10);

            Assert.That(expectedOutput, Is.EqualTo(output));
        }

        [Test]
        public void Test_Assert_VolumeChange_Down_LessThanZeroVolume()
        {
            string expectedOutput = "Volume: 0";

            string output = tv.VolumeChange("DOWN", 14);

            Assert.That(expectedOutput, Is.EqualTo(output));
        }

        [Test]
        public void Test_Assert_MuteDevice_MutedDevice_IsUnmuted()
        {
            tv.MuteDevice();

            bool isMuted = tv.MuteDevice();

            Assert.IsFalse(isMuted);
        }

        [Test]
        public void Test_Assert_MuteDevice_MutedDevice_IsMuted()
        {
            bool isMuted = tv.MuteDevice();

            Assert.IsTrue(isMuted);
        }

        [Test]
        public void Test_Assert_ToStringMethod_ReturnsCorrectOutput()
        {
            string expectedOutput = "TV Device: TestBrand, Screen Resolution: 1920x1080, Price 499.99$";

            string output = tv.ToString();

            Assert.That(expectedOutput, Is.EqualTo(output));
        }
    }
}