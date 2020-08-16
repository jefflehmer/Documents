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
        public async Task GivenInput_WhenGetDocumentCount_ShouldBumpResponse()
        {
            // Arrange
            var sut = new DocumentsTestService();

            // Act
            var response = await sut.Count();

            // Assert
            response.ShouldBe(47);
        }
    }
}
