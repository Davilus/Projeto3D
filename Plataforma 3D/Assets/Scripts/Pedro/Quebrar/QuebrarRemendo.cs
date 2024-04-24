using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuebrarRemendo : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Gun"))
        {
           Debug.Log("colidiu");
           Destroy(gameObject);

        }
          
    }
}
