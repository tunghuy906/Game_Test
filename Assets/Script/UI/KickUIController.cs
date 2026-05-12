using UnityEngine;

public class KickUIController : MonoBehaviour
{
    [SerializeField]
    private BallDetector ballDetector;

    [SerializeField]
    private Transform leftGoal;

    [SerializeField]
    private Transform rightGoal;

    [SerializeField]
    private CameraManager cameraManager;

    public void KickBall()
    {
        if (ballDetector.CurrentBall == null)
            return;

        Transform targetGoal =
            GetNearestGoal(
                ballDetector.CurrentBall.transform.position
            );

        Vector3 direction =
            (
                targetGoal.position
                - ballDetector.CurrentBall.transform.position
            ).normalized;

        ballDetector.CurrentBall.Kick(direction);

        cameraManager.FollowBall(
            ballDetector.CurrentBall.transform
        );
    }

    private Transform GetNearestGoal(
        Vector3 ballPosition
    )
    {
        float leftDistance =
            Vector3.Distance(
                ballPosition,
                leftGoal.position
            );

        float rightDistance =
            Vector3.Distance(
                ballPosition,
                rightGoal.position
            );

        return leftDistance < rightDistance
            ? leftGoal
            : rightGoal;
    }
}