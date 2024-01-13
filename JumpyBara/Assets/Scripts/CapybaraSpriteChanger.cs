using UnityEngine;

public class CapybaraSpriteChanger : MonoBehaviour
{
    public Sprite[] moveSprites;
    public Sprite staticSprite;
    public Sprite jumpSprite;
    private bool isWalking;
    private bool isJumping;
    private bool isStopped;

    private SpriteRenderer spriteRenderer;
    private int currentSpriteIndex = 0;

    void Start()
    {
        isWalking = GetComponent<CapybaraMovement>().isWalking;
        isStopped = GetComponent<CapybaraMovement>().capybaraStop;
        isJumping = GetComponent<CapybaraMovement>().isJumping;
        spriteRenderer = GetComponent<SpriteRenderer>();
        InvokeRepeating("ChangeMoveSprite", 0.2f, 0.2f);
    }

    void Update()
    {
        isWalking = GetComponent<CapybaraMovement>().isWalking;
        isJumping = GetComponent<CapybaraMovement>().isJumping;
        isStopped = GetComponent<CapybaraMovement>().capybaraStop;
    }

    void ChangeMoveSprite()
    {
        if(!isStopped && !isJumping)
        {
            spriteRenderer.sprite = moveSprites[currentSpriteIndex];
            currentSpriteIndex = (currentSpriteIndex + 1) % moveSprites.Length;
        }
        else if(isJumping)
        {
            spriteRenderer.sprite = jumpSprite;
        }
        else spriteRenderer.sprite = staticSprite;
        
    }
}
