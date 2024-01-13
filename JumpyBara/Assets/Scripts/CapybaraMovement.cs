using UnityEngine;

public class CapybaraMovement : MonoBehaviour
{
    public float jumpSpeed = 15f;
    public float walkSpeed = 5f; 
    public Collider2D groundCollider;
    public LayerMask groundLayer;

    private bool canJump;
    private bool isJumping;

    void Update()
    {
        MoveCapybara();

        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }

        if (canJump && isJumping)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        CheckGround();
    }

    void CheckGround()
    {
        canJump = Physics2D.Raycast(groundCollider.bounds.center, Vector2.down, groundCollider.bounds.extents.y + 0.1f, groundLayer);
    }

    void MoveCapybara()
    {
        float characterSpeed = walkSpeed;
        transform.Translate(new Vector2(characterSpeed * Time.deltaTime, 0));
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpSpeed);
    }
}
