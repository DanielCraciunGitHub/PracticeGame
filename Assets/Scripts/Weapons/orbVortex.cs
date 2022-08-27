using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbVortex : MonoBehaviour
{
    [SerializeField] float radius;
    [SerializeField] AudioClip electric;

    LineRenderer lr;
    AudioSource a;

    void Start()    
    {
        a = GetComponent<AudioSource>();
        lr = GetComponent<LineRenderer>();
    }
    void enemiesInRange() // takes in the centre, and the radius of the circle
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (var collider in hitColliders) // check for each object
        {
            if (collider.gameObject.tag == "enemy")
            {

                lr.SetPosition(0, transform.position); // render the line
                lr.SetPosition(1, collider.transform.position);
                
                a.PlayOneShot(electric);
                Destroy(collider.gameObject);

                ScoreManager.playerScore++;
                 
            }
        }
    }

    void Update()
    {
        enemiesInRange();
    }
}
