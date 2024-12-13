using Avalonia;
using Avalonia.Input;
using GameOfLife.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Xml.Serialization;

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
        trex = new TRex(new Point(Width/2-32, Height/2-32), 500, new Point(4.0,2.0), 200, DateTime.MinValue, DateTime.MinValue);
        stegosaure = new Stegosaure(new Point(0,0), 800, new Point(2.5, 2.0), 200, DateTime.MinValue, DateTime.MinValue);
        plant = new Plant(new Point(Width/2, Height/2), 600, 200, DateTime.MinValue);
        GameObjects.Add(trex);
        GameObjects.Add(stegosaure);
        GameObjects.Add(plant);

    }
    public static double Distance(GameObject obj1, GameObject obj2){
        double x =Math.Sqrt(Math.Pow(obj2.Location.X-obj1.Location.X,2)+Math.Pow(obj2.Location.Y-obj1.Location.Y, 2));
        return x;
    }
    protected override void Tick(){
        List<GameObject> toRemove = new List<GameObject>();
        List<GameObject> toAdd = new List<GameObject>();

        foreach (GameObject obj in GameObjects){
            foreach(GameObject obj2 in GameObjects){
                if (obj is Plant && obj2 is Poop){
                    Plant obj1 = (Plant)obj;
                    if (Distance(obj, obj2)<250 && obj1.CanEat == true){                        
                        obj1.Eat();
                        toRemove.Add(obj2);
                    }
                }
                else if (obj is Stegosaure && obj2 is Plant){
                    Stegosaure obj4 = (Stegosaure)obj;
                    if (Distance(obj,obj2)<300 && obj4.CanEat == true){
                        obj4.Eat();
                        toRemove.Add(obj2);
                    } 
                }
                else if (obj is TRex){
                    if (obj2 is Meat){
                        TRex obj5 = (TRex)obj;
                        if (Distance(obj,obj2)<150 && obj5.CanEat == true){
                            obj5.Eat();
                            toRemove.Add(obj2);
                        }
                    }
                    if (obj2 is Stegosaure){
                        if (Distance(obj,obj2)<150){
                            obj2.Health = obj2.Health-100;
                        }
                    }
                }
            }
            if (obj is Meat && obj.Health==0){
                toAdd.Add(new Poop(new Point(obj.Location.X,obj.Location.Y),300));
                toRemove.Add(obj);
            }
            if (obj is Poop && obj.Health==0){
                toRemove.Add(obj);
            }
            if (obj is Living_Object)
            {
                if (obj.Health==0){
                    if (obj is Animal){
                    toAdd.Add(new Meat(new Point(obj.Location.X,obj.Location.Y),200));
                    }
                    if (obj is Plant){
                        toAdd.Add(new Poop(new Point(obj.Location.X,obj.Location.Y),300));
                    }
                    toRemove.Add(obj);
                }
                if (obj is Animal)
            {
                    Animal obj3 = (Animal)obj;
                    if (obj3.CanPoop==true){
                        obj3.Poop();
                        toAdd.Add(new Poop(new Point(obj3.Location.X,obj3.Location.Y),300));
                    }
                    if (obj3.Location.Y<0 || obj3.Location.Y>Height-100){
                        obj3.Velocity = new Point(obj3.Velocity.X, -obj3.Velocity.Y);
                    }
                    if (obj3.Location.X>Width-100 || obj3.Location.X<0){
                        obj3.Velocity = new Point(-obj3.Velocity.X, obj3.Velocity.Y);
                    }
            }
            }
        }

        foreach(GameObject obj in toRemove) {
            GameObjects.Remove(obj);
        }
        foreach(GameObject obj in toAdd){
            GameObjects.Add(obj);
        }

        foreach (GameObject obj in GameObjects){
            obj.Tick();
        }
        
        
    }
    

}
