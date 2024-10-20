using System;
using System.Collections.Generic;
using System.Linq;

public class Creature
{
    public string Name { get; }
    public string Kind { get; }
    public int Health { get; }
    public List<string> Abilities { get; }

    public Creature(string name, string kind, int health, string abilities)
    {
        Name = name;
        Kind = kind;
        Health = health;
        Abilities = abilities.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    public override string ToString()
    {
        string abilitiesString = string.Join(", ", Abilities);
        return $"{Name} ({Kind}) has {Health} HP\nAbilities: {abilitiesString}";
    }
}
