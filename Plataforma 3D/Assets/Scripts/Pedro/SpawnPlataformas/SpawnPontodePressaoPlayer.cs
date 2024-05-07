using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPontodePressaoPlayer : MonoBehaviour
{
    [SerializeField] GameObject gameObject;
    private bool spawnou = false;
    private bool primeiroSpawn = true;
    [SerializeField] private BoxCollider col;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            spawnou = true;
           
        }
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnou && primeiroSpawn) 
        {
            gameObject.SetActive(true);
        }
    }
}
