using System;
using System.Collections.Generic;
using System.Text;
using ELH.Framework.Interfaces;
using NUnit.Framework;

namespace ELH.Framework.Tests
{
    [TestFixture]
    public class ApplicationSettingsTests
    {

        [TestFixtureSetUp]
        public void SetupMethods()
        {
        }

        [TestFixtureTearDown]
        public void TearDownMethods()
        {
        }

        [SetUp]
        public void SetupTest()
        {
        }

        [TearDown]
        public void TearDownTest()
        {
        }

        [Test]
        public void GetEnumSettingFromConfig()
        {
            IApplicationSettings configSettings = new ApplicationSettings();
            PropertyType type = configSettings.GetAppSettingValue<PropertyType>("PropertyType");
            Assert.AreEqual(PropertyType.SingleFamilyHome, type);
        }

        [Test]
        public void GetEnumSettingFromConfigWithEmptyValueInConfig()
        {
            IApplicationSettings configSettings = new ApplicationSettings();
            PropertyType type = configSettings.GetAppSettingValue<PropertyType>("PropertyType2");
            Assert.AreEqual(PropertyType.VacantLand, type);
        }

        [Test]
        public void GetEnumSettingFromConfigWithBogusValueInConfig()
        {
            IApplicationSettings configSettings = new ApplicationSettings();
            PropertyType type = configSettings.GetAppSettingValue<PropertyType>("PropertyType3");
            Assert.AreEqual(PropertyType.VacantLand, type);
        }

        [Test]
        public void GetEnumSettingFromConfigWithMissingAppSettingKey()
        {
            IApplicationSettings configSettings = new ApplicationSettings();
            PropertyType type = configSettings.GetAppSettingValue<PropertyType>("PropertyType4");
            Assert.AreEqual(PropertyType.VacantLand, type);
        }

        [Test]
        public void GetIntegerSettingFromConfig()
        {
            IApplicationSettings configSettings = new ApplicationSettings();
            int type = configSettings.GetAppSettingValue<int>("ExpirationInDays");
            Assert.AreEqual(11, type);
        }

        [Test]
        public void GetIntegerSettingFromConfigWithDefault()
        {
            IApplicationSettings configSettings = new ApplicationSettings();
            int type = configSettings.GetAppSettingValue<int>("ExpirationInMonths", 16);
            Assert.AreEqual(16, type);
        }

        [Test]
        public void GetIntegerSettingFromConfigWithMissingAppSettingKey()
        {
            IApplicationSettings configSettings = new ApplicationSettings();
            int type = configSettings.GetAppSettingValue<int>("ExpirationInYears");
            Assert.AreEqual(0, type);
        }

        [Test]
        public void GetIntegerSettingFromConfigWithMissingAppSettingKeyWithDefault()
        {
            IApplicationSettings configSettings = new ApplicationSettings();
            int type = configSettings.GetAppSettingValue<int>("ExpirationInYears", 24);
            Assert.AreEqual(24, type);
        }

        [Test]
        public void GetStringSettingFromConfig()
        {
            IApplicationSettings configSettings = new ApplicationSettings();
            string type = configSettings.GetAppSettingValue<string>("Prefix");
            Assert.AreEqual("SOMEPREFIX", type);
        }

        [Test]
        public void GetStringSettingFromConfigWithEmptyValue()
        {
            IApplicationSettings configSettings = new ApplicationSettings();
            string type = configSettings.GetAppSettingValue<string>("Prefix2");
            Assert.AreEqual(null, type);
        }

        [Test]
        public void GetStringSettingFromConfigMissingAppSettingKey()
        {
            IApplicationSettings configSettings = new ApplicationSettings();
            string type = configSettings.GetAppSettingValue<string>("Prefix3");
            Assert.AreEqual(null, type);
        }

        [Test]
        public void GetStringSettingFromConfigMissingAppSettingKeyWithDefault()
        {
            IApplicationSettings configSettings = new ApplicationSettings();
            string type = configSettings.GetAppSettingValue<string>("Prefix3", "My Prefix");
            Assert.AreEqual("My Prefix", type);
        }

        [Test]
        public void GetIntegerBasedBooleanSettingFromConfig()
        {
            IApplicationSettings configSettings = new ApplicationSettings();
            bool type = configSettings.GetAppSettingValue<bool>("Flag");
            Assert.AreEqual(false, type);
        }

        [Test]
        public void GetStringBasedBooleanSettingFromConfig()
        {
            IApplicationSettings configSettings = new ApplicationSettings();
            bool type = configSettings.GetAppSettingValue<bool>("Flag2");
            Assert.AreEqual(true, type);
        }

        [Test]
        public void GetStringBasedBooleanSettingFromConfigWithBogusValue()
        {
            IApplicationSettings configSettings = new ApplicationSettings();
            bool type = configSettings.GetAppSettingValue<bool>("Flag3");
            Assert.AreEqual(false, type);
        }

        [Test]
        public void GetBooleanSettingFromConfigWithEmptyValue()
        {
            IApplicationSettings configSettings = new ApplicationSettings();
            bool type = configSettings.GetAppSettingValue<bool>("Flag4");
            Assert.AreEqual(false, type);
        }

        [Test]
        public void GetBooleanSettingFromConfigMissingAppSettingKey()
        {
            IApplicationSettings configSettings = new ApplicationSettings();
            bool type = configSettings.GetAppSettingValue<bool>("Flag5");
            Assert.AreEqual(false, type);
        }

        [Test]
        public void GetBooleanSettingFromConfigMissingAppSettingKeyWithDefault()
        {
            IApplicationSettings configSettings = new ApplicationSettings();
            bool type = configSettings.GetAppSettingValue<bool>("Flag5", true);
            Assert.AreEqual(true, type);
        }

        [Test]
        public void GetClassSettingFromConfig()
        {
            IApplicationSettings configSettings = new ApplicationSettings();
            ActivationContext type = configSettings.GetAppSettingValue<ActivationContext>("ActivationContext");
            Assert.AreEqual(null, type);
        }
    }
}