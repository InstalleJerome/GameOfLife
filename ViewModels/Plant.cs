using System;
using Avalonia;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;

namespace GameOfLife.ViewModels;

public partial class Plant : Living_Object{

    public Plant(Point location, int health, int energy, DateTime lastReproduce) : base (location, health, energy, lastReproduce){

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