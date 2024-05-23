using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Empurrar : MonoBehaviour
{
    
    [SerializeField] Rigidbody cubo;
    [SerializeField] private float forca = 10;

    //Sound Effects
    [SerializeField] AudioSource empurrarCaixa;
    

    private void OnTriggerEnter(Collider collider)
    {
        
        if (collider.gameObject.CompareTag("Gun"))
        {

            //BoxCollider col = new BoxCollider();
            //col.transform.position = cubo.transform.position + vector;
            empurrarCaixa.Play();
            cubo.AddForce(new Vector3(forca,0,0),ForceMode.Impulse);
            
            
        }
    }


}

