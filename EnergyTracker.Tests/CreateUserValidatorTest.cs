using EnergyTracker.Application.Commands.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.TestHelper;
using EnergyTracker.Application.Validators;
using FluentValidation.Results;


namespace EnergyTracker.Tests
{
    public class CreateUserValidatorTest
    {
        private readonly  CreateUserCommandValidator _validator;
        public CreateUserValidatorTest()
        {
            _validator = new CreateUserCommandValidator();
        }
       
        [Fact]
        public void Should_Have_Error_When_FirstName_Is_Empty()
        {
            var command = new CreateUserCommand
            {
                FirstName = "",
                LastName = "Reqqass",
                Email = "kaoutharreqqass@gmail.com"
            };

            ValidationResult result = _validator.Validate(command);

            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == "FirstName");
        }
        [Fact]
        public void Should_Have_Error_When_LastName_Is_Empty()
        {
            var command = new CreateUserCommand
            {
                FirstName = "kaouthar",
                LastName = "",
                Email = "kaoutharreqqass@gmail.com"
            };

            ValidationResult result = _validator.Validate(command);

            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == "LastName");
        }
        [Fact]
        public void Should_Have_Error_When_Email_Is_Invalid()
        {
            var command = new CreateUserCommand
            {
                FirstName = "kaouthar",
                LastName = "Reqqass",
                Email = "kaouthar.reeqass"
            };

            ValidationResult result = _validator.Validate(command);
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == "Email");
        }
        [Fact]
        public void Should_Not_Have_Error_When_Command_Is_Valid()
        {
            var command = new CreateUserCommand
            {
                FirstName = "kaouthar",
                LastName = "Reqqass",
                Email = "kaoutharreqqass@gmail.com"
            };

            ValidationResult result = _validator.Validate(command);

            Assert.True(result.IsValid);
        }
    }
}
