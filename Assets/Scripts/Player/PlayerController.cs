using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb; // edits the rigidbody component of the player object
    [SerializeField] Camera cam;
    [SerializeField] TMP_Text text;

    Vector2 direction; // store the direction of movement as a vector
    Vector2 mousePos;

    [SerializeField] float speed = 5.0f;
    public static int score;
    
    void Start()
    {
        score = 0;
        transform.position = new Vector2(0, 0); // spawn location for the player     
    }
    void Update()
    {
        // score displaying
        text.text = $"Score: {score}";
        //process player movements
        float moveX = Input.GetAxisRaw("Horizontal"); // recieves horizontal input direction (a,d)
        float moveY = Input.GetAxisRaw("Vertical"); // recieves vertical input direction (s,w)

        direction = new Vector2(moveX, moveY).normalized; // store the direction based on inputs, normalise to keep movement speed consistent for any direction

        // process rotations
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
    public void increment()
    {
        score++;
    }
    public int getScore()
    {
        return score;
    }
}
