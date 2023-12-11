using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Price : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI price;
    [SerializeField] private string animal;

    private void Update()
    {
        price.text = "PRICE : " + GameManager.instance.GetAnimalPrice(animal) + "$";
    }
}