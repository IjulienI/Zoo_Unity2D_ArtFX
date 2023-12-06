using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Price : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI price;
    [SerializeField] private string animal;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    private void Update()
    {
        price.text = "PRICE : " + gameManager.GetAnimalPrice(animal) + "$";
    }
}