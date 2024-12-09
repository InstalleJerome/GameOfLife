using System;
using Avalonia;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;

namespace GameOfLife.ViewModels;


public partial class Stegosaure : Animal {
    
    public Stegosaure(Point location, int health, Point velocity, DateTime lastPoop) : base (location, health, velocity, lastPoop){
        
    }
    

    public override void Poop(){
        lastPoop = DateTime.Now;
    }
    public override void Tick(){
        Location = Location + Velocity;
        Health--;
    }
}