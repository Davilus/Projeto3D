using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empurrar : MonoBehaviour, Interagivel
{
    [SerializeField] Transform player;
    [SerializeField] private float Magnitude = 2;

    //public float speed = 3f;
    //public float smoothTime = 0.5f;
    //public Vector3 alvo = new Vector3(0, 0, 2);
    //Vector3 currentVelocity;
    public void Interagir()
    {

        //transform.Translate(alvo);

        //transform.position = Vector3.SmoothDamp(transform.position, alvo, ref currentVelocity, smoothTime);


        //Rigidbody body = GetComponent<Rigidbody>();
        //if (body != null)
        //{
        //    Vector3 direcaoForca = body.position - player.position;
        //    direcaoForca.y = 0;
        //    direcaoForca.Normalize();

        //    body.AddForceAtPosition(direcaoForca * Magnitude, player.position, ForceMode.Impulse);
        //}
    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.F)) 
        {
            transform.Translate(3, 0, 0);
        }
        
    }


}
