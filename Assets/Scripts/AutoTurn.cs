using UnityEngine;

public class CharacterSpriteFlipper : MonoBehaviour
{
    public Transform otherCharacter;

    void Update()
    {
        if (otherCharacter != null)
        {
            // Check if the other character is on the right or left side
            bool isOnRightSide = transform.position.x < otherCharacter.position.x;

            // Flip the sprite based on the relative positions of the characters
            if (isOnRightSide)
            {
                FlipSprite(false);
            }
            else
            {
                FlipSprite(true);
            }
        }
        else
        {
            Debug.LogWarning("Other character transform is not assigned!");
        }
    }

    void FlipSprite(bool facingRight)
    {
        // Set the scale along the X axis to flip the sprite horizontally
        Vector3 newScale = transform.localScale;
        newScale.x = facingRight ? Mathf.Abs(newScale.x) : -Mathf.Abs(newScale.x);
        transform.localScale = newScale;
    }
}
