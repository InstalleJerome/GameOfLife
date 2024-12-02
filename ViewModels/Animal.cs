using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using GameOfLife.ViewModels;

namespace GameOfLife.ViewModels;


public partial class Animal : Living_Object{
    [ObservableProperty]
    private Point velocity;
    public Animal(Point location, int health, Point velocity) : base(location, health){
        Velocity = velocity;
    }
}