using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public GameObject prefab;
    [SerializeField] protected string Name;
    [SerializeField] protected string Type;
    [SerializeField] public AlimentationType alimentation;
    [SerializeField] protected int age;
    [SerializeField] protected float speed;
    [SerializeField] protected int hungerness;
    [SerializeField] protected int thirstness;
    [SerializeField] protected int tiredness;
    [SerializeField] protected float minSpeed;
    [SerializeField] protected float maxSpeed;
    [SerializeField] protected GameObject enclot;

    private Vector2 targetPos;
    private bool canMove;

    private void Awake()
    {
        FindEnclot();
        targetPos = transform.position;
        SetRandomTargetPos(2);
    }

    private void Update()
    {
        Move();
        Rotate();
    }

    private void FindEnclot()
    {
        GameObject[] enclots = GameObject.FindGameObjectsWithTag("Enclot");
        float distance = Mathf.Infinity;
        int index = 0;
        for(int i = 0; i < enclots.Length; i++)
        { 
            if(distance > Vector3.Distance(gameObject.transform.position, enclots[i].transform.position))
            {
                distance = Vector3.Distance(gameObject.transform.position, enclots[i].transform.position);
                index = i;
            }
        }
        enclot = enclots[index];
    }

    public void Chill()
    {
        canMove = false;
        Invoke("StopChill", Random.Range(30, 60));
    }

    private void StopChill()
    {
        tiredness /= 2;
        SetRandomTargetPos(5);
    }

    public void Sleep()
    {
        canMove = false;
    }

    private void StopSleep()
    {

    }

    public void Eat(int amount)
    {
        if(hungerness <= 0)
        {
            age += amount;
        }
        else
        {
            hungerness -= amount;
        }
    }

    public void SetRandomTargetPos(int range)
    {
        canMove = true;
        targetPos = new Vector2(Random.Range(enclot.transform.position.x - (enclot.GetComponent<Renderer>().bounds.size.x/2) + (GetComponent<Renderer>().bounds.size.x/2), enclot.transform.position.x + (enclot.GetComponent<Renderer>().bounds.size.x / 2) - (GetComponent<Renderer>().bounds.size.x / 2)),
            Random.Range(enclot.transform.position.y - (enclot.GetComponent<Renderer>().bounds.size.x / 2) + (GetComponent<Renderer>().bounds.size.x / 2), enclot.transform.position.y + (enclot.GetComponent<Renderer>().bounds.size.x / 2) - (GetComponent<Renderer>().bounds.size.x / 2)));
        ChangeSpeed(maxSpeed, minSpeed);
    }

    public void Move()
    {
        if (canMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }
        if(Vector3.Distance(transform.position,targetPos) <= 0.2f && canMove)
        {
            StopMove();
        }
    }

    public void StopMove()
    {
        canMove = false;
        int rnd = Random.Range(1, 100);
        if (rnd > 95 && tiredness >= 6)
        {
            Chill();
        }
        else
        {
            Invoke(nameof(CallSetRandomTargetPos), Random.Range(5, 15));
        }

    }

    private void Rotate()
    {
        Vector2 direction = targetPos - (Vector2)transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * (180 / Mathf.PI);

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }

    private void ChangeSpeed(float max, float min)
    {
        speed = Random.Range(min, max);
    }

    public string GetAnimalType()
    {
        return Type;
    }

    private void CallSetRandomTargetPos()
    {
        SetRandomTargetPos(2);
    }

    
}

public enum AlimentationType
{
    Fish,
    Vegetable,
    Meat
}