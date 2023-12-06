using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameInfo
{
    public int money;
    public List<AnimalSave> animals = new List<AnimalSave>();
}

[Serializable]
public struct AnimalSave
{
    public string prefabName;
    public string name; 
    //public int id;
    public int age;
    public int hungerness;
    public int thirstness;
    public int tiredness;
    public float minSpeed;
    public float maxSpeed;
    public Vector2 position;
}
