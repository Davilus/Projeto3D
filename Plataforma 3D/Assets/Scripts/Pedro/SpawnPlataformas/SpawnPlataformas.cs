using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnPlataformas : MonoBehaviour
{
    [SerializeField] GameObject inimigo;
    [SerializeField] GameObject plataforma;
    private bool destruido = true;

    //Movimento Smooth Damp
    [SerializeField] float speed = 3;
    [SerializeField] float smoothTime = 0.5f;
    [SerializeField] Vector3 diferenca = new Vector3(0, 2, 0);
    
    Vector3 alvo;
    Vector3 currentVCelocity;


    // Start is called before the first frame update
    void Start()
    {
        alvo = transform.localPosition + diferenca;
    }

    // Update is called once per frame
    void Update()
    {
        //Spawnar();
        if (destruido == true && inimigo.gameObject == null)
        {
            plataforma.SetActive(true);
            destruido =false;
        }
        if(inimigo.gameObject == null)
            transform.position = Vector3.SmoothDamp(transform.localPosition, alvo, ref currentVCelocity, smoothTime);
    }

    private void Spawnar()
    {
        if(inimigo.gameObject == null) 
        {   
            destruido = true;
        }
    }
}
