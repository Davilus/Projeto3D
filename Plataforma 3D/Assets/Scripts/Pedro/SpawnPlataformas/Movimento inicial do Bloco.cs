using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoinicialdoBloco : MonoBehaviour
{
    [SerializeField] float speed = 3;
    [SerializeField] float smoothTime = 0.5f;
    [SerializeField] Vector3 diferenca = new Vector3(0,2,0);
    //[SerializeField] Transform lugarOrigim;
    Vector3 alvo;
    Vector3 currentVCelocity;


    // Start is called before the first frame update
    void Start()
    {
        alvo = transform.position + diferenca;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.localPosition, alvo, ref currentVCelocity,smoothTime);
    }
}
