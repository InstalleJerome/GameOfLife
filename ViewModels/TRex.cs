using System;
using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace GameOfLife.ViewModels;


public partial class TRex : Animal {
    [ObservableProperty]
    private Type target;

    public TRex(Point location, int health, Point velocity, Type target) : base (location, health, velocity){
        Target = target;
    }

    public void Tick(){
        Location = Location + Velocity;
        Health--;
    }
}