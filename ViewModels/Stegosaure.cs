using System;
using Avalonia;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;

namespace GameOfLife.ViewModels;


public partial class Stegosaure : Animal {
    
    public Stegosaure(Point location, int health, Point velocity,  int energy, string sex) : base (location, health, velocity, energy, sex){
        
    }

    public override void Reproduce()
    {   if (Sex == "female"){
            lastReproduce = DateTime.Now;
        }
    }
    public override void Poop(){
        lastPoop = DateTime.Now;
    }
    public override void Tick(){
        Location = Location + Velocity;
        if (Energy>0)
        {
            Energy--;   
        }
        else{
            Health--;
        }
    }
    public override void Eat()
    {
        Energy=Energy+100;
    }
}