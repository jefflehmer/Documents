using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ForMoreMoney.Documents.Services;
using Shouldly;
using Xunit;

namespace ForMoreMoney.Documents.Test.Unit.Services
{
    public class DocumentsServiceTest
    {
        [Fact]
        public async Task GivenTestInput_WhenGetDocumentCount_ShouldAgree()
        {
            // Arrange
            var sut = new DocumentsServiceDisk();

            // Act
            var response = await sut.Count();

            // Assert
            response.ShouldBe(3);
        }

        [Fact]
        public async Task GivenTestInput_WhenGetDocumentList_ShouldMatch()
        {
            // Arrange
            var sut = new DocumentsServiceDisk();

            // Act
            var response = await sut.ListAll();

            // Assert
            response.ShouldBe(new List<string> { "dummy.pdf", "Fred.txt", "image.png" });
        }

        [Fact]
        public async Task GivenTestInput_WhenGetDocument_ShouldMatch()
        {
            // Arrange
            var sut = new DocumentsServiceDisk();

            // Act
            var response = await sut.Get("Fred.txt");

            // Assert
            response.ShouldNotBeNull();
            response.Length.ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task GivenTestInput_WhenDeleteDocument_ShouldSucceed()
        {
            // Arrange
            var sut = new DocumentsServiceDisk();

            // Act
            var response = await sut.Delete("imag3.png");

            // Assert
            response.ShouldBeTrue();
        }
    }
}
