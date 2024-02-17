// <copyright file="RelayCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRepairShopSolution.UI.Win.Commands;

using System;

public class RelayCommand : CommandBase
{
    private readonly Action _execute;
    private readonly Predicate<object?>? _canExecute;

    public RelayCommand(Action execute, Predicate<object?>? canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    public override bool CanExecute(object? parameter)
    {
        return _canExecute?.Invoke(parameter) ?? true;
    }

    public override void Execute(object? parameter)
    {
        _execute();
    }
}
