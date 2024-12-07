using System;
using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace GameOfLife.ViewModels;


public partial class TRex : Animal {
    

    public TRex(Point location, int health, Point velocity) : base (location, health, velocity){

    }

    public override void Tick(){
        Location = Location + Velocity;
        Health--;
    }
}