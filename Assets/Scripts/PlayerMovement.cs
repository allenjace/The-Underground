using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float PlayerMoveSpeed = 5f;
    Vector2 moveInput;
    public bool PlayerMoving { get; private set; }  
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x  * PlayerMoveSpeed, rb.velocity.y);
    }
    public void PlayerMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        PlayerMoving = moveInput != Vector2.zero;
    }
}
