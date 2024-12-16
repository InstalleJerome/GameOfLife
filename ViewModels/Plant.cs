using System;
using Avalonia;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;

namespace GameOfLife.ViewModels;

public partial class Plant : Living_Object{
    [ObservableProperty]
    private int eatingRadius;
    [ObservableProperty]
    private int seedingRadius;
    public Plant(Point location, int health, int energy, DateTime lastReproduce, int eatingRadius, int seedingRadius) : base (location, health, energy){
        EatingRadius = eatingRadius;
        SeedingRadius = seedingRadius;
    }
    public override void Tick(){
        if (Energy>0){
            Energy--;
        }
        else{
            Health--;
        }
    }

    public override void Reproduce()
    {
        lastReproduce = DateTime.Now;
    }
    public override void Eat()
    {
        Energy = Energy + 100;
    }
}