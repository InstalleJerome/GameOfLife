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
    private Stegosaure stegosaure2;
    private Stegosaure stegosaure3;
    private Plant plant;
    public ObservableCollection<GameObject> GameObjects { get; } = new();

    public MainWindowViewModel(){
        trex = new TRex(RandomLocation(0, Width, 0, Height), 500, new Point(1.5,-1.5), 200, DateTime.Now);
        stegosaure = new Stegosaure(new Point(0,0), 600, new Point(1.0, 2.0), 1000);
        plant = new Plant(new Point(Width/2, Height/2), 600, 200, DateTime.Now, 200, 400);
        stegosaure2 = new Stegosaure(new Point(500,400), 600, RandomVelocity(-2,2,-2,2), 1000);
        GameObjects.Add(trex);
        GameObjects.Add(stegosaure);
        GameObjects.Add(plant);
        GameObjects.Add(stegosaure2);
        stegosaure3 = new Stegosaure(new Point(600,600), 1200, RandomVelocity(-2,2,-2,2), 1000);
        GameObjects.Add(stegosaure3);
    }
    private Random random = new Random();

    private Point RandomVelocity(int minX, int maxX, int minY, int maxY){
        double X = random.Next(minX,maxX);
        double Y = random.Next(minY, maxY);
        return new Point(X,Y);
    }
    private Point RandomLocation(int minX, int maxX, int minY, int maxY){
        double X = random.Next(minX, maxX);
        double Y = random.Next(minY, maxY);
        return new Point(X,Y);
    }
    public static double Distance(GameObject obj1, GameObject obj2){
        double x = Math.Sqrt(Math.Pow(obj2.Location.X-obj1.Location.X,2) + Math.Pow(obj2.Location.Y-obj1.Location.Y, 2));
        return x;
    }
    protected override void Tick(){
        List<GameObject> toRemove = new List<GameObject>();
        List<GameObject> toAdd = new List<GameObject>();

        foreach (GameObject obj in GameObjects){
            foreach(GameObject obj2 in GameObjects){
                if (obj is Plant){
                    Plant obj1 = (Plant)obj;
                    if (obj2 is Poop){
                        if (Distance(obj, obj2)<200 && obj1.Energy<100){                        
                            obj1.Eat();
                            toRemove.Add(obj2);
                        }
                    }
                    if (obj1.CanReproduce == true){
                        obj1.Reproduce();
                        toAdd.Add(new Plant(RandomLocation((int)obj1.Location.X-obj1.SeedingRadius, (int)obj1.Location.X+obj1.SeedingRadius, (int)obj1.Location.Y-obj1.SeedingRadius, (int)obj1.Location.Y+obj1.SeedingRadius), 600, 200, DateTime.MinValue, 200, 400));
                    }
                }
                else if (obj is Stegosaure){
                    Stegosaure obj4 = (Stegosaure)obj;
                    if (obj2 is Plant){
                        if (Distance(obj,obj2)<400){
                            Vector direction = new Vector(obj2.Location.X-obj.Location.X, obj2.Location.Y-obj.Location.Y);
                            Point dir = (Point)direction.Normalize();
                            double length = Math.Sqrt(Math.Pow(obj4.Velocity.X, 2)+Math.Pow(obj4.Velocity.Y,2));
                            obj4.Velocity = dir*length;
                        }
                        if (Distance(obj,obj2)<60){
                            obj4.Eat();
                            toRemove.Add(obj2);
                        }
                    }
                    if (obj2 is Stegosaure && Distance(obj,obj2)<100 && obj2 != obj){
                        Stegosaure obj6 = (Stegosaure)obj2;
                        if (obj4.CanReproduce == true && obj6.CanReproduce == true){
                            obj4.Reproduce();
                            obj6.Reproduce();
                            toAdd.Add(new Stegosaure(new Point((obj4.Location.X+obj6.Location.X)/2, (obj4.Location.Y+obj6.Location.Y)/2), 800, RandomVelocity(-2,2,-2,2), 600));
                        }
                        
                    }
                }
                else if (obj is TRex){
                    TRex obj5 = (TRex)obj;
                    if (obj2 is Meat){                        
                        if (Distance(obj,obj2)<200){
                            obj5.Eat();
                            toRemove.Add(obj2);
                        }
                    }
                    if (obj2 is Stegosaure){
                        if (Distance(obj,obj2)<300){
                            Vector direction = new Vector(obj2.Location.X-obj.Location.X, obj2.Location.Y-obj.Location.Y);
                            Point dir = (Point)direction.Normalize();
                            double length = Math.Sqrt(Math.Pow(obj5.Velocity.X, 2)+Math.Pow(obj5.Velocity.Y,2));
                            obj5.Velocity = dir*length; 
                        }
                        if (Distance(obj,obj2)<50 && obj5.CanAttack == true){
                            obj2.Health = obj2.Health-200;
                            obj5.lastAttack = DateTime.Now;
                        }

                    }
                    if (obj2 is TRex && Distance(obj,obj2)<100 && obj2 != obj){
                        TRex obj6 = (TRex)obj2;
                        if (obj5.CanReproduce == true && obj6.CanReproduce == true){
                            obj5.Reproduce();
                            obj6.Reproduce();
                            toAdd.Add(new TRex(new Point((obj5.Location.X+obj6.Location.X)/2, (obj5.Location.Y+obj6.Location.Y)/2), 800, RandomVelocity(-2,2,-2,2), 600, DateTime.MinValue));
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
                    toAdd.Add(new Meat(new Point(obj.Location.X,obj.Location.Y),800));
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
