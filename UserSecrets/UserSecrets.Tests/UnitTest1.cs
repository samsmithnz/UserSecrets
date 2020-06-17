using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UserSecrets.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AppSettingsTest()
        {
            //Arrange
            IConfigurationBuilder config = new ConfigurationBuilder()
               .SetBasePath(AppContext.BaseDirectory)
               .AddJsonFile("appsettings.json");
            IConfigurationRoot configuration = config.Build();

            //Act
            string setting1 = configuration["AppSettings:Setting1"];
            string setting2 = configuration["AppSettings:Setting2"];

            //Assert
            Assert.AreEqual("abc123", setting1);
            Assert.AreEqual("xyz321", setting2);
        }

        [TestMethod]
        public void UserSecretsTest()
        {
            //Arrange
            IConfigurationBuilder config = new ConfigurationBuilder()
               .SetBasePath(AppContext.BaseDirectory)
               .AddJsonFile("appsettings.json")
               .AddUserSecrets<UnitTest1>();
            IConfigurationRoot configuration = config.Build();

            //Act
            string setting1 = configuration["AppSettings:Setting1"];
            string setting2 = configuration["AppSettings:Setting2"];

            //Assert
            Assert.AreEqual("SECRET-abc123", setting1);
            Assert.AreEqual("SECRET-xyz321", setting2);
        }
    }
}
