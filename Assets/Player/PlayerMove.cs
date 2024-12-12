using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public PlayerState playerState;
    public SpriteRenderer playerSprite;
    Rigidbody2D rigi;
    void Start()
    {
      rigi = GetComponent<Rigidbody2D>();
      playerState = GetComponent<PlayerState>();
    }
    void Update()
    {
        move();
        fly();
    }
    private void FixedUpdate()
    {
        groundCheck();
    }
    void move()
    {
        rigi.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * playerState.MoveSpeed,
            Mathf.Clamp(rigi.linearVelocityY,-10,10));
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            if (rigi.linearVelocityX > 0)
            {
                playerSprite.flipX = false;
            }
            else playerSprite.flipX = true;
        }

        playerState.isMove = Input.GetAxis("Horizontal") == 0 ? false : true;
    }
    void fly()
    {
        if(Input.GetButton("Jump"))
        {
            if (rigi.linearVelocityY < 0) rigi.linearVelocityY = 0;
            rigi.AddForceY(20,ForceMode2D.Force);
        }
        else if(Input.GetButtonUp("Jump"))
        {
            rigi.linearVelocityY = 0;
        }
    }
    void groundCheck()
    {
        Debug.DrawRay(transform.position, Vector2.down*0.4f);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down,0.4f,LayerMask.GetMask("Ground"));
        if (hit.collider != null)
        {
            playerState.isGround = true;
        }
        else
        {
            playerState.isGround = false;
        }
    }
}
