using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;
using ChallengeLaNacion.Controllers;
using ChallengeLaNacion.Models;
using ChallengeLaNacion.Business.Interfaces;
using Microsoft.AspNetCore.Http;

namespace ChallengeLaNacion.Tests.Controllers
{
    public class ContactControllerTests
    {
        [Fact]
        public async Task Index_ReturnsOkResultWithContacts()
        {
            // Arrange
            var mockContactService = new Mock<IContactService>();
            var expectedContacts = new List<Contact>
            {
                new Contact
                {
                    Id = 1,
                    Name = "Lucio Zuccolo",
                    Company = "La Nacion",
                    Profile_Image = new byte[0],
                    Email = "lzuccolo@gmail.com",
                    Birthdate = DateTime.Now,
                    Work_Phone = "123456789",
                    Personal_Phone = "987654321",
                    Address = "Quilmes, Buenos Aires"
                },
                new Contact
                {
                    Id = 2,
                    Name = "Juan Perez",
                    Company = "La Nacion",
                    Profile_Image = new byte[0],
                    Email = "juan@hotmail.com",
                    Birthdate = DateTime.Now,
                    Work_Phone = "987654321",
                    Personal_Phone = "123456789",
                    Address = "Berazategui, Buenos Aires"
                }
            };
            mockContactService.Setup(service => service.GetAll()).ReturnsAsync(expectedContacts);

            var controller = new ContactController(mockContactService.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualContacts = Assert.IsType<List<Contact>>(okResult.Value);
            Assert.Equal(expectedContacts.Count, actualContacts.Count);
            for (int i = 0; i < expectedContacts.Count; i++)
            {
                Assert.Equal(expectedContacts[i].Id, actualContacts[i].Id);
                Assert.Equal(expectedContacts[i].Name, actualContacts[i].Name);
                Assert.Equal(expectedContacts[i].Company, actualContacts[i].Company);
                Assert.Equal(expectedContacts[i].Profile_Image, actualContacts[i].Profile_Image);
                Assert.Equal(expectedContacts[i].Email, actualContacts[i].Email);
                Assert.Equal(expectedContacts[i].Birthdate, actualContacts[i].Birthdate);
                Assert.Equal(expectedContacts[i].Work_Phone, actualContacts[i].Work_Phone);
                Assert.Equal(expectedContacts[i].Personal_Phone, actualContacts[i].Personal_Phone);
                Assert.Equal(expectedContacts[i].Address, actualContacts[i].Address);
            }
        }

        [Fact]
        public async Task Details_ReturnsOkResult_WhenContactExists()
        {
            // Arrange
            int contactId = 1;
            var expectedContact = new Contact { Id = contactId, Name = "John Doe", Email = "john@example.com" };

            var mockContactService = new Mock<IContactService>();
            mockContactService.Setup(service => service.Find(contactId)).ReturnsAsync(expectedContact);

            var controller = new ContactController(mockContactService.Object);

            // Act
            var result = await controller.Details(contactId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedContact = Assert.IsType<Contact>(okResult.Value);
            Assert.Equal(expectedContact.Id, returnedContact.Id);
            Assert.Equal(expectedContact.Name, returnedContact.Name);
            Assert.Equal(expectedContact.Email, returnedContact.Email);
        }

        [Fact]
        public async Task Details_ReturnsNotFoundResult_WhenContactDoesNotExist()
        {
            // Arrange
            int contactId = 1;
            Contact nullContact = null;

            var mockContactService = new Mock<IContactService>();
            mockContactService.Setup(service => service.Find(contactId)).ReturnsAsync(nullContact);

            var controller = new ContactController(mockContactService.Object);

            // Act
            var result = await controller.Details(contactId);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("No se encontraron resultados para la búsqueda.", notFoundResult.Value);
        }

        [Fact]
        public async Task Create_ReturnsRedirectToActionResult_WhenContactIsCreated()
        {
            // Arrange
            var newContact = new Contact
            {
                Id = 1,
                Name = "Lucio Zuccolo",
                Company = "La Nacion",
                Profile_Image = new byte[0],
                Email = "lzuccolo@gmail.com",
                Birthdate = DateTime.Now,
                Work_Phone = "123456789",
                Personal_Phone = "987654321",
                Address = "Quilmes, Buenos Aires"
            };

            var mockContactService = new Mock<IContactService>();
            mockContactService.Setup(service => service.CreateContact(It.IsAny<Contact>())).Returns(Task.CompletedTask);

            var controller = new ContactController(mockContactService.Object);

            // Act
            var result = await controller.Create(newContact);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

    }
}


