using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameInfo
{
    public int money;
    public int zebra;
    public int koala;
    public int capybara;
    public int lemur;
    public int redPanda;
    public int lion;
    public int lynx;
    public int penguin;
    public List<AnimalSave> animals = new List<AnimalSave>();
}

[Serializable]
public struct AnimalSave
{
    public string prefabName;
    public string name; 
    public int age;
    public int hungerness;
    public int thirstness;
    public int tiredness;
    public float minSpeed;
    public float maxSpeed;
    public Vector2 position;
}