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
    private Stegosaure stegosaure4;
    private Stegosaure stegosaure5;
    private Plant plant;
    private Plant plant2;
    private TRex trex2;
    private Plant plant3;

    public ObservableCollection<GameObject> GameObjects { get; } = new();

    public MainWindowViewModel(){
        trex = new TRex(RandomLocation(0, Width-100, 0, Height-50), 800, new Point(1.5,1.5), 1000, "male");
        stegosaure = new Stegosaure(RandomLocation(0,Width-100, 0, Height-50), 600, RandomVelocity(-2, 2, -2, 2), 1000, "male");
        plant = new Plant(new Point(Width/2, Height/2), 600, 200, 200, 400);
        stegosaure2 = new Stegosaure(RandomLocation(0,Width-100, 0, Height-50), 600, RandomVelocity(-2,2,-2,2), 1000, "female");
        GameObjects.Add(trex);
        GameObjects.Add(stegosaure);
        GameObjects.Add(plant);
        GameObjects.Add(stegosaure2);
        stegosaure3 = new Stegosaure(RandomLocation(0,Width-100, 0, Height-50), 1200, RandomVelocity(-2,2,-2,2), 1000, "female");
        GameObjects.Add(stegosaure3);
        plant2 = new Plant(RandomLocation(0,Width-100, 0, Height-50), 600, 200, 200, 400);
        GameObjects.Add(plant2);
        trex2 = new TRex(RandomLocation(0, Width-100, 0, Height-50), 800, new Point(1.5, 1.5), 1000, "female");
        GameObjects.Add(trex2);
        stegosaure4 = new Stegosaure(RandomLocation(0,Width-100, 0, Height-50), 600, RandomVelocity(-2, 2, -2, 2), 1000, "female");
        stegosaure5 = new Stegosaure(RandomLocation(0,Width-100, 0, Height-50), 600, RandomVelocity(-2, 2, -2, 2), 1000, "male");
        GameObjects.Add(stegosaure4);
        GameObjects.Add(stegosaure5);
        plant3 = new Plant(RandomLocation(0,Width-100, 0, Height-50), 600, 200, 200, 400);
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
        if (X < 0 || X > Width){
            X = random.Next(minX, maxX);
        }
        if (Y < 0 || Y > Height){
            Y = random.Next(minY, maxY);
        }
        return new Point(X,Y);
    }

    private string RandomSex(){
        double x = random.Next(1,2);
        if (x==1){
            return "female";
        }
        else{
            return "male";
        }
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
                        toAdd.Add(new Plant(RandomLocation((int)obj1.Location.X-obj1.SeedingRadius, (int)obj1.Location.X+obj1.SeedingRadius, (int)obj1.Location.Y-obj1.SeedingRadius, (int)obj1.Location.Y+obj1.SeedingRadius), 600, 200, 200, 400));
                    }
                }
                else if (obj is Stegosaure){
                    Stegosaure obj4 = (Stegosaure)obj;
                    if (obj2 is Plant){
                        if (Distance(obj,obj2)<200){
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
                    if (obj2 is TRex && Distance(obj,obj2)<100){
                        Vector direction = new Vector(-(obj2.Location.X-obj.Location.X), -(obj2.Location.Y-obj.Location.Y));
                        Point dir = (Point)direction.Normalize();
                        double length = Math.Sqrt(Math.Pow(obj4.Velocity.X, 2)+Math.Pow(obj4.Velocity.Y,2));
                        obj4.Velocity = dir*length;
                    }
                    if (obj2 is Stegosaure){
                        Stegosaure obj6 = (Stegosaure)obj2;
                        if (obj4.CanReproduce == true && obj4.Sex == "male" && Distance(obj4,obj6)<400 && obj2 != obj && obj6.Sex=="female"){
                            Vector direction = new Vector(obj2.Location.X-obj.Location.X, obj2.Location.Y-obj.Location.Y);
                            Point dir = (Point)direction.Normalize();
                            double length = Math.Sqrt(Math.Pow(obj4.Velocity.X, 2)+Math.Pow(obj4.Velocity.Y,2));
                            obj4.Velocity = dir*length;
                        }
                        if (Distance(obj,obj2)<100 && obj2 != obj){
                            if (obj4.CanReproduce == true && obj4.Sex == "male" && obj6.CanReproduce == true && obj6.Sex=="female"){
                                obj4.Reproduce();
                                obj6.Reproduce();
                                toAdd.Add(new Stegosaure(new Point((obj4.Location.X+obj6.Location.X)/2, (obj4.Location.Y+obj6.Location.Y)/2), 800, RandomVelocity(-2,2,-2,2), 600, RandomSex()));
                                obj4.Velocity = RandomVelocity(-2,2,-2,2);
                            }
                        }
                        
                    }
                }
                else if (obj is TRex){
                    TRex obj5 = (TRex)obj;
                    if (obj2 is Meat){                        
                        if (Distance(obj,obj2)<100){
                            obj5.Eat();
                            toRemove.Add(obj2);
                        }
                    }
                    if (obj2 is Stegosaure || obj2 is Meat){
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
                        if (obj5.CanReproduce == true && Distance(obj5,obj6)<400 && obj2 != obj && obj6.Sex == "female" && obj5.Sex == "male"){
                            Vector direction = new Vector(obj2.Location.X-obj.Location.X, obj2.Location.Y-obj.Location.Y);
                            Point dir = (Point)direction.Normalize();
                            double length = Math.Sqrt(Math.Pow(obj5.Velocity.X, 2)+Math.Pow(obj5.Velocity.Y,2));
                            obj5.Velocity = dir*length;
                        }
                        if (obj5.CanReproduce == true && obj5.Sex == "male" &&obj6.CanReproduce == true && obj6.Sex == "female"){
                            obj5.Reproduce();
                            obj6.Reproduce();
                            toAdd.Add(new TRex(new Point((obj5.Location.X+obj6.Location.X)/2, (obj5.Location.Y+obj6.Location.Y)/2), 800, RandomVelocity(-2,2,-2,2), 600, RandomSex()));
                            obj5.Velocity = RandomVelocity(-2,2,-2,2);
                            obj6.Velocity = RandomVelocity(-2,2,-2,2);
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
                if (obj.Health<=0){
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
                    
                    if (obj3.Location.Y<0 || obj3.Location.Y>Height-50){
                        obj3.Velocity = new Point(obj3.Velocity.X, -obj3.Velocity.Y);
                    }
                    if (obj3.Location.X>Width-50 || obj3.Location.X<0){
                        obj3.Velocity = new Point(-obj3.Velocity.X, obj3.Velocity.Y);
                    }
                    if (obj3.Location.X<0){
                        obj3.Location = new Point(0,obj3.Location.Y);
                    }
                    if (obj3.Location.X>Width){
                        obj3.Location = new Point(Width,obj3.Location.Y);
                    }
                    if (obj3.Location.Y<0){
                        obj3.Location = new Point(obj3.Location.X, 0);
                    }
                    if (obj3.Location.Y>Height){
                        obj3.Location = new Point(obj3.Location.X, Height);
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
