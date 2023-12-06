using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Ui References")]
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject shop;
    [SerializeField] private GameObject animalShop;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject usedMenu;
    [SerializeField] private GameObject infoAnimal;
    //[SerializeField] private GameObject mainMenu;

    private bool onShop;
    private bool onInfo;

    private void Update()
    {
        if (onShop && Input.GetKeyDown(KeyCode.Escape))
        {
            usedMenu.SetActive(false);
            onShop = false;
            pauseMenu.SetActive(true);
        }
        if(onInfo && Input.GetKeyDown(KeyCode.Escape))
        {
            onInfo = false;
            usedMenu.SetActive(false);
        }
    }
    public void Return()
    {
        gameManager.ChangePause();
    }

    public void Shop()
    {
        onShop = true;
        pauseMenu.SetActive(false);
        shop.SetActive(true);
        usedMenu = shop;
    }

    public void AnimalShop()
    {
        onShop = true;
        pauseMenu.SetActive(false);
        animalShop.SetActive(true);
        usedMenu = animalShop;
    }

    public void AnimalInfo()
    {
        onInfo = true;
        infoAnimal.SetActive(true);
        usedMenu = infoAnimal;
    }

    public bool GetOnShop()
    {
        return onShop;
    }

    public bool GetOnInfo()
    {
        return onInfo;
    }

    public void BuyZebra()
    {
        if(gameManager.GetAnimalPrice("zebra") == 0)
        {
            gameManager.SetAnimalPrice("zebra", 15);
            Instantiate(gameManager.GetAnimal("zebra"), gameManager.GetAnimalEnclot("zebra").transform.position, gameManager.GetAnimalEnclot("zebra").transform.rotation);
        }
        else if(gameManager.GetResources("money") >= gameManager.GetAnimalPrice("zebra"))
        {
            gameManager.SetResources("money", -gameManager.GetAnimalPrice("zebra"));
            gameManager.SetAnimalPrice("zebra", gameManager.GetAnimalPrice("zebra") * 2);
            Instantiate(gameManager.GetAnimal("zebra"), gameManager.GetAnimalEnclot("zebra").transform.position, gameManager.GetAnimalEnclot("zebra").transform.rotation);
        }
        SaveSystem.instance.Save();
    }
}
