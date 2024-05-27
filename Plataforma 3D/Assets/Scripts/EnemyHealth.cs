using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public int enemyHealth = 1;
    int damage = 1;
    [SerializeField] AudioSource source;

    public void HurtEnemy()
    {
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Gun")
        {
            enemyHealth -= damage;
            if (gameObject.CompareTag("Pato"))
            {
                SceneManager.LoadScene("Tela Final");
            }
            else if (enemyHealth <= 0)
            {
                source.Play();
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
            if (gameObject.CompareTag("Pato"))
            {
                source.Play();
                
                Destroy(gameObject);
            }
            else if (enemyHealth <= 0)
            {
                source.Play();
                Destroy(gameObject);
            }
                
        }else if (collider.gameObject.CompareTag("Zona de Morte"))
        {
            enemyHealth -= damage;
            Destroy(gameObject);
        }
    }

   
}
