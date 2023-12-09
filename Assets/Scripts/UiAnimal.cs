using TMPro;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.UI;

public class UiAnimal : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private TextMeshProUGUI Name;
    [SerializeField] private TextMeshProUGUI needFoodText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI foodText;
    [SerializeField] private TextMeshProUGUI levelFoodText;
    [SerializeField] private Slider xpSlider;
    [SerializeField] private Sprite[] foodSprites;
    [SerializeField] private Image[] foodImages;



    private void Update()
    {
        if(gameManager.GetTarget() != null)
        {
            if(gameManager.GetTarget().GetComponent<Animal>().Name != null)
            {
                Animal animal = gameManager.GetTarget().GetComponent<Animal>();
                SetTexts(animal);
                SetSlider(animal);
                SetFoodSprite(animal);
            }
        }
    }

    public void Feed()
    {
        Animal animal = gameManager.GetTarget().GetComponent<Animal>();
        if (gameManager.GetResources(animal.GetAlimentationType()) >= animal.foodNeed)
        {
            animal.Eat();
        }
        SaveSystem.instance.Save();
    }

    public void FeedOneLevel()
    {
        Animal animal = gameManager.GetTarget().GetComponent<Animal>();
        int temp = gameManager.GetResources(animal.GetAlimentationType());
        Debug.Log(temp);
        for(int i = 0; i < animal.foodNeededLevel; i++)
        {
            temp = temp - animal.foodNeed;
        }
        if(temp >= 0)
        {
            for (int i = 0; i < animal.foodNeededLevel; i++)
            {
                animal.Eat();
            }
            animal.ReturnNextLevelValue();
            SaveSystem.instance.Save();
        }
    }

    private void SetTexts(Animal animal)
    {
        Name.text = animal.Name;
        needFoodText.text = animal.foodNeed.ToString();
        levelText.text = ("LVL : " + animal.level.ToString());
        foodText.text = gameManager.GetResources(animal.GetAlimentationType()).ToString();
        levelFoodText.text = (animal.foodNeededLevel * animal.foodNeed).ToString();
    }

    private void SetSlider(Animal animal)
    {
        xpSlider.value = (animal.xp / animal.maxXp);
    }

    private void SetFoodSprite(Animal animal)
    {
        foreach (Image image in foodImages)
        {
            if (animal.GetAlimentationType().ToLower() == "fish")
            {
                image.sprite = foodSprites[0]; 
            }
            if (animal.GetAlimentationType().ToLower() == "vegetable")
            {
                image.sprite = foodSprites[1];
            }
            if (animal.GetAlimentationType().ToLower() == "meat")
            {
                image.sprite = foodSprites[2];
            }
        }
    }

}
