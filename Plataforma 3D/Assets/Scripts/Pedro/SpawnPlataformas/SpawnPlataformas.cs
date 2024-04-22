using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlataformas : MonoBehaviour
{
    [SerializeField] GameObject inimigo;
    [SerializeField] GameObject plataforma;
    private bool destruido = true;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Spawnar();
        if (destruido == true && inimigo.gameObject == null)
        {
            Instantiate(plataforma, gameObject.transform);
            destruido=false;
        }
    }

    private void Spawnar()
    {
        if(inimigo.gameObject == null) 
        {   
            destruido = true;
        }
    }
}
