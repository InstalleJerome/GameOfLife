using System;
using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace GameOfLife.ViewModels;


public partial class TRex : Animal {

    

    public TRex(Point location, int health, Point velocity, DateTime lastPoop) : base (location, health, velocity, lastPoop){

    }

    public override void Poop(){
        lastPoop = DateTime.Now;
    }
    public override void Tick(){
        Location = Location + Velocity;
        Health--;
    }
}