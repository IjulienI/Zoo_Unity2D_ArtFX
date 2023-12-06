using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnimalShop : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private TextMeshProUGUI money;

    private void Update()
    {
        money.text = (gameManager.GetResources("money")+ " $");
    }
}
