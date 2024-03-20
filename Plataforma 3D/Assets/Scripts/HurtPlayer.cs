using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int damageToGive = 1;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 hitDirection = collision.transform.position - transform.position;

            hitDirection = hitDirection.normalized;

            FindObjectOfType<HealthManager>().HurtPlayer(damageToGive, hitDirection);
        }else if(collision.gameObject.CompareTag("Player") && gameObject.tag == "bullet")
        {
            Vector3 hitDirection = collision.transform.position - transform.position;

            hitDirection = hitDirection.normalized;
            Destroy(gameObject);
        }

    }
}
