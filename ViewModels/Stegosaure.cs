using System;
using Avalonia;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;

namespace GameOfLife.ViewModels;


public partial class Stegosaure : Animal {
    
    public Stegosaure(Point location, int health, Point velocity) : base (location, health, velocity){
        
    }

    public override void Tick(){
        Location = Location + Velocity;
        Health--;
    }
}