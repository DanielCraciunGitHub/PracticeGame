using System.Collections;
using GameFlow;
using UnityEngine;

namespace Weapons
{
    public class OrbVortex : MonoBehaviour
    {
        [SerializeField] private float radius;

        private LineRenderer _zapLineRenderer;

        private void Start()    
        {
            _zapLineRenderer = GetComponent<LineRenderer>();

            StartCoroutine(RadiusChecker());
        }

        private IEnumerator RadiusChecker()
        {
            while (true)
            {
                ZapEnemiesInRange();
                yield return new WaitForSeconds(0.2f);
            }
        }

        private void ZapEnemiesInRange()
        {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, radius);

            foreach (var collidedWith in hitColliders)
            {
                if (!collidedWith.CompareTag("enemy") && !collidedWith.CompareTag("boss")) 
                    continue;
                RenderZapLine(collidedWith);
                AudioManager.PlayOrbSound();
                Destroy(collidedWith.gameObject);
                ScoreManager.playerScore++;
            }
        }

        private void RenderZapLine(Collider2D collided)
        {
            _zapLineRenderer.SetPosition(0, transform.position);
            _zapLineRenderer.SetPosition(1, collided.transform.position);
        }
    }
}
