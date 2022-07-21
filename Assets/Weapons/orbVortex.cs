using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbVortex : MonoBehaviour
{
    [SerializeField] float radius;
    [SerializeField] AudioClip electric;

    LineRenderer lr;
    EnemySpawner e;
    PlayerController p;
    AudioSource a;

    void Start()    
    {
        a = GetComponent<AudioSource>();
        lr = GetComponent<LineRenderer>();
        p = GameObject.FindGameObjectWithTag("player").GetComponent<PlayerController>(); // allows for score counting
        e = GameObject.FindGameObjectWithTag("enemyControl").GetComponent<EnemySpawner>(); // includes an object with the EnemySpawner script attached to it
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

                e.decrement(); // decrements the enemy count
                p.increment(); // increment player score
                 
            }
        }
    }

    void Update()
    {
        enemiesInRange();
    }
}
