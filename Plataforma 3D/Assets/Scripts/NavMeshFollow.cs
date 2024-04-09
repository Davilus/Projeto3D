using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshFollow : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform player;
    [SerializeField] private BoxCollider cool;
    private bool perseguir = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
           perseguir=true;
        }
    }
    void Update()
    {

        if(perseguir)
            enemy.SetDestination(player.position);
    }
}
