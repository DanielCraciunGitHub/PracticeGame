using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Camera cam;

    Vector2 direction; 
    Vector2 mousePos;

    [SerializeField] float speed = 5.0f;
    
    void Start()
    {
        transform.position = Vector2.zero;   
    }
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal"); 
        float moveY = Input.GetAxisRaw("Vertical");

        direction = new Vector2(moveX, moveY).normalized;

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);   
    }   
    void FixedUpdate()
    {
        // increase velocity in given directions, to allow movements.
        rb.velocity = new Vector2(direction.x * speed, direction.y * speed); 
        
        // handle look direction
        Vector2 lookDirection = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
