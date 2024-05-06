using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuebrarPorPontodePressão : MonoBehaviour
{

    [SerializeField] GameObject plataforma;
    private bool quebrou = false;
    //private bool primeiroSpawn = true;
    [SerializeField] private BoxCollider col;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Caixa Empurrável"))
        {
            quebrou = true;
        }
    }

    void Update()
    {
        if (quebrou)
        {
            plataforma.SetActive(false);
        }
    }
}
