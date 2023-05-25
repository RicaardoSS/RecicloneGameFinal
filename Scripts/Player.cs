using UnityEngine;
using Mirror;
using SimpleInputNamespace;

public class Player : NetworkBehaviour
{
    public float Speed;
    public float JumpForce;

    public bool isJumping;
    public bool doubleJump;

    private Rigidbody2D rig;
    private Animator anim;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!isLocalPlayer)
            return;

        Move();
        Jump();
    }

    private void Move()
    {
        float horizontalInput = 0f;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            float touchPositionX = touch.position.x;

            if (touch.phase == TouchPhase.Began)
            {
                if (touchPositionX > Screen.width / 2)
                {
                    horizontalInput = 1f;
                    anim.SetBool("walk", true);
                    transform.eulerAngles = new Vector3(0f, 0f, 0f);
                }
                else if (touchPositionX < Screen.width / 2)
                {
                    horizontalInput = -1f;
                    anim.SetBool("walk", true);
                    transform.eulerAngles = new Vector3(0f, 180f, 0f);
                }
                else
                {
                    anim.SetBool("walk", false);
                }
            }
        }
        else
        {
            horizontalInput = SimpleInput.GetAxis("Horizontal");

            if (horizontalInput > 0f)
            {
                anim.SetBool("walk", true);
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }
            else if (horizontalInput < 0f)
            {
                anim.SetBool("walk", true);
                transform.eulerAngles = new Vector3(0f, 180f, 0f);
            }
            else
            {
                anim.SetBool("walk", false);
            }
        }

        Vector3 movement = new Vector3(horizontalInput, 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;
    }

    private void Jump()
    {
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || SimpleInput.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                isJumping = true;
                doubleJump = true;
                anim.SetBool("jump", true);
            }
            else if (doubleJump)
            {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                doubleJump = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            isJumping = false;
            anim.SetBool("jump", false);
        }

        if (collision.gameObject.CompareTag("spike"))
        {
            GameManager.instance.ShowGameOver();
            Destroy(gameObject);

            if (isLocalPlayer)
            {
                NetworkManager networkManager = FindObjectOfType<NetworkManager>();
                networkManager.ServerChangeScene("GameOverScene");
            }
        }
    }
}
