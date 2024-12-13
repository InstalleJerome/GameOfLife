using System;
using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace GameOfLife.ViewModels;


public partial class TRex : Animal {

    

    public TRex(Point location, int health, Point velocity, int energy, DateTime lastPoop, DateTime lastEat) : base (location, health, velocity, energy, lastPoop, lastEat){

    }

    public override void Poop(){
        lastPoop = DateTime.Now;
    }
    public override void Tick(){
        Location = Location + Velocity;
        if (Energy>0){
            Energy--;
        }
        else{
            Health--;
        }
    }

    public override void Eat()
    {
        Energy=Energy+100;
        lastEat = DateTime.Now;
    }
}