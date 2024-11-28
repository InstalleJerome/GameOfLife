using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace GameOfLife.ViewModels;

// représente un objet affichable sur l'interface
public abstract partial class GameObject : ViewModelBase
{
    [ObservableProperty]
    private Point _location;
    [ObservableProperty]
    private Point _velocity;
    [ObservableProperty]
    private int _health;
    [ObservableProperty]
    private string _status;
    protected GameObject(Point location, Point velocity, int health, string status)
    {
        Location = location;
        Velocity = velocity;
        Health = health;
        Status = status;
    }
    public abstract void Tick();
}