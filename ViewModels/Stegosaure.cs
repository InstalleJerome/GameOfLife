using System;
using Avalonia;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;

namespace GameOfLife.ViewModels;


public partial class Stegosaure : Animal {
    [ObservableProperty]
    private Type target;

    public Stegosaure(Point location, int health, Point velocity, Type target) : base (location, health, velocity){
        Target = target;
    }

    public void Tick(){
        Location = Location + Velocity;
        Health--;
    }
}