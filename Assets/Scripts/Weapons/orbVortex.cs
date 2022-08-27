using System.Collections;
using UnityEngine;

public class orbVortex : MonoBehaviour
{
    [SerializeField] float radius;
    [SerializeField] AudioClip zapSound;

    LineRenderer zapLineRenderer;
    AudioSource audioSource;

    void Start()    
    {
        audioSource = GetComponent<AudioSource>();
        zapLineRenderer = GetComponent<LineRenderer>();

        StartCoroutine(radiusChecker());
    }
    IEnumerator radiusChecker()
    {
        while (true)
        {
            zapEnemiesInRange();
            yield return new WaitForSeconds(0.2f);
        }
    }
 
    void zapEnemiesInRange() // takes in the centre, and the radius of the circle
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (var collider in hitColliders) // check for each object
        {
            if (collider.CompareTag("enemy") || collider.CompareTag("boss"))
            {
                renderZapLine(collider);
                audioSource.PlayOneShot(zapSound);
                Destroy(collider.gameObject);
                ScoreManager.playerScore++;
            }
        }
    }

    void renderZapLine(Collider2D collider)
    {
        zapLineRenderer.SetPosition(0, transform.position);
        zapLineRenderer.SetPosition(1, collider.transform.position);
    }
}
