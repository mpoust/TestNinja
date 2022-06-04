

using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class HtmlFormatterTests
    {
        [Test]
        [TestCase("Test")]
        public void FormatAsBold_WhenCalled_ShouldEncloseTheStringWithStrongElement(string s)
        {
            // Arrange 
            var formatter = new HtmlFormatter();

            // Act
            var result = formatter.FormatAsBold(s);

            // Assert

            // Specific
            Assert.That(result, Is.EqualTo($"<strong>{s}</strong>"));
            Assert.That(result, Is.EqualTo($"<strong>{s}</strong>").IgnoreCase);

            // More general
            Assert.That(result, Does.StartWith("<strong>"));
            // Make the more general a little more specific
            Assert.That(result, Does.EndWith("</strong>"));
            Assert.That(result, Does.Contain(s));
        }
    }
}
