using System;
using Avalonia;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;

namespace GameOfLife.ViewModels;

public partial class Plant : GameObject{

    public Plant(Point location, Point velocity, int health, string status) : base (location, velocity, health, status){

    }
    public override void Tick(){
        Health--;
    }
}