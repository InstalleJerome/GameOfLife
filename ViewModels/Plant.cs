using System;
using Avalonia;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;

namespace GameOfLife.ViewModels;

public partial class Plant : Living_Object{

    public Plant(Point location, int health, int energy) : base (location, health, energy){

    }
    public override void Tick(){
        Health--;
    }
}