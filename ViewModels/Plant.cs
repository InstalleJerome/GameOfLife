using System;
using Avalonia;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;

namespace GameOfLife.ViewModels;

public partial class Plant : Living_Object{
    [ObservableProperty]
    private Type target;

    public Plant(Point location, int health, Type target) : base (location, health){
        Target = target;
    }
    public void Tick(){
        Health--;
    }
}