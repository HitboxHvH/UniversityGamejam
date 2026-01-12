using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 3;
    public int currentHealth;
    
    [Header("UI Reference")]
    public HeathSystem healthSystem;
    
    [Header("Effects")]
    public AudioClip hurtSound;
    public float invincibilityTime = 1f;
    
    private bool isInvincible = false;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        if (isInvincible || currentHealth <= 0) return;
        
        currentHealth -= damage;
        
        if (hurtSound != null)
            AudioSource.PlayClipAtPoint(hurtSound, transform.position);
        
        UpdateHealthUI();
        
        StartCoroutine(InvincibilityFrames());
        
        if (currentHealth <= 0)
        {
            Die();
        }
        
        Debug.Log($"Игрок получил урон: {damage}. Осталось HP: {currentHealth}");
    }

    void UpdateHealthUI()
    {
        if (healthSystem != null)
        {
            healthSystem.health = currentHealth;
        }
    }

    System.Collections.IEnumerator InvincibilityFrames()
    {
        isInvincible = true;
        
        float elapsedTime = 0f;
        while (elapsedTime < invincibilityTime)
        {
            spriteRenderer.color = new Color(1, 1, 1, 0.5f);
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(0.1f);
            elapsedTime += 0.2f;
        }
        
        spriteRenderer.color = Color.white;
        isInvincible = false;
    }

    void Die()
    {
        Debug.Log("Игрок умер!");
        

        GetComponent<Player_Controller>().enabled = false;
        if (GetComponent<PlayerAttack>() != null)
            GetComponent<PlayerAttack>().enabled = false;
        

        GameManagerSimple gameManager = FindObjectOfType<GameManagerSimple>();
        if (gameManager != null)
        {
            gameManager.ShowGameOver();
        }
    }
}