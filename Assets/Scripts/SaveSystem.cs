using System;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem instance;
    public GameInfo gameInfo;
    public GameObject cheatScreen;

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

            if (File.GetLastWriteTime(Application.persistentDataPath + "/data.save").ToString(CultureInfo.CurrentCulture) == gameInfo.modificationDate)
            {
                LoadAnimals();
                LoadGameManager();
            }
            else
            {
                File.Delete(Application.persistentDataPath + "/data.save");
                cheatScreen.SetActive(true);
            }
        }
    }

    public void Save()
    {
        SaveGameManager();
        SaveAnimals();

        gameInfo.modificationDate = DateTime.ParseExact(DateTime.Now.ToString("U"), "U", CultureInfo.CurrentCulture).ToString(CultureInfo.CurrentCulture);

        string json = JsonUtility.ToJson(gameInfo);
        if (!File.Exists(Application.persistentDataPath + "/data.save"))
        {
            File.Create(Application.persistentDataPath + "/data.save").Dispose();
        }        
        File.WriteAllText(Application.persistentDataPath + "/data.save", json); 
    }

    private void LoadAnimals()
    {
        foreach (AnimalSave i in gameInfo.animals)
        {
            Animal animal = Instantiate(Resources.Load<Animal>("Prefab/Animals/" + i.prefabName.Replace("(Clone)", "").Trim()));
            animal.transform.position = i.position;
            animal.transform.localScale = i.size;
            animal.Name = i.name;
            animal.age = i.age;
            animal.hungerness = i.hungerness;
            animal.thirstness = i.thirstness;
            animal.tiredness = i.tiredness;
            animal.minSpeed = i.minSpeed;
            animal.maxSpeed = i.maxSpeed;
            animal.foodNeed = i.foodNeed;
            animal.xp = i.xp;
            animal.maxXp = i.maxXp;
            animal.level = i.level;
        }
    }
    private void LoadGameManager()
    {
        GameManager.instance.SetAnimalPrice("zebra", gameInfo.zebra);
        GameManager.instance.SetAnimalPrice("koala", gameInfo.koala);
        GameManager.instance.SetAnimalPrice("capybara", gameInfo.capybara);
        GameManager.instance.SetAnimalPrice("lemur", gameInfo.lemur);
        GameManager.instance.SetAnimalPrice("redpanda", gameInfo.redPanda);
        GameManager.instance.SetAnimalPrice("lion", gameInfo.lion);
        GameManager.instance.SetAnimalPrice("lynx", gameInfo.lynx);
        GameManager.instance.SetAnimalPrice("penguin", gameInfo.penguin);

        GameManager.instance.SetResources("money", -GameManager.instance.GetResources("money") + gameInfo.money);
        GameManager.instance.SetResources("vegetable", gameInfo.vegetable);
        GameManager.instance.SetResources("meat", gameInfo.meat);
        GameManager.instance.SetResources("fish", gameInfo.fish);
    }

    private void SaveGameManager()
    {
        gameInfo.zebra = GameManager.instance.GetAnimalPrice("zebra");
        gameInfo.koala = GameManager.instance.GetAnimalPrice("koala");
        gameInfo.capybara = GameManager.instance.GetAnimalPrice("capybara");
        gameInfo.lemur = GameManager.instance.GetAnimalPrice("lemur");
        gameInfo.redPanda = GameManager.instance.GetAnimalPrice("redpanda");
        gameInfo.lion = GameManager.instance.GetAnimalPrice("lion");
        gameInfo.lynx = GameManager.instance.GetAnimalPrice("lynx");
        gameInfo.penguin = GameManager.instance.GetAnimalPrice("penguin");

        gameInfo.money = GameManager.instance.GetResources("money");
        gameInfo.meat = GameManager.instance.GetResources("meat");
        gameInfo.fish = GameManager.instance.GetResources("fish");
        gameInfo.vegetable = GameManager.instance.GetResources("vegetable");
    }
    private void SaveAnimals()
    {
        Animal[] animals = FindObjectsOfType<Animal>();

        gameInfo.animals.Clear();
        for (int i = 0; i < animals.Length; i++)
        {
            gameInfo.animals.Add(new AnimalSave()
            {
                position = new Vector2(animals[i].transform.position.x, animals[i].transform.position.y),
                size = new Vector2(animals[i].transform.localScale.x, animals[i].transform.localScale.y),
                name = animals[i].Name,
                age = animals[i].age,
                hungerness = animals[i].hungerness,
                thirstness = animals[i].thirstness,
                tiredness = animals[i].tiredness,
                minSpeed = animals[i].minSpeed,
                maxSpeed = animals[i].maxSpeed,
                prefabName = animals[i].prefab.name,
                xp = animals[i].xp,
                maxXp = animals[i].maxXp,
                level = animals[i].level,
                foodNeed = animals[i].foodNeed,
            });
        }
    }
}
