using UnityEngine;


public class AttributeManager : MonoBehaviour
{
    public int health = 100;

    public HealthBar healthBar;

    public void Start()
    {
        healthBar.SetMaxHealth(health);
    }
    

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);
        
        Debug.Log("Player takes " + damage + " damage. Health: " + health);
        if (health <= 0)
        {
            Debug.Log("Game Over!");
            Time.timeScale = 0; // Stop the game
                
              }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyProjectile"))
        {
            TakeDamage(10);
            
            Destroy(other.gameObject);
            
            Debug.Log(health);
        }
        
    }

   
}