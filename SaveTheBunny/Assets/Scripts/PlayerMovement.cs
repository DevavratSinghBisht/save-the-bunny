using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rb;
    float xInput;
    public float moveSpeed; 
    Vector2 newPosition;
    public float xPositionLimit;

    //runs before start
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // For physics functions we prefer FixedUpdate rather than Update
    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        // -1 to +1 from left arrow key to right arrow key
        xInput = Input.GetAxis("Horizontal");

        // geting the current position of the player
        newPosition = transform.position;
        newPosition.x += xInput * moveSpeed;
        newPosition.x = Mathf.Clamp(newPosition.x, -xPositionLimit, xPositionLimit);
        rb.MovePosition(newPosition);
    }
}
