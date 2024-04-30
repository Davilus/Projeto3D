using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshFollow : MonoBehaviour
{
    //private Animator slime;
    public NavMeshAgent enemy;
    public Transform player;
    [SerializeField] private BoxCollider cool;
    private bool perseguir = false;
    //public bool andando;

    private void Start()
    {
        //slime = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
           perseguir=true;
        }
    }
    void Update()
    {

        if (perseguir)
        {
            //slime.SetBool("Andando", andando);
            enemy.SetDestination(player.position);
        }
    }
}
