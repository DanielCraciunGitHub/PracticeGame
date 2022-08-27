using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasedPlayer : MonoBehaviour
{
    Vector2 direction;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float playerSpeed;
    public static Transform playerTransform;
    
    void Awake()
    {
        playerTransform = transform;
    }
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal"); 
        float moveY = Input.GetAxisRaw("Vertical"); 

        direction = new Vector2(moveX, moveY).normalized;
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(direction.x * playerSpeed, direction.y * playerSpeed);
    }
}
