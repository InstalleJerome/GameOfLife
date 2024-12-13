using System;
using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using GameOfLife.ViewModels;

namespace GameOfLife.ViewModels;

public abstract partial class Living_Object : GameObject{
    [ObservableProperty]
    private int energy;

    public const int EatCooldown = 3;
    public DateTime lastEat{get; set;} = DateTime.Now;

    public bool CanEat {
        get {
            return (DateTime.Now-lastEat).TotalSeconds>EatCooldown;
        }
    }
    public Living_Object(Point location, int energy,int health, DateTime lastEat) : base(location, health){
        Health = health;
        Energy = energy;
        this.lastEat = lastEat;
    }
    

    public abstract void Eat();
    public override void Tick(){
    }

}