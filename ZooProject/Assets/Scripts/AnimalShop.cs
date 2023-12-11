using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnimalShop : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private TextMeshProUGUI money;
    [SerializeField] private TextMeshProUGUI fish;
    [SerializeField] private TextMeshProUGUI vegetable;
    [SerializeField] private TextMeshProUGUI meat;


    private void Update()
    {
        money.text = (Mathf.Round(gameManager.GetResources("money")) + " $");
        meat.text = GameManager.instance.GetResources("meat").ToString();
        fish.text = GameManager.instance.GetResources("fish").ToString();
        vegetable.text = GameManager.instance.GetResources("vegetable").ToString();
    }
}
