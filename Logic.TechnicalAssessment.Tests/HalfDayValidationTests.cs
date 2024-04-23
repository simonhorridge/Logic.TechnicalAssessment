using Logic.TechnicalAssement.App.Models;
using Logic.TechnicalAssement.App.Validation;
using System.ComponentModel.DataAnnotations;

namespace Logic.TechnicalAssement.Tests
{
    [TestClass]
    public class HalfDayValidationTests
    {
        [TestMethod]
        public void TestHalfDayValidationAttribute_InvalidCase()
        {
            // Arrange
            var model = new LeaveViewModel
            {
                IsHalfDay = true,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1) // Different date, should be invalid
            };
            var context = new ValidationContext(model);
            var attribute = new HalfDayValidation();

            // Act
            var result = attribute.GetValidationResult(model, context);

            // Assert
            Assert.IsNotNull(result); // The result should be invalid
        }

        [TestMethod]
        public void TestHalfDayValidationAttribute_ValidCase()
        {
            // Arrange
            var model = new LeaveViewModel
            {
                IsHalfDay = true,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now // Same date, should be valid
            };
            var context = new ValidationContext(model);
            var attribute = new HalfDayValidation();

            // Act
            var result = attribute.GetValidationResult(model, context);

            // Assert
            Assert.IsNull(result); // The result should be valid
        }
    }
}