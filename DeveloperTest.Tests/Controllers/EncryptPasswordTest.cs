using NUnit.Framework;
using DeveloperTest.Controllers;
using System;

namespace DeveloperTest.Tests.Controllers
{
    /// <summary>
    /// Test class for hashing passwords
    /// </summary>
    [TestFixture]
    class EncryptPasswordTest
    {
        [TestCase(null, typeof(ArgumentException))]
        public void HashPassword_IfPasswordNull_Fails(string password, Type expectedException)
        {
            Assert.Throws(expectedException, () => EncryptPassword.HashPassword(password));
        }

        [TestCase("", typeof(ArgumentException))]         
        public void HashPassword_IfPasswordEmpty_Fails(string password, Type expectedException)
        {
            Assert.Throws(expectedException, () => EncryptPassword.HashPassword(password));

        }

        [Test]
        public void HashPassword_Success()
        {
            string expected = "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=";
            string result = EncryptPassword.HashPassword("password");
            Assert.AreEqual(result, expected);
        }
    }    
}
