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

            }
        }
    }

    public void Save()
    {
        int money = GameManager.instance.GetResources("money");
        gameInfo.money = money;
        
        string json = JsonUtility.ToJson(gameInfo);
        Debug.Log(Application.persistentDataPath + "/data.save");
        if (!File.Exists(Application.persistentDataPath + "/data.save"))
        {
            File.Create(Application.persistentDataPath + "/data.save").Dispose();
        }
        File.WriteAllText(Application.persistentDataPath + "/data.save", json); 
    }
}
