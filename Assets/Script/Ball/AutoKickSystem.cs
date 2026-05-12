using UnityEngine;

public class AutoKickSystem : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    [SerializeField]
    private Transform leftGoal;

    [SerializeField]
    private Transform rightGoal;

    [SerializeField]
    private CameraManager cameraManager;

    public void AutoKick()
    {
        BallController farthestBall =
            FindFarthestBall();

        if (farthestBall == null)
            return;

        Transform targetGoal =
            GetOpponentGoal();

        Vector3 direction =
            (
                targetGoal.position
                - farthestBall.transform.position
            ).normalized;

        farthestBall.Kick(direction);

        cameraManager.FollowBall(
            farthestBall.transform
        );
    }

    private BallController FindFarthestBall()
    {
        BallController[] balls =
            FindObjectsOfType<BallController>();

        BallController farthestBall = null;

        float maxDistance = 0f;

        foreach (BallController ball in balls)
        {
            float distance =
                Vector3.Distance(
                    player.position,
                    ball.transform.position
                );

            if (distance > maxDistance)
            {
                maxDistance = distance;
                farthestBall = ball;
            }
        }

        return farthestBall;
    }

    private Transform GetOpponentGoal()
    {
        return player.position.x <= 0
            ? rightGoal
            : leftGoal;
    }
}