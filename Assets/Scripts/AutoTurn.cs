using UnityEngine;

public class AutoTurn : MonoBehaviour
{
    public Transform otherCharacter;
    private SpriteRenderer spriteRenderer;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (otherCharacter != null)
        {
            if (transform.position.x < otherCharacter.position.x)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f); 
            }
        }
        else
        {
            Debug.LogWarning("Other character transform is not assigned!");
        }
    }
}
