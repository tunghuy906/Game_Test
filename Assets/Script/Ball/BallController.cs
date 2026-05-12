using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private float kickForce = 15f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Kick(Vector3 direction)
    {
        rb.velocity = Vector3.zero;

        rb.AddForce(
            direction * kickForce,
            ForceMode.Impulse
        );
    }
}