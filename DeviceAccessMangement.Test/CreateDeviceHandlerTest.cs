using Domain.Entities;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Services.Commands.Devices;
using Services.Commands.Devices.Handler;
using Services.InterFaces;
using Xunit;


namespace DeviceAccessMangement.Test
{
    public class CreateDeviceHandlerTest
    {
        public class CreateDeviceHandlerTests
        {
            [Fact]
            public async Task Handle_Should_Create_Device_And_Commit()
            {
                // Arrange
                var unitOfWork = Substitute.For<IUnitOfWork>();
                var handler = new CreateDeviceHandler(unitOfWork);

                var command = new CreateDeviceCommand()
                {
                    Name = "Testing_Device"
                };

                // Act
                var result = await handler.Handle(command, CancellationToken.None);

                // Assert
                Assert.NotEqual(Guid.Empty, result);
                await unitOfWork.Received(1).Commit();
            }
        }
        [Fact]
        public async Task Handle_Should_Throw_When_Commit_Fails()
        {
            var uow = Substitute.For<IUnitOfWork>();
            uow.Commit().Throws(new Exception());

            var handler = new CreateDeviceHandler(uow);
            var command = new CreateDeviceCommand()
            {
                Name ="Device"
            };
            await Assert.ThrowsAsync<Exception>(() =>
                handler.Handle(command, CancellationToken.None));
        }
    }
}