using UnityEngine;

public class BallDetector : MonoBehaviour
{
    [SerializeField]
    private float detectRange = 2f;

    [SerializeField]
    private GameObject kickButton;

    private BallController currentBall;

    public BallController CurrentBall => currentBall;

    private void Update()
    {
        DetectBall();
    }

    private void DetectBall()
    {
        Collider[] hits =
            Physics.OverlapSphere(
                transform.position,
                detectRange
            );

        bool foundBall = false;

        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Ball"))
            {
                foundBall = true;

                currentBall =
                    hit.GetComponent<BallController>();

                break;
            }
        }

        kickButton.SetActive(foundBall);

        if (!foundBall)
        {
            currentBall = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(
            transform.position,
            detectRange
        );
    }
}