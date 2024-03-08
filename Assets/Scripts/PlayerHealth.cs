using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int switchHp = 50;
    private int currentHealth;
    public bool lowHp = false;
    public bool isAlive = true;


    public Image healthBar; 

    void Start()
    {
        currentHealth = maxHealth;

        UpdateHealthBar();
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("Player took " + damageAmount + " damage. Current health: " + currentHealth);

        UpdateHealthBar();

        if (currentHealth <= switchHp && !lowHp)
        {
            lowHp = true; 
            Debug.Log("Switch moves");
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isAlive = false;
        Debug.Log("Player died!");

    }

    void UpdateHealthBar()
    {  
        if (healthBar != null)
        { 
            float fillAmount = (float)currentHealth / maxHealth;
            healthBar.fillAmount = fillAmount;
        }
        else
        {
            Debug.LogWarning("Health bar reference is not set!");
        }
    }
}
