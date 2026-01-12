using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Attack Settings")]
    public float attackRange = 1.5f;
    public int attackDamage = 1;
    public float attackCooldown = 0.5f;
    
    [Header("Visual Settings")]
    public GameObject swordObject;
    public float attackDuration = 0.3f;
    
    private bool canAttack = true;
    private Vector2 attackDirection = Vector2.right;

    void Update()
    {
        UpdateAttackDirection();
        
        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            StartCoroutine(PerformAttack());
        }
    }

    void UpdateAttackDirection()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - transform.position).normalized;
        
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            attackDirection = direction.x > 0 ? Vector2.right : Vector2.left;
        }
        else
        {
            attackDirection = direction.y > 0 ? Vector2.up : Vector2.down;
        }
    }

    IEnumerator PerformAttack()
    {
        canAttack = false;
        
        if (swordObject != null)
        {
            swordObject.SetActive(true);
            PositionSword();
        }
        
        CheckForHit();
        
        yield return new WaitForSeconds(attackDuration);
        
        if (swordObject != null)
            swordObject.SetActive(false);
        
        yield return new WaitForSeconds(attackCooldown - attackDuration);
        canAttack = true;
    }

    void PositionSword()
    {
        if (swordObject == null) return;
        
        Vector2 swordOffset = attackDirection * 0.8f;
        swordObject.transform.localPosition = swordOffset;
        
        float angle = 0;
        switch (attackDirection.ToString())
        {
            case "(1.0, 0.0)": angle = 0; break;
            case "(-1.0, 0.0)": angle = 180; break;
            case "(0.0, 1.0)": angle = 90; break;
            case "(0.0, -1.0)": angle = -90; break;
        }
        
        swordObject.transform.localEulerAngles = new Vector3(0, 0, angle);
    }

    void CheckForHit()
    {
        Vector2 attackPos = (Vector2)transform.position + attackDirection * attackRange;
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPos, 0.5f);
        
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(attackDamage);
                    Debug.Log($"Попали во врага! Нанесено урона: {attackDamage}");
                }
            }
        }
        
        Debug.DrawLine(transform.position, attackPos, Color.red, 0.5f);
    }
    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Vector2 attackPos = (Vector2)transform.position + attackDirection * attackRange;
        Gizmos.DrawWireSphere(attackPos, 0.5f);
    }
}