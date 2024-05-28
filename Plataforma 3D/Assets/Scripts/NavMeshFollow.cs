using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshFollow : MonoBehaviour
{
    public Animator slime;
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
           slime.SetBool("Andando", perseguir);
        }
    }
    void Update()
    {

        if (perseguir)
        {
            enemy.SetDestination(player.position);
        }
        
    }
}
