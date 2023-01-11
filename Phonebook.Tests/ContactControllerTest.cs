using Microsoft.AspNetCore.Mvc;
using Moq;
using Phonebook.Controllers;
using Phonebook.Models;
using Phonebook.Repositories;

namespace Phonebook.Tests
{
    public class ContactControllerTest
    {
        private readonly Mock<IRepository<Contact, int>> _mockRepo;
        private readonly ContactController _controller;
        public ContactControllerTest()
        {
            _mockRepo = new Mock<IRepository<Contact, int>>();
            _controller = new ContactController(_mockRepo.Object);
        }
        [Fact]
        public void Contact_Index()
        {
            var result = _controller.Index(null);
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void Create_ActionExecutes_ReturnsViewForCreate()
        {
            var result = _controller.Create();
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void AddUserReturnsARedirectAndAddsUser()
        {
            Contact newUser = new Contact() { Name = "Ben", PhoneNumber = "+420792733051" };

            var result = _controller.Create(newUser);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            _mockRepo.Verify(r => r.Insert(newUser));
        }
    }
}