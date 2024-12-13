using System;
using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace GameOfLife.ViewModels;


public partial class TRex : Animal {

    public const int attackCooldown = 2;
    public DateTime lastAttack{get; set;} = DateTime.Now;

    public bool CanAttack {
        get {
            return (DateTime.Now-lastAttack).TotalSeconds>attackCooldown;
        }
    }

    public TRex(Point location, int health, Point velocity, int energy, DateTime lastPoop, DateTime lastAttack) : base (location, health, velocity, energy, lastPoop){
        this.lastAttack = lastAttack;
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
    }
}