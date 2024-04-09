using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refletir : MonoBehaviour
{
    [SerializeField] private Rigidbody refletir;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Gun"))
        {
            refletir.velocity = -refletir.velocity;
            gameObject.tag = "Gun";
            gameObject.layer = 11;
            //gameObject.sphe
            
        }
    }
}
