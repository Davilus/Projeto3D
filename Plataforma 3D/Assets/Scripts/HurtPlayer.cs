using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int damageToGive = 1;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 hitDirection = collision.transform.position - transform.position;

            hitDirection = hitDirection.normalized;
            //Debug.Log("Colidiu");
            FindObjectOfType<HealthManager>().HurtPlayer(damageToGive, hitDirection);

           if(gameObject.tag == "Bullet")
           {
                Destroy(gameObject);
           }
        }

    }
}
