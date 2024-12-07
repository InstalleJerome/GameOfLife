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
        trex = new TRex(new Point(Width/2-32, Height/2-32), 500, new Point(4.0,2.0));
        stegosaure = new Stegosaure(new Point(0,0), 800, new Point(2.5, 2.0));
        plant = new Plant(new Point(Width/2, Height/2),600);
        GameObjects.Add(trex);
        GameObjects.Add(stegosaure);
        GameObjects.Add(plant);

    }
    protected override void Tick(){
        Console.WriteLine("global tick");
        List<GameObject> toRemove = new List<GameObject>();
        List<GameObject> toAdd = new List<GameObject>();

        foreach (GameObject obj in GameObjects){
            if (obj is Living_Object)
            {
                Living_Object obj2 = (Living_Object)obj;
                Console.WriteLine("life tick");
                if (obj2.Health==0){
                    toRemove.Add(obj2);
                    toAdd.Add(new Meat(new Point(trex.Location.X,trex.Location.Y),100));
                }
                if (obj is Animal)
            {
                Animal obj3 = (Animal)obj2;
                Console.WriteLine("animal ok");
                if (obj3.Location.Y<0 || obj3.Location.Y>Height-100){
                    Console.WriteLine("out of border");
                    obj3.Velocity = new Point(obj3.Velocity.X, -obj3.Velocity.Y);
                }
                if (obj3.Location.X>Width-100 || obj3.Location.X<0){
                    obj3.Velocity = new Point(-obj3.Velocity.X, obj3.Velocity.Y);
                }
            }
            }
        }

        Console.WriteLine("ok fine");
        foreach(GameObject obj in toRemove) {
            Console.WriteLine("remove");
            GameObjects.Remove(obj);
        }
        foreach(GameObject obj in toAdd){
            GameObjects.Add(obj);
        }
        toAdd=new List<GameObject>();

        foreach (GameObject obj in GameObjects){
            obj.Tick();
            Console.WriteLine("tick");
        }
        
        
    }
    

}
