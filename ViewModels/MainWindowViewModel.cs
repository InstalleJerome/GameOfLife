using Avalonia;
using Avalonia.Input;
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
        trex = new TRex(new Point(Width/2-32, Height/2-32), new Point(4.0,2.0), 500, "alive");
        stegosaure = new Stegosaure(new Point(0,0), new Point(2.5, 2.0), 800, "alive");
        plant = new Plant(new Point(Width/2, Height/2),new Point(0.0,0.0),600,"alive");
        GameObjects.Add(trex);
        GameObjects.Add(stegosaure);
        GameObjects.Add(plant);

    }
    protected override void Tick(){

        List<GameObject> toRemove = new List<GameObject>();
        
        foreach (GameObject objet in GameObjects){
            if (objet.Location.Y<0 || objet.Location.Y>Height-100){
                objet.Velocity = new Point(objet.Velocity.X, -objet.Velocity.Y);
            }
            if (objet.Location.X>Width-100 || objet.Location.X<0){
                objet.Velocity = new Point(-objet.Velocity.X, objet.Velocity.Y);
            }
            if (objet.Health<=0 && objet.Status == "alive"){
                objet.Velocity = new Point(0.0, 0.0);
                objet.Status = "dead";
                objet.Health = 500;
            }
            if (objet.Health<=0 && objet.Status == "dead"){
                objet.Status = "rotting";
                objet.Health = 500;
            }
            if (objet.Health<=0 && objet.Status=="rotting"){
                toRemove.Add(objet);
            }
            Console.WriteLine("Tick window");
        }

        foreach(GameObject obj in toRemove) {
            GameObjects.Remove(obj);
        }


        foreach (GameObject objet in GameObjects){
            objet.Tick();
        }
    }
    

}
