using System;
using Avalonia;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;

namespace GameOfLife.ViewModels;

public partial class Plant : Living_Object{

    public Plant(Point location, int health, int energy, DateTime lastEat) : base (location, health, energy, lastEat){

    }
    public override void Tick(){
        if (Energy>0){
            Energy--;
        }
        else{
            Health--;
        }
    }
    public override void Eat()
    {
        Energy = Energy + 100;
        lastEat = DateTime.Now;
    }
}