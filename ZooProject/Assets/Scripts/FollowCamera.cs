using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    GameObject target;

    private void Update()
    {
        if (target != null)
        {
            transform.position = new Vector3(target.transform.position.x, target.transform.position.y, -10);
        }        
    }

    public void UpdateTarget(GameObject obj)
    {
        target = obj;
    }
}
