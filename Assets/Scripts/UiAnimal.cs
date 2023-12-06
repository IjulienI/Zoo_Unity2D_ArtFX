using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class UiAnimal : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private TextMeshProUGUI Name;

    private enum Alimentation {rien};


    private void Update()
    {
        if(gameManager.GetTarget() != null)
        {
            Name.text = gameManager.GetTarget().GetComponent<Animal>().GetAnimalType();
        }
    }
}
