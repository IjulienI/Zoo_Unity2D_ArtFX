using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FoodPrice : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private TextMeshProUGUI amountText;
    [SerializeField] private int amount;
    [SerializeField] private int price;
    [SerializeField] private string ressource;


    private void Update()
    {
        priceText.text = "PRICE : " + price + "$";
        amountText.text = amount.ToString();
    }
}
