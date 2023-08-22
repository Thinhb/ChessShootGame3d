using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotationDrag : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 lastMousePosition;
    public Camera mainCamera;
    public float rotationSpeed = 1.0f;

    public float zoomSpeed = 10f;
    public float minZoom = 100.0f;
    public float maxZoom = 150f;
    void Update()
    {
        
        rotateCar();
        zoomCar();
    }
    void rotateCar()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            lastMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 currentMousePosition = Input.mousePosition;
            Vector3 mouseDelta = currentMousePosition - lastMousePosition;


            float rotationY = -mouseDelta.x * rotationSpeed * Time.deltaTime;

            transform.Rotate(0f, rotationY, 0, Space.Self);

            lastMousePosition = currentMousePosition;
        }
    }
   

    void zoomCar()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        float newZoom = transform.localScale.x + scrollInput * zoomSpeed;
        newZoom = Mathf.Clamp(newZoom, minZoom, maxZoom);
        Vector3 newScale = new Vector3(newZoom, newZoom, newZoom);
        transform.localScale = newScale;
    }
}
