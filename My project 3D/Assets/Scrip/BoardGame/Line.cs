using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public bool isDragging = false;
    new Camera camera;
    Vector3 initialPosition;
    float direction;
    Vector3 positionChess;
    public bool checkCollionFirstChess;
    private void Start()
    {
        camera = Camera.main;
        lineRenderer = GetComponent<LineRenderer>();
        initialPosition = lineRenderer.GetPosition(1);
        checkCollionFirstChess= true;
    }

    private void Update()
    {
        if (isDragging)
        {
            float z = camera.WorldToScreenPoint(transform.position).z;
            Vector3 newPosition = camera.ScreenToWorldPoint(positionChess);
            lineRenderer.SetPosition(1, newPosition+new Vector3(0,0,-0.4f*direction));
        }
        if (!isDragging)
        {
            lineRenderer.SetPosition(1, initialPosition);
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (checkCollionFirstChess)
            {
                collision.gameObject.GetComponent<DragDropable>().checkShoot = true;
            }
        }
    }
    private void OnTriggerStay(Collider collision)
   {
        if (collision.gameObject.CompareTag("Player"))
        {
            direction = collision.gameObject.GetComponent<DragDropable>().direction;
            if (collision.gameObject.GetComponent<DragDropable>().isDragging)
            {
                positionChess = camera.WorldToScreenPoint(collision.gameObject.transform.position);
                isDragging = true;
            }
            
        }
   }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isDragging = false;
        }
    }
  
}
