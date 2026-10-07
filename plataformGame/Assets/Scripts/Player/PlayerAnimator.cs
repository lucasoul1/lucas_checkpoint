using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    // Components
    private Animator animator;
    private PlayerMovement playerMovement;
    private PlayerJump playerJump;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        playerJump = GetComponent<PlayerJump>();
    }

    private void Update()
    {
        animator.SetInteger("pMove", playerMovement.MoveValue());
        animator.SetInteger("pJump", playerJump.JumpValue());
    }
}
