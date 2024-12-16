using System;
using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using GameOfLife.ViewModels;

namespace GameOfLife.ViewModels;


public abstract partial class Animal : Living_Object{
    [ObservableProperty]
    private Point velocity;

    public const int PoopCooldown = 5;
    public DateTime lastPoop{get; set;} = DateTime.Now;

    public bool CanPoop {
        get {
            return (DateTime.Now-lastPoop).TotalSeconds>PoopCooldown;
        }
    }

    
    
    
    public abstract void Poop();

    public Animal(Point location, int health, Point velocity, int energy, DateTime lastPoop, DateTime lastReproduce) : base(location, health, energy, lastReproduce){
        Velocity = velocity;
        this.lastPoop = lastPoop;
    }
}