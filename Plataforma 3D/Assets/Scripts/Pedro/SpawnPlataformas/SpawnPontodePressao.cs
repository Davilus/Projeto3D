using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPontodePressao : MonoBehaviour
{
    [SerializeField] GameObject plataforma;
    private bool spawnou = false;
    private bool primeiroSpawn = true;
    [SerializeField] private BoxCollider col;

    // Sound Effect
    [SerializeField] AudioSource botaoPressionado;

    //Movimento Smooth Damp
    [SerializeField] float speed = 3;
    [SerializeField] float smoothTime = 0.5f;
    [SerializeField] Vector3 diferenca = new Vector3(0, 3, 0);

    Vector3 alvo;
    Vector3 currentVCelocity;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Caixa Empurrável"))
        {
            botaoPressionado.Play();
            spawnou = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        alvo = transform.localPosition + diferenca;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnou && primeiroSpawn) 
        {
            plataforma.SetActive(true);
        }
        if (spawnou) 
        {
            transform.position = Vector3.SmoothDamp(transform.localPosition, alvo, ref currentVCelocity, smoothTime);
        }
    }
}
