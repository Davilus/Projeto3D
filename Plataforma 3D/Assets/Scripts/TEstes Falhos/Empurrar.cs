using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empurrar : MonoBehaviour, Interagivel
{
    [SerializeField] Transform player;
    [SerializeField] private float Magnitude = 2;
    public void Interagir()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null )
        {
            Vector3 direcaoForca = body.position-player.position;
            direcaoForca.y = 0;
            //if ( direcaoForca.x > direcaoForca.z )
            //{
            //    direcaoForca.z = 0;
            //}
            //if (direcaoForca.x < direcaoForca.z)
            //{
            //    direcaoForca.x = 0;
            //}
            //if( direcaoForca.x == direcaoForca.z)
            //{
            //    direcaoForca.x = 0;
            //    direcaoForca.z = 0;
            //}
            direcaoForca.Normalize();

            body.AddForceAtPosition(direcaoForca * Magnitude, player.position, ForceMode.Impulse);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
