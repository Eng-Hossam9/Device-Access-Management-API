using Domain.Entities;
using Infrastructure.Repositories;
using MediatR;
using Services.Commands.Devices;
using Services.Commands.Devices.Handler;
using Services.InterFaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NSubstitute;
using Xunit;

namespace DeviceAccessMangement.Test
{
    public class UpdateDeviceHandlerTest
    {
        [Fact]
        public async Task Handle_DeviceExists_UpdatesFieldsAndCommits()
        {
            // Arrange
            var deviceId = Guid.NewGuid();
            var existingDevice = new Devices("OldName", deviceId)
            {
                IsActive = false
            };

            var mockRepo = Substitute.For<IRepositoryEntityBase<Guid, Devices>>();
            mockRepo.GetByIdAsync(deviceId).Returns(Task.FromResult(existingDevice));

            var mockUnitOfWork = Substitute.For<IUnitOfWork>();
            mockUnitOfWork.Repository<Guid, Devices>().Returns(mockRepo);
            mockUnitOfWork.Commit().Returns(Task.FromResult(1));

            var handler = new UpdateDeviceHandler(mockUnitOfWork);

            var command = new UpdateDeviceCommand(
                id: deviceId,
                name: "NewName",
                isActive: true
            );

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal("NewName", existingDevice.Name);
            Assert.True(existingDevice.IsActive);
            await mockUnitOfWork.Received(1).Commit();
            Assert.Equal(Unit.Value, result);
        }

        [Fact]
        public async Task Handle_DeviceDoesNotExist_ThrowsKeyNotFoundException()
        {
            // Arrange
            var deviceId = Guid.NewGuid();

            var mockRepo = Substitute.For<IRepositoryEntityBase<Guid, Devices>>();
            mockRepo.GetByIdAsync(deviceId).Returns(Task.FromResult<Devices>(null));

            var mockUnitOfWork = Substitute.For<IUnitOfWork>();
            mockUnitOfWork.Repository<Guid, Devices>().Returns(mockRepo);

            var handler = new UpdateDeviceHandler(mockUnitOfWork);

            var command = new UpdateDeviceCommand(
                id: deviceId,
                name: "NewName",
                isActive: true
            );

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() =>
                handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_NullFields_DoesNotUpdateThoseProperties()
        {
            // Arrange
            var deviceId = Guid.NewGuid();
            var existingDevice = new Devices("OldName", deviceId)
            {
                IsActive = false
            };

            var mockRepo = Substitute.For<IRepositoryEntityBase<Guid, Devices>>();
            mockRepo.GetByIdAsync(deviceId).Returns(Task.FromResult(existingDevice));

            var mockUnitOfWork = Substitute.For<IUnitOfWork>();
            mockUnitOfWork.Repository<Guid, Devices>().Returns(mockRepo);
            mockUnitOfWork.Commit().Returns(Task.FromResult(1));

            var handler = new UpdateDeviceHandler(mockUnitOfWork);

            // Command مع null للحقل Name
            var command = new UpdateDeviceCommand(
                id: deviceId,
                name: null,
                isActive: true
            );

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal("OldName", existingDevice.Name); 
            Assert.True(existingDevice.IsActive);
            await mockUnitOfWork.Received(1).Commit();
            Assert.Equal(Unit.Value, result);
        }
    }
}
