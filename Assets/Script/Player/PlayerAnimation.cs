using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private PlayerController playerController;

    private void Update()
    {
        animator.SetFloat(
            "Blend",
            playerController.MoveAmount
        );
    }
}