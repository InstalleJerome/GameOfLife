using System;
using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using GameOfLife.ViewModels;

namespace GameOfLife.ViewModels;


public abstract partial class Animal : Living_Object{
    [ObservableProperty]
    private Point velocity;

    [ObservableProperty]
    private string sex;

    public const int PoopCooldown = 8;
    public DateTime lastPoop{get; set;}
    
    public bool CanPoop {
        get {
            return (DateTime.Now-lastPoop).TotalSeconds>PoopCooldown;
        }
    }

    
    
    
    public abstract void Poop();

    public Animal(Point location, int health, Point velocity, int energy, string sex) : base(location, health, energy){
        Velocity = velocity;
        this.lastPoop = DateTime.Now;
        Sex = sex;
    }
}