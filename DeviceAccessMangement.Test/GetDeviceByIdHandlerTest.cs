using Domain.Entities;
using Infrastructure.Repositories;
using NSubstitute;
using Services.Commands.Devices;
using Services.Commands.Devices.Handler;
using Services.InterFaces;
using Services.Queries;
using Services.Queries.Devices.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceAccessMangement.Test
{
    public class GetDeviceByIdHandlerTest
    {
        [Fact]
        public async Task Handle_Should_Return_Device_When_Exists()
        {
            // Arrange
            var deviceId = Guid.NewGuid();
            var device = new Devices("TestDevice",deviceId) ;

            var repo = Substitute.For<IRepositoryEntityBase<Guid, Devices>>();
            repo.GetByIdAsync(deviceId).Returns(device);

            var uow = Substitute.For<IUnitOfWork>();
            uow.Repository<Guid, Devices>().Returns(repo);

            var handler = new GetDeviceByIdHandler(uow);
            var query = new GetDeviceByIdQuery()
            {
                Id = deviceId,
            };

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal(deviceId, result.Id);
            Assert.Equal("TestDevice", result.Name);
        }

    }
}

