using DeveloperTest.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;


namespace DeveloperTest.Tests.Controllers
{
    [TestClass]
    public class UserDataControllerTests
    {
        [TestMethod]
        public void AddUserInitialise()
        {
            // Arrange
            UserDataController controller = new UserDataController();

            // Act
            ViewResult result = controller.AddUser() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
 
    }
}
