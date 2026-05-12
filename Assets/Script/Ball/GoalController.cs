using UnityEngine;
using System.Collections;

public class GoalController : MonoBehaviour
{
    [SerializeField]
    private CameraManager cameraManager;

    [SerializeField]
    private GameObject confettiEffect;

    private bool isGoalTriggered;

    private void OnTriggerEnter(Collider other)
    {
        if (isGoalTriggered)
            return;

        if (other.CompareTag("Ball"))
        {
            isGoalTriggered = true;

            SpawnConfetti(other.transform.position);

            StartCoroutine(
                ReturnCameraRoutine()
            );
        }
    }

    private void SpawnConfetti(Vector3 position)
    {
        Instantiate(
            confettiEffect,
            position,
            Quaternion.identity
        );
    }

    private IEnumerator ReturnCameraRoutine()
    {
        yield return new WaitForSeconds(2f);

        cameraManager.ReturnToPlayer();

        isGoalTriggered = false;
    }
}