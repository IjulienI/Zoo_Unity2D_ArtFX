using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    [Header("Ui References")]
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private UIManager uiManager;

    [Header("Animals References")]
    [SerializeField] private GameObject zebra;
    [SerializeField] private GameObject koala;
    [SerializeField] private GameObject capybara;
    [SerializeField] private GameObject lemur;
    [SerializeField] private GameObject redPanda;
    [SerializeField] private GameObject lion;
    [SerializeField] private GameObject lynx;
    [SerializeField] private GameObject penguin;

    [Header("Animals Price")]
    [SerializeField] private int zebraPrice;
    [SerializeField] private int koalaPrice;
    [SerializeField] private int capybaraPrice;
    [SerializeField] private int lemurPrice;
    [SerializeField] private int redPandaPrice;
    [SerializeField] private int lionPrice;
    [SerializeField] private int lynxPrice;
    [SerializeField] private int penguinPrice;

    [Header("Enclot References")]
    [SerializeField] private GameObject zebraEnclot;
    [SerializeField] private GameObject koalaEnclot;
    [SerializeField] private GameObject capybaraEnclot;
    [SerializeField] private GameObject lemurEnclot;
    [SerializeField] private GameObject redPandaEnclot;
    [SerializeField] private GameObject lionEnclot;
    [SerializeField] private GameObject lynxEnclot;
    [SerializeField] private GameObject penguinEnclot;
    private bool isPaused;
    private float money;
    private float meat;
    private float fish;
    private float vegetable;
    private Animal[] animals;
    private float animalMoney;

    private int zebraCount = 0;
    private int koalaCount = 0;
    private int capybaraCount = 0;
    private int lemurCount = 0;
    private int redPandaCount = 0;
    private int lionCount = 0;
    private int lynxCount = 0;
    private int penguinCount = 0;

    private GameObject target;

    private void Awake()
    {
        instance = this;
        Invoke("UpdateAnimalCount", 0.1f);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !uiManager.GetOnShop() || Input.GetKeyDown(KeyCode.Escape) && !uiManager.GetOnInfo() && !uiManager.GetOnShop())
        {
            ChangePause();
        }
         money += (animalMoney / 2) * Time.deltaTime;
    }

    public void UpdateAnimals()
    {
        animals = FindObjectsOfType<Animal>();
        CalculMoney();
    }

    private void CalculMoney()
    {
        animalMoney = 0;
        foreach (var a in animals)
        {
             animalMoney += a.moneyGain * (3 * (a.level + 1));
        }
    }

    public bool GetIsPaused()
    {
        return isPaused;
    }

    public void ChangePause()
    {
        isPaused = !isPaused;
        if (!uiManager.GetOnInfo())
        {
            pauseMenu.SetActive(isPaused);
        }
    }

    public float GetResources(string type)
    {
        if(type.ToLower() == "money")
        {
            return money;
        }
        if (type.ToLower() == "vegetable")
        {
            return vegetable;
        }
        if (type.ToLower() == "meat")
        {
            return meat;
        }
        if (type.ToLower() == "fish")
        {
            return fish;
        }
        return 0;
    }

    public void SetResources(string type,float amount)
    {
        if (type.ToLower() == "money")
        {
            money += amount;
        }
        else if (type.ToLower() == "vegetable")
        {
            vegetable += amount;
        }
        else if (type.ToLower() == "meat")
        {
            meat += amount;
        }
        else if (type.ToLower() == "fish")
        {
            fish += amount;
        }
    }

    public int GetAnimalPrice(string name)
    {
        if(name.ToLower() == "zebra")
        {
            return zebraPrice;
        }
        else if (name.ToLower() == "koala")
        {
            return koalaPrice;
        }
        else if (name.ToLower() == "capybara")
        {
            return capybaraPrice;
        }
        else if (name.ToLower() == "lemur")
        {
            return lemurPrice;
        }
        else if (name.ToLower() == "redpanda")
        {
            return redPandaPrice;
        }
        else if (name.ToLower() == "lion")
        {
            return lionPrice;
        }
        else if (name.ToLower() == "lynx")
        {
            return lynxPrice;
        }
        else if (name.ToLower() == "penguin")
        {
            return penguinPrice;
        }
        return 999999999;
    }

    public void SetAnimalPrice(string name, float amount)
    {
        if (name.ToLower() == "zebra")
        {
            zebraPrice = ((int)MathF.Round(amount));
        }
        else if (name.ToLower() == "koala")
        {
            koalaPrice = ((int)MathF.Round(amount));
        }
        else if (name.ToLower() == "capybara")
        {
            capybaraPrice = ((int)MathF.Round(amount));
        }
        else if (name.ToLower() == "lemur")
        {
            lemurPrice = ((int)MathF.Round(amount));
        }
        else if (name.ToLower() == "redpanda")
        {
            redPandaPrice = ((int)MathF.Round(amount));
        }
        else if (name.ToLower() == "lion")
        {
            lionPrice = ((int)MathF.Round(amount));
        }
        else if (name.ToLower() == "lynx")
        {
            lynxPrice = ((int)MathF.Round(amount));
        }
        else if (name.ToLower() == "penguin")
        {
            penguinPrice = ((int)MathF.Round(amount));
        }
    }

    public GameObject GetAnimal(string name)
    {
        if (name.ToLower() == "zebra")
        {
            return zebra;
        }
        else if (name.ToLower() == "koala")
        {
            return koala;
        }
        else if (name.ToLower() == "capybara")
        {
            return capybara;
        }
        else if (name.ToLower() == "lemur")
        {
            return lemur;
        }
        else if (name.ToLower() == "redpanda")
        {
            return redPanda;
        }
        else if (name.ToLower() == "lion")
        {
            return lion;
        }
        else if (name.ToLower() == "lynx")
        {
            return lynx;
        }
        else if (name.ToLower() == "penguin")
        {
            return penguin;
        }
        return null;
    }

    public GameObject GetAnimalEnclot(string name)
    {
        if (name.ToLower() == "zebra")
        {
            return zebraEnclot;
        }
        else if (name.ToLower() == "koala")
        {
            return koalaEnclot;
        }
        else if (name.ToLower() == "capybara")
        {
            return capybaraEnclot;
        }
        else if (name.ToLower() == "lemur")
        {
            return lemurEnclot;
        }
        else if (name.ToLower() == "redpanda")
        {
            return redPandaEnclot;
        }
        else if (name.ToLower() == "lion")
        {
            return lionEnclot;
        }
        else if (name.ToLower() == "lynx")
        {
            return lynxEnclot;
        }
        else if (name.ToLower() == "penguin")
        {
            return penguinEnclot;
        }
        return null;
    }

    public int GetAnimalCount(string name)
    {
        if (name.ToLower() == "zebra")
        {
            return zebraCount;
        }
        else if (name.ToLower() == "koala")
        {
            return koalaCount;
        }
        else if (name.ToLower() == "capybara")
        {
            return capybaraCount;
        }
        else if (name.ToLower() == "lemur")
        {
            return lemurCount;
        }
        else if (name.ToLower() == "redpanda")
        {
            return redPandaCount;
        }
        else if (name.ToLower() == "lion")
        {
            return lionCount;
        }
        else if (name.ToLower() == "lynx")
        {
            return lynxCount;
        }
        else if (name.ToLower() == "penguin")
        {
            return penguinCount;
        }
        return -1;
    }

    public void SetAnimalCount(string name)
    {
        if (name.ToLower() == "zebra")
        {
            zebraCount++;
        }
        else if (name.ToLower() == "koala")
        {
            koalaCount++;
        }
        else if (name.ToLower() == "capybara")
        {
            capybaraCount++;
        }
        else if (name.ToLower() == "lemur")
        {
            lemurCount++;
        }
        else if (name.ToLower() == "redpanda")
        {
            redPandaCount++;
        }
        else if (name.ToLower() == "lion")
        {
            lionCount++;
        }
        else if (name.ToLower() == "lynx")
        {
            lynxCount++;
        }
        else if (name.ToLower() == "penguin")
        {
            penguinCount++;
        }
    }

    public GameObject GetTarget()
    {
        return target;
    }

    public void SetTarget(GameObject obj)
    {
        target = obj;
    }

    private void UpdateAnimalCount()
    {
        if(animals != null)
        {
            foreach (var a in animals)
            {
                SetAnimalCount(a.name.Replace("(Clone)", "").Trim());
            }
        }
    }
}
