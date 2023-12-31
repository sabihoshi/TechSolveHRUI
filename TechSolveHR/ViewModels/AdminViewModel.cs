﻿using Stylet;
using StyletIoC;
using TechSolveHR.Models;

namespace TechSolveHR.ViewModels;

public class AdminViewModel : Screen
{
    private readonly IContainer _ioc;
    private readonly DatabaseContext _db;
    private readonly MainWindowViewModel _main;
    private bool _initialized;

    public AdminViewModel(IContainer ioc, DatabaseContext db, MainWindowViewModel main)
    {
        _ioc  = ioc;
        _db   = db;
        _main = main;

        UserInfoView = _ioc.Get<PersonalInfoViewModel>();
        UserListView = _ioc.Get<EmployeeListViewModel>();

        UserListView.EmployeeSelected += (_, _) => OnEmployeeSelected();
        UserListView.ShowDeleteButton =  true;
    }

    public Employee SelectedEmployee
    {
        get => UserListView.SelectedEmployee!;
        set => UserListView.SelectedEmployee = value;
    }

    public EmployeeListViewModel UserListView { get; }

    public int SelectedIndex { get; set; }

    public PersonalInfoViewModel UserInfoView { get; }

    protected override void OnActivate()
    {
        UserListView.Activate();
        UserInfoView.Activate();
    }

    private void OnEmployeeSelected()
    {
        UserInfoView.Employee = SelectedEmployee;
        SelectedIndex         = 1;

        UserInfoView.Activate();
    }
}