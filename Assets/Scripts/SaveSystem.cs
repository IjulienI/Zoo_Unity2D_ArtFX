using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem instance;
    public GameInfo gameInfo;

    private void Start()
    {
        instance = this;
        Load();
    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/data.save"))
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/data.save");
            gameInfo = JsonUtility.FromJson<GameInfo>(json);
            GameManager.instance.SetResources("money",-GameManager.instance.GetResources("money") + gameInfo.money);
            foreach(AnimalSave i in gameInfo.animals)
            {
                Animal animal = Instantiate(Resources.Load<Animal>("Prefab/" + i.prefabName.Replace("(Clone)", "").Trim()));
                animal.transform.position = new Vector2(i.position.x, i.position.y);
                animal.Name = i.name;
                animal.age = i.age;
                animal.hungerness = i.hungerness;
                animal.thirstness = i.thirstness;
                animal.tiredness = i.tiredness;
                animal.minSpeed = i.minSpeed;
                animal.maxSpeed = i.maxSpeed;

            }
        }
    }

    public void Save()
    {
        int money = GameManager.instance.GetResources("money");
        gameInfo.money = money;

        Animal[] animals = FindObjectsOfType<Animal>();

        gameInfo.animals.Clear();
        for (int i = 0; i < animals.Length; i++)
        {
            gameInfo.animals.Add(new AnimalSave() { position = new Vector2(animals[i].transform.position.x, animals[i].transform.position.y),name = animals[i].Name, 
            age = animals[i].age, hungerness = animals[i].hungerness, thirstness = animals[i].thirstness, tiredness = animals[i].tiredness, minSpeed = animals[i].minSpeed, maxSpeed = animals[i].maxSpeed, prefabName = animals[i].prefab.name } );
        }
        
        string json = JsonUtility.ToJson(gameInfo);
        Debug.Log(Application.persistentDataPath + "/data.save");
        if (!File.Exists(Application.persistentDataPath + "/data.save"))
        {
            File.Create(Application.persistentDataPath + "/data.save").Dispose();
        }
        File.WriteAllText(Application.persistentDataPath + "/data.save", json); 
    }
}
