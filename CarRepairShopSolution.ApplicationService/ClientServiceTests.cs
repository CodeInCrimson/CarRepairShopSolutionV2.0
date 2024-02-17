// <copyright file="ClientServiceTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRepairShopSolution.ApplicationService;

using System;
using System.Threading.Tasks;
using CarRepairShopSolution.ApplicationServices.RepositoryMappings;
using CarRepairShopSolution.Domain.Models;
using CarRepairShopSolution.Infrastructure.Persistence.DbModels;
using CarRepairShopSolution.Infrastructure.Persistence.Repositories;
using Moq;
using Xunit;
public class ClientServiceTests
{
    [Fact]
    public async Task AddClientAsync_SavesToDatabase()
    {
        // Arrange
        var mockRepository = new Mock<IRepository<DbClient>>();
        var clientService = new ClientService(mockRepository.Object);
        var clientModel = new ClientModel(
            id: 1,
            firstName: "John",
            lastName: "Doe",
            phoneNumber: "1234567890",
            createdAt: DateTimeOffset.UtcNow,
            updatedAt: DateTimeOffset.UtcNow);

        // Act
        await clientService.AddClientAsync(clientModel);

        // Assert
        mockRepository.Verify(repo => repo.AddAsync(It.IsAny<DbClient>()), Times.Once);
    }
}
