using UnityEngine;

public class GameManager : MonoBehaviour
{
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
    private int money = 999999999;
    private int meat;
    private int fish;
    private int vegetable;

    private GameObject target;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !uiManager.GetOnShop() || Input.GetKeyDown(KeyCode.Escape) && !uiManager.GetOnInfo() && !uiManager.GetOnShop())
        {
            ChangePause();
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

    public int GetResources(string type)
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

    public void SetResources(string type,int amount)
    {
        if (type.ToLower() == "money")
        {
            money += amount;
            Debug.Log("Money : "+ money);
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
        return 0;
    }

    public void SetAnimalPrice(string name, int amount)
    {
        if (name.ToLower() == "zebra")
        {
            zebraPrice = amount;
        }
        else if (name.ToLower() == "koala")
        {
            koalaPrice = amount;
        }
        else if (name.ToLower() == "capybara")
        {
            capybaraPrice = amount;
        }
        else if (name.ToLower() == "lemur")
        {
            lemurPrice = amount;
        }
        else if (name.ToLower() == "redpanda")
        {
            redPandaPrice = amount;
        }
        else if (name.ToLower() == "lion")
        {
            lionPrice = amount;
        }
        else if (name.ToLower() == "lynx")
        {
            lynxPrice = amount;
        }
        else if (name.ToLower() == "penguin")
        {
            penguinPrice = amount;
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

    public GameObject GetTarget()
    {
        return target;
    }

    public void SetTarget(GameObject obj)
    {
        target = obj;
    }
}
