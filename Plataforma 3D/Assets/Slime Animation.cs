using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAnimation : MonoBehaviour
{
    private Animator slime;
    public bool andando;
    // Start is called before the first frame update
    void Start()
    {
        slime = GetComponent<Animator>();
      
    }

    // Update is called once per frame
    void Update()
    {
        slime.SetBool("Andando", andando);
        
    }
}
