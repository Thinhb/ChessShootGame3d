using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DragDropable : MonoBehaviour
{
    private Vector3 curScreenPos;
    Camera camera;
    public bool isDragging;
    Rigidbody rb;
    [SerializeField]
    float shootForce;
    public float direction;
    public bool checkShoot;
    GameObject gameObjectMove;
    bool checkRaycast;
    ControllerGame controllerGame;
    private Vector3 WorldPos
    {
        get
        {
            float z = camera.WorldToScreenPoint(transform.position).z;
            return camera.ScreenToWorldPoint(curScreenPos + new Vector3(0, 0, z));
        }
    }
    private bool isClickedOn
    {
        get
        {
            Ray ray = camera.ScreenPointToRay(curScreenPos);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.CompareTag("Player") && !checkRaycast)
                {
                    gameObjectMove = hit.collider.gameObject;
                    checkRaycast= true;
                }
                return hit.transform == transform;
            }
            return false;
        }
    }
    private void Awake()
    {
        camera = Camera.main;
        rb = GetComponent<Rigidbody>();
        checkRaycast = false;
        controllerGame= FindObjectOfType<ControllerGame>();
    }
    private void Update()
    {
        int i = 0;
        gameObject.transform.position = new Vector3(transform.position.x, -3.89f, transform.position.z);
        while (i < Input.touchCount)
        {

            Touch t = Input.GetTouch(i);
            if (t.phase == TouchPhase.Ended)
            {
                isDragging = false;
                checkRaycast = false;
            }
            else if (t.phase == TouchPhase.Moved)
            {
                curScreenPos = t.position;
                if (isClickedOn)
                {
                    StartCoroutine(Drag());
                }
            }
            ++i;
        }
    }
    private IEnumerator Drag()
    {
        isDragging = true;
        controllerGame.checkAwake= true;
        Vector3 offset = transform.position - WorldPos;
        while (isDragging)
        {
            gameObjectMove.transform.position = WorldPos + offset;
            checkRegion();
            yield return null;
        }
        shoot();
    }

    private void shoot()
    {
        if (checkShoot)
        {
            rb.AddForce(transform.forward * shootForce *direction, ForceMode.Impulse);
            checkShoot = false;
        }
    }
    private void OnTriggerStay(Collider collision)
    {
        /*if (collision.gameObject.CompareTag("Line"))
        {
            checkShoot = true;
        }*/
        if (collision.gameObject.CompareTag("region1"))
        {
            direction = 1f;
        }
        if (collision.gameObject.CompareTag("region2"))
        {
            direction = -1f;
        }      
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Line"))
        {
            checkShoot = false;
            collision.gameObject.GetComponent<Line>().checkCollionFirstChess= true;
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("region1"))
        {
            controllerGame.incrementScorePlayer1();
        }
        if (collision.gameObject.CompareTag("region2"))
        {
            controllerGame.incrementScorePlayer2();
        }
    }
    void checkRegion()
    {
        if (direction == 1f)
        {
            gameObjectMove.transform.position = new Vector3(Mathf.Clamp(gameObjectMove.transform.position.x, -2.2f, 2f),
                                                            gameObjectMove.transform.position.y,
                                                            Mathf.Clamp(gameObjectMove.transform.position.z, -4.2f, -0.3f));
        }
        if (direction == -1f)
        {
            gameObjectMove.transform.position = new Vector3(Mathf.Clamp(gameObjectMove.transform.position.x, -2.2f, 2f),
                                                            gameObjectMove.transform.position.y,
                                                            Mathf.Clamp(gameObjectMove.transform.position.z, 0.9f,4.9f));
        }
    }
}
