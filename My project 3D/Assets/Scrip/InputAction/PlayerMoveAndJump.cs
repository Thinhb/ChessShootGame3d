using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveAndJump : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    private float moveSpeed = 1f;
    public PlayerAction playerAction;
    Vector2 moveDirection;
    private InputAction move;
    private InputAction jump;
    [SerializeField]
    private float jumpPower = 1f;
    private bool isGround;
    // Start is called before the first frame update
    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerAction=new PlayerAction();
        isGround= true;
    }
    private void OnEnable()
    {
        move=playerAction.Player.Move;
        move.Enable();
        jump = playerAction.Player.Jump;
        jump.Enable();
        jump.performed += jumpPlayer;
    }
    private void OnDisable()
    {
        move.Disable();
        jump.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        movePlayer();
    }
    void movePlayer()
    {
        moveDirection = move.ReadValue<Vector2>();
        Vector3 moveTranform= new Vector3(moveDirection.x * moveSpeed*Time.deltaTime, 0f, moveDirection.y * moveSpeed*Time.deltaTime);
        rb.transform.position += moveTranform;
    }
    private void jumpPlayer(InputAction.CallbackContext context)
    {
        if (isGround)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isGround = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGround= true;
        }
    }
}
