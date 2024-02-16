// <copyright file="ModelBase.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRepairShopSolution.Domain.Models;

using System;
using System.ComponentModel.DataAnnotations;

public abstract record ModelBase
{
    private DateTimeOffset _updatedAt;

    protected ModelBase(
        int id,
        DateTimeOffset? createdAt,
        DateTimeOffset? updatedAt)
    {
        DateTimeOffset utcNow = DateTimeOffset.UtcNow;

        if (createdAt.HasValue && createdAt > utcNow)
        {
            throw CreateArgumentException(nameof(createdAt));
        }

        if (updatedAt.HasValue && updatedAt > utcNow)
        {
            throw CreateArgumentException(nameof(updatedAt));
        }

        this.CreatedAt = createdAt ?? updatedAt ?? utcNow;
        this.UpdatedAt = updatedAt ?? utcNow;
    }

    protected ModelBase(ModelBase original)
    {
        Id = original.Id;
        CreatedAt = original.CreatedAt;
        UpdatedAt = DateTimeOffset.UtcNow;
    }

    //[Key]
    public int Id { get; }

    //[Required]
    public DateTimeOffset CreatedAt { get; }

    //[Required]
    public DateTimeOffset UpdatedAt
    {
        get => _updatedAt;
        private set
        {
            if (value < _updatedAt || value < CreatedAt || value > DateTimeOffset.UtcNow)
            {
                throw CreateArgumentException(nameof(UpdatedAt));
            }

            _updatedAt = value;
        }
    }

    protected static DateOnly ThrowIfFuture(DateOnly value, string propertyName)
    {
        if (value > DateOnly.FromDateTime(DateTime.UtcNow))
        {
            throw CreateArgumentException(propertyName, "The provided date is invalid.");
        }

        return value;
    }

    protected static DateTimeOffset ThrowIfFuture(DateTimeOffset value, string propertyName)
    {
        if (value > DateTimeOffset.UtcNow)
        {
            throw CreateArgumentException(propertyName, "The provided timestamp is invalid.");
        }

        return value;
    }

    protected static TEnum ThrowIfEnumNotDefined<TEnum>(TEnum value, string propertyName)
        where TEnum : struct, Enum
    {
        if (!Enum.IsDefined(value))
        {
            throw CreateArgumentException(propertyName, "The provided enumeration value is invalid.");
        }

        return value;
    }

    protected static string ThrowIfInvalidPhoneNumber(string phoneNumber, string propertyName)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber) || !phoneNumber.All(c => char.IsDigit(c) || "+-()".Contains(c)))
        {
            throw CreateArgumentException(propertyName, "The provided phone number is invalid.");
        }

        return phoneNumber;
    }

    protected static string ThrowIfInvalidEmail(string email, string propertyName)
    {
        if (string.IsNullOrWhiteSpace(email) ||
            email.Count(c => c == '@') != 1 ||
            email.LastIndexOf('.') < email.IndexOf('@'))
        {
            throw CreateArgumentException(propertyName, "The provided email address is invalid.");
        }

        return email;
    }

    protected static string ThrowIfEmpty(string value, string propertyName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw CreateArgumentException(propertyName);
        }

        return value;
    }

    private static Exception CreateArgumentException(string propertyName, string? message = null)
    {
        return new ArgumentException(message ?? "The provided value is invalid.", propertyName);
    }
}
