using Unity.VisualScripting;
using UnityEngine;

public class CapybaraMovement : MonoBehaviour
{
    public float jumpSpeed = 15f;
    public float walkSpeed = 5f; 
    public Collider2D groundCollider;
    public LayerMask groundLayer;
    public AudioClip collectSound;

    private bool canJump;
    private bool jumpHolding;
    private int collectedOranges = 0;
    public bool isWalking;
    public bool isJumping;
    private float previousXPosition;
    public bool capybaraStop=false;

    void Start()
    {
        previousXPosition = transform.position.x;
    }
    void Update()
    {
        if (!capybaraStop)
        {
            MoveCapybara();
        }
        

        if (Input.GetButtonDown("Jump"))
        {
         jumpHolding = true;
        }

        if (Input.GetButtonUp("Jump"))
        {
         jumpHolding = false;
        }

        if (canJump && jumpHolding)
        {
            if(!capybaraStop)
            {
                Jump();
            }
        }

        float currentXPosition = transform.position.x;

        if (currentXPosition > previousXPosition)
        {
            isWalking = true;
        }
        else if (currentXPosition < previousXPosition)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }

        previousXPosition = currentXPosition;
    }

    void FixedUpdate()
    {
        CheckGround();
    }

    void CheckGround()
    {
        canJump = Physics2D.Raycast(groundCollider.bounds.center, Vector2.down, groundCollider.bounds.extents.y + 0.1f, groundLayer);
        isJumping = !Physics2D.Raycast(groundCollider.bounds.center, Vector2.down, groundCollider.bounds.extents.y + 0.1f, groundLayer);
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

    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Orange"))
        {
            CollectObject(other.gameObject);

            collectedOranges++;

            Debug.Log("Capy collected an orange! Total number collected:" + collectedOranges);
        }
    }

    public void CollectObject(GameObject obj)
    {
        if (collectSound != null)
        {
            AudioSource.PlayClipAtPoint(collectSound, obj.transform.position);
        }

        obj.SetActive(false);
    }
}
