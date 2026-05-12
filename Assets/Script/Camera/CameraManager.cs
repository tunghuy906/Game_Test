using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    private CameraFollow cameraFollow;

    [SerializeField]
    private Transform player;

    public void FollowBall(Transform ball)
    {
        cameraFollow.SetTarget(ball);
    }

    public void ReturnToPlayer()
    {
        cameraFollow.SetTarget(player);
    }
}