using System;
using Avalonia;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;

namespace GameOfLife.ViewModels;

public partial class Meat : GameObject{

    public Meat(Point location, int health) : base (location, health){

    }

    public override void Tick(){
        Health--;
    }
}