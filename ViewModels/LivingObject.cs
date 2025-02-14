using System;
using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using GameOfLife.ViewModels;

namespace GameOfLife.ViewModels;

public abstract partial class Living_Object : GameObject{
    [ObservableProperty]
    private int energy;

    public const int ReproduceCooldown = 3;
    public DateTime lastReproduce{get; set;}

    public bool CanReproduce{
        get{
            return(DateTime.Now-lastReproduce).TotalSeconds>ReproduceCooldown;
        }
    }

    public abstract void Reproduce();

    public Living_Object(Point location, int energy,int health) : base(location, health){
        Health = health;
        Energy = energy;
        this.lastReproduce = DateTime.Now;
    }
    

    public abstract void Eat();
    public override void Tick(){
    }

}