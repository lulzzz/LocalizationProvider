using Xunit;

namespace DbLocalizationProvider.Tests
{
    public class MessageFormatingTests
    {
        class Customer
        {
            public string FirstName { get; set; }
        }

        [Fact]
        public void FormatMessage_WithNamedPlaceholders_WithObject()
        {
            var message = "Hello, {FirstName}";
            var model = new Customer { FirstName = "John" };

            var result = LocalizationServiceExtensions.Format(message, model);

            Assert.Equal("Hello, John", result);
        }

        [Fact]
        public void FormatMessage_WithNamedPlaceholders_WithAnonymousObject()
        {
            var message = "Hello, {FirstName}";

            var result = LocalizationServiceExtensions.Format(message, new { FirstName = "John" });

            Assert.Equal("Hello, John", result);
        }

        [Fact]
        public void FormatMessage_WithNamedMixedOrderPlaceholders_WithAnonymousObject()
        {
            var message = "Hello, {Surname} {FirstName}";

            var result = LocalizationServiceExtensions.Format(message, new { FirstName = "John", Surname = "Smith" });

            Assert.Equal("Hello, Smith John", result);
        }


        [Fact]
        public void FormatMessage_WithNonExistingNamedPlaceholders_WithAnonymousObject()
        {
            var message = "Hello, {Surname} {FirstName}";

            var result = LocalizationServiceExtensions.Format(message, new { FirstName = "John" });

            Assert.Equal("Hello, {Surname} John", result);
        }

        [Fact]
        public void FormatMessage_WithIndexedPlaceholders()
        {
            var message = "Hello, {0}";

            var result = LocalizationServiceExtensions.Format(message, "John");

            Assert.Equal("Hello, John", result);
        }
    }
}