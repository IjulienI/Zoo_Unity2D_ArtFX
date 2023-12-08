using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Click : MonoBehaviour
{
    private BoxCollider2D Collider;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private FollowCamera followCamera;
    [SerializeField] private UIManager UIManager;
    private float delay;
    private bool canCollide;
    private bool canClick;

    private void Awake()
    {
        Collider = GetComponent<BoxCollider2D>();
        Collider.enabled = false;
        canClick = true;
    }
    private void Update()
    {
        if(canClick && !gameManager.GetIsPaused())
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                delay += 1f * Time.deltaTime;
                Collider.enabled = true;
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                if (delay < 0.1f)
                {
                    transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
                    canCollide = true;
                }
                delay = 0f;
                Invoke(nameof(ColliderOff), 0.1f);
            }
        }
    }

    private void ColliderOff()
    {
        Collider.enabled = false;
        canCollide = false;
        transform.position = new Vector3(0,0,-100);
    }

    public void SetCanClick(bool value)
    {
        canClick = value;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Animal" && canCollide)
        {
            gameManager.SetTarget(collision.gameObject);
            followCamera.UpdateTarget(collision.gameObject);
            UIManager.AnimalInfo();
            gameManager.ChangePause();
        }
        ColliderOff();
    }
}
