using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using GameOfLife.ViewModels;

namespace GameOfLife.ViewModels;

public abstract partial class Living_Object : GameObject{
    [ObservableProperty]
    private int energy;
    public Living_Object(Point location, int energy,int health) : base(location, health){
        Health = health;
        Energy = energy;
    }

    public abstract void Eat();
    public override void Tick(){
    }

}