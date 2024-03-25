using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


interface Interagivel
{
    public void Interagir();
}
public class Interagir : MonoBehaviour
{
    public Transform fonteDaInteracao;
    public float alcanceDaInteracao = 1;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Ray r = new Ray(fonteDaInteracao.position, fonteDaInteracao.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, alcanceDaInteracao))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out Interagivel interactObj))
                {
                    interactObj.Interagir();
                }
            }
        }
        
    }

    //private void AreadeInteracao() // Metodo errado :(
    //{
    //    Gizmos.color = Color.blue;
    //    Gizmos.DrawWireSphere(fonteDaInteracao.position, alcanceDaInteracao);  
    //}
}
