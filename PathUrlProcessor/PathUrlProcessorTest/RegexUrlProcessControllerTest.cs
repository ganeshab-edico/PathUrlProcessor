using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PathUrlProcessor.Controllers;
using PathUrlProcessor.Model;
using PathUrlProcessor.Services;

namespace PathUrlProcessorTest
{
    [TestClass]
    public class RegexUrlProcessControllerTest
    {
        [TestMethod]
        public void Post_ValidRequest_HappyPath()
        {
            //Arrange
            var controller = new RegexUrlProcessController(new RegexUrlValidation(), new SizeValidation());
            //Act
            var inputObjects = new List<InputObject>
            {
                new InputObject() {Url = "https://www.youtube.com/", Path = "youtube", Size = 20},
                new InputObject() {Url = "https://www.google.com/", Path = "google", Size = 20},
            };
            var result = (Dictionary<string, PathValueObject>) controller.Post(inputObjects).Value;
            //Assert
            CollectionAssert.AllItemsAreNotNull(result);
        }

        [TestMethod]
        public void Post_InValidUrl_Error()
        {
            //Arrange
            var controller = new RegexUrlProcessController(new RegexUrlValidation(), new SizeValidation());
            //Act
            var inputObjects = new List<InputObject>
            {
                new InputObject() {Url = "InValidUrl", Path = "youtube", Size = 20},
                new InputObject() {Url = "https://www.google.com/", Path = "google", Size = 20},
            };


            var exceptionThrown = false;
            try
            {
                var result = (Dictionary<string, PathValueObject>) controller.Post(inputObjects).Value;
            }
            catch (Exception e)
            {
                exceptionThrown = true;
                Assert.AreEqual("InValidUrl is Invalid for Url - InValidUrl, Path - youtube, Size - 20", e.Message);
            }

            if (!exceptionThrown)
                throw new AssertFailedException("Exception expected!!");
        }

        [TestMethod]
        public void Post_InValidSize_Error()
        {
            //Arrange
            var controller = new RegexUrlProcessController(new RegexUrlValidation(), new SizeValidation());
            //Act
            var inputObjects = new List<InputObject>
            {
                new InputObject() {Url = "https://www.google.com/", Path = "google", Size = 0},
            };


            var exceptionThrown = false;
            try
            {
                var result = (Dictionary<string, PathValueObject>)controller.Post(inputObjects).Value;
            }
            catch (Exception e)
            {
                exceptionThrown = true;
                Assert.AreEqual("Size - 0 is Invalid for Url - https://www.google.com/, Path - google, Size - 0", e.Message);
            }

            if (!exceptionThrown)
                throw new AssertFailedException("Exception expected!!");
        }
    }
}