using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using GameOfLife.ViewModels;

namespace Pong.ViewModels;

public partial class Living_Object : GameObject{
    [ObservableProperty]
    private int health;
    public Living_Object(Point location, int health) : base(location){
        Health = health;
    }
}