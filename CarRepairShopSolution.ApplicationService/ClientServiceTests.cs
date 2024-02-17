// <copyright file="ClientServiceTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRepairShopSolution.ApplicationService;

using System;
using System.Threading.Tasks;
using CarRepairShopSolution.ApplicationServices.RepositoryMappings;
using CarRepairShopSolution.Domain.Models;
using CarRepairShopSolution.Infrastructure.Persistence.DatabaseContextInit;
using CarRepairShopSolution.Infrastructure.Persistence.DbModels;
using CarRepairShopSolution.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
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

        var clientModel1 = new ClientModel(
            id: 2,
            firstName: "Mark",
            lastName: "Doe",
            phoneNumber: "1231251221",
            createdAt: DateTimeOffset.UtcNow,
            updatedAt: DateTimeOffset.UtcNow);

        // Act
        await clientService.AddClientAsync(clientModel);
        //await clientService.AddClientAsync(clientModel1);

        // Assert
        mockRepository.Verify(repo => repo.AddAsync(It.IsAny<DbClient>()), Times.Once);
    }

    [Fact]
    public async Task AddClientAsync_SavesToDatabase1()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite("DataSource=:memory:")
            .Options;

        using var context = new AppDbContext(options);
        context.Database.OpenConnection();
        context.Database.EnsureCreated();

        var clientRepository = new Repository<DbClient>(context);
        var clientService = new ClientService(clientRepository);

        var clientModel = new ClientModel(
            id: 2,
            firstName: "Mark",
            lastName: "Doe",
            phoneNumber: "1231251221",
            createdAt: DateTimeOffset.UtcNow,
            updatedAt: DateTimeOffset.UtcNow);

        // Act
        await clientService.AddClientAsync(clientModel);

        // Assert
        var dbClient = await context.Clients.FirstOrDefaultAsync(c => c.Id == clientModel.Id);
        Assert.NotNull(dbClient);
    }
}
