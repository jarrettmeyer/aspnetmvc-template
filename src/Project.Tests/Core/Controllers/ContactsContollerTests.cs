using System.Web.Mvc;
using Moq;
using Project.Core.Lib.Data;
using Project.Core.Lib.Infrastructure;
using Project.Core.Models.Entities;
using Xunit;

namespace Project.Core.Controllers
{
    public class ContactsContollerTests
    {
        [Fact]
        public void TestCreateAsXhrReturnsPartial()
        {
            // Assemble
            var scope = new Mock<IAppScope>();
            scope.SetupGet(x => x.IsXhr).Returns(true);
            var repo = new Mock<IRepository>();
            var controller = new ContactsController(repo.Object, scope.Object);
            
            // Act
            var contact = new Contact();
            var result = controller.Create(contact);

            // Assert
            var partialViewResult = Assert.IsType<PartialViewResult>(result);
            Assert.IsType<Contact>(partialViewResult.ViewData.Model);
        }

        [Fact]
        public void TestCreateReturnsIndex()
        {
            // Assemble
            var scope = new Mock<IAppScope>();
            scope.SetupGet(x => x.IsXhr).Returns(false);
            var repo = new Mock<IRepository>();
            var controller = new ContactsController(repo.Object, scope.Object);

            // Act
            var contact = new Contact();
            var result = controller.Create(contact);

            // Assert
            var redirectToRouteResult = Assert.IsType<RedirectToRouteResult>(result);
            Assert.Equal("Index", redirectToRouteResult.RouteValues["action"]);            
        }

    }
}
