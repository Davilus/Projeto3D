using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform PontodeInteracao;
    [SerializeField] private float AlcancedeInteracao = 0.5f;
    [SerializeField] private LayerMask MascaraInteragível;

    private readonly Collider[] _colliders = new Collider[1];

    [SerializeField] private int _encontrados;

    private void Update()
    {
        _encontrados = Physics.OverlapSphereNonAlloc(PontodeInteracao.position
                                                    , AlcancedeInteracao, _colliders,
                                                    MascaraInteragível);

        //if (_encontrados > 0)
        //{
        //    var interactable = _colliders[0].GetComponents<IInterface>();

        //    if (interactable != null && Keyboard.current.eKey.wasPressedThisFrame)
        //    {

        //        interactable.Interact();
        //    }
        //}
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(PontodeInteracao.position, AlcancedeInteracao);
    //}
}
