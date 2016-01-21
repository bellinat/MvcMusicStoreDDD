using System;
using Moq;
using MvcMusicStore.Application.Interfaces;
using MvcMusicStore.Domain.Entities;
using MvcMusicStore.Domain.Validation;
using Xunit;

namespace MvcMusicStore.Application.Tests
{
    [Trait("Application", "Client - Services")]
    public class ClientAppServiceTest
    {
        private readonly Mock<IClientAppService> _mockIClientAppService;

        public ClientAppServiceTest(Mock<IClientAppService> mockIClientAppService)
        {
            _mockIClientAppService = mockIClientAppService;
        }

        [Fact]
        public void Create_WithSuccess()
        {
            //arrage
            var client = new Client {Name = "Eduardo"};

            //act
            _mockIClientAppService
                .Setup(x => x.Create(client))
                .Returns(new ValidationResult());

            //assert
            _mockIClientAppService
                .Verify(x => x.Create(client), Times.Once);
        }

        [Fact]
        public void Create_WithError()
        {
            //arrage
            //act
            //assert

            throw new NotImplementedException();
        }
    }
}
