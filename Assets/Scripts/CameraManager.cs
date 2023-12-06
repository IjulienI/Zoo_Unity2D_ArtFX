using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager: MonoBehaviour
{
    [SerializeField] private float minSize;
    [SerializeField] private float maxSize;
    [SerializeField] private float step;
    [SerializeField] private GameManager gameManager;

    private bool drag;
    private Vector3 difference;
    private Vector3 origin;

    private void Update()
    {
        if (!gameManager.GetIsPaused())
        {
            //Zoom
            if (Input.GetAxis("Mouse ScrollWheel") > 0f && GetComponent<Camera>().orthographicSize > minSize)
            {
                GetComponent<Camera>().orthographicSize -= step;
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f && GetComponent<Camera>().orthographicSize < maxSize)
            {
                GetComponent<Camera>().orthographicSize += step;
            }

            //Drag
            if (Input.GetMouseButton(0))
            {
                difference = (Camera.main.ScreenToWorldPoint(Input.mousePosition)) - Camera.main.transform.position;
                if (!drag)
                {
                    drag = true;
                    origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                }
            }
            else
            {
                drag = false;
            }

            if (drag)
            {
                Camera.main.transform.position = origin - difference;
            }
        }
    }
}
