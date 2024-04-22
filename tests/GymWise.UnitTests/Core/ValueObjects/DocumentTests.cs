
using FluentAssertions;
using GymWise.Core.Errors;
using GymWise.Core.Models.ValueObjects;

namespace GymWise.UnitTests.Core.ValueObjects
{
    [Trait("Core.ValueObjects", nameof(Document))]
    public class DocumentTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("1234567891")]
        [InlineData("123456789112345")]
        public void GivenDocument_WhenInvalidLength_ThenReturnDomainErrorResult(string document)
        {
            // Assert
            // Action
            var result = Document.Create(document);
            // Assert
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(DomainErrors.Document.InvalidDocumentLength);
        }

        [Theory]
        [InlineData("81.699.676/0001-77")]
        [InlineData("27.992.596/0001-99")]
        [InlineData("079.207.450-99")]
        [InlineData("037.631.610-99")]
        public void GivenDocument_WhenInvalidDocument_ThenReturnDomainErrorResult(string document)
        {
            // Assert
            // Action
            var result = Document.Create(document);
            // Assert
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(DomainErrors.Document.InvalidDocument);
        }

        [Theory]
        [InlineData("81.699.676/0001-17", "81699676000117", false, true)]
        [InlineData("27.992.596/0001-00", "27992596000100", false, true)]
        [InlineData("079.207.450-55", "07920745055", true, false)]
        [InlineData("037.631.610-15", "03763161015", true, false)]
        public void GivenDocument_WhenValidLength_ThenReturnDocumentResult(string document, string expected, bool isCpf, bool isCnpj)
        {
            // Assert
            // Action
            var result = Document.Create(document);
            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Value.Should().Be(expected);
            result.Value.IsCpf.Should().Be(isCpf);
            result.Value.IsCnpj.Should().Be(isCnpj);
        }
    }
}
