
using UnityEngine;

public class Wing : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriterenderer;
    public PlayerState playerState;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriterenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (Input.GetButton("Jump"))
            animator.SetBool("UP", true);
        else animator.SetBool("UP", false);

        if (playerState.isGround)
            spriterenderer.enabled = false;
        else spriterenderer.enabled = true;
    }
}
