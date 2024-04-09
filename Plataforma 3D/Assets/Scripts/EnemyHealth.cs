using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int enemyHealth;
    int damage = 1;

    public void HurtEnemy()
    {
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Gun")
        {
            enemyHealth -= damage;
            if (enemyHealth <= 0)
            {
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Gun"))
        {
            enemyHealth -= damage;
            if(enemyHealth <= 0)
            {
                Destroy(gameObject);
            }
                
        }else if (collider.gameObject.CompareTag("Zona de Morte"))
        {
            enemyHealth -= damage;
            Destroy(gameObject);
        }

        
    }
}
