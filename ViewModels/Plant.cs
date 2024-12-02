using System;
using Avalonia;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;

namespace GameOfLife.ViewModels;

public partial class Plant : Living_Object{

    public Plant(Point location, int health) : base (location, health){

    }
    public void Tick(){
        Health--;
    }
}