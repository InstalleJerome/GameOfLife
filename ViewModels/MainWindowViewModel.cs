using Avalonia;
using Avalonia.Input;
using GameOfLife.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Threading;

namespace GameOfLife.ViewModels;

public partial class MainWindowViewModel : GameBase
{
    public int Width { get; } = 1100;
    public int Height { get; } = 750;

    private TRex trex;
    private Stegosaure stegosaure;
    private Plant plant;
    public ObservableCollection<GameObject> GameObjects { get; } = new();

    public MainWindowViewModel(){
        trex = new TRex(new Point(Width/2-32, Height/2-32), 500, new Point(4.0,2.0), null);
        stegosaure = new Stegosaure(new Point(0,0), 800, new Point(2.5, 2.0), null);
        plant = new Plant(new Point(Width/2, Height/2),600, null);
        GameObjects.Add(trex);
        GameObjects.Add(stegosaure);
        GameObjects.Add(plant);

    }
    protected override void Tick(){

        List<GameObject> toRemove = new List<GameObject>();
        
        foreach (Animal objet in GameObjects){
            if (objet.Location.Y<0 || objet.Location.Y>Height-100){
                objet.Velocity = new Point(objet.Velocity.X, -objet.Velocity.Y);
            }
            if (objet.Location.X>Width-100 || objet.Location.X<0){
                objet.Velocity = new Point(-objet.Velocity.X, objet.Velocity.Y);
            }
        }
        foreach (Living_Object obj in GameObjects){
            if (obj.Health==0){
                toRemove.Add(obj);
            }
        }

        foreach(GameObject obj in toRemove) {
            GameObjects.Remove(obj);
        }


        foreach (Stegosaure objet in GameObjects){
            objet.Tick();
        }
        foreach (TRex objet in GameObjects){
            objet.Tick();
        }
        foreach (Plant objet in GameObjects){
            objet.Tick();
        }
        foreach (Meat objet in GameObjects){
            objet.Tick();
        }
        
    }
    

}
