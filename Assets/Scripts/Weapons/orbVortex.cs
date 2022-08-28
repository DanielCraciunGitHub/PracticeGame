using System.Collections;
using UnityEngine;

public class orbVortex : MonoBehaviour
{
    [SerializeField] float radius;

    LineRenderer zapLineRenderer;

    void Start()    
    {
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
 
    void zapEnemiesInRange()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (var collider in hitColliders)
        {
            if (collider.CompareTag("enemy") || collider.CompareTag("boss"))
            {
                renderZapLine(collider);
                AudioManager.playOrbSound();
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
