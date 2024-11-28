using System;
using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace GameOfLife.ViewModels;


public partial class TRex : GameObject {

    public TRex(Point location, Point velocity, int health, string status) : base (location, velocity, health, status){

    }

    public override void Tick(){
        Location = Location + Velocity;
        Health--;
    }
}