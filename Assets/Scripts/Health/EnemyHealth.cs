using UnityEngine;


public class EnemyHealth : MonoBehaviour
{
    public int health = 100;
    

    public void TakeDamage(int damage)
    {
        health -= damage;
      
        
        Debug.Log("Player takes " + damage + " damage. Health: " + health);
        if (health <= 0)
        {
           Destroy(gameObject);
                
              }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if( collision.gameObject.CompareTag("PlayerProjectile"))
        {
            TakeDamage(100);
            Debug.Log("AAA");
            
            Destroy(collision.gameObject);
            
        }
        
    }

   
}