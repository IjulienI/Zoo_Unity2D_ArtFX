using TMPro;
using UnityEngine;

public class UiAnimal : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private TextMeshProUGUI Name;



    private void Update()
    {
        if(gameManager.GetTarget() != null)
        {
            if(gameManager.GetTarget().GetComponent<Animal>().Name != null)
            {
                Name.text = gameManager.GetTarget().GetComponent<Animal>().Name;
            }
        }
    }
}
