using UnityEngine;

public class CapybaraSpriteChanger : MonoBehaviour
{
    public Sprite[] moveSprites;

    private SpriteRenderer spriteRenderer;
    private int currentSpriteIndex = 0;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        InvokeRepeating("ChangeMoveSprite", 0.2f, 0.2f);
    }

    void ChangeMoveSprite()
    {
        spriteRenderer.sprite = moveSprites[currentSpriteIndex];
        currentSpriteIndex = (currentSpriteIndex + 1) % moveSprites.Length;
    }
}
