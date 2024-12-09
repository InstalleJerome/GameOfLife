using System;
using Avalonia;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;

namespace GameOfLife.ViewModels;


public partial class Stegosaure : Animal {
    
    public Stegosaure(Point location, int health, Point velocity,  int energy, DateTime lastPoop) : base (location, health, velocity, energy, lastPoop){
        
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
}