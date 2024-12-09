using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using GameOfLife.ViewModels;

namespace GameOfLife.ViewModels;

// représente un objet affichable sur l'interface
public abstract partial class GameObject : ViewModelBase
{
    [ObservableProperty]
    private Point _location;

    [ObservableProperty]
    private int _health;

    protected GameObject(Point location, int health)
    {
        Health = health;
        Location = location;
    }
    public abstract void Tick();
}