using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trocarcamada : MonoBehaviour
{
    
    private void Awake()
    {
        Invoke(nameof(MudarCamada), 3);
    }

    public void MudarCamada()
    {
        gameObject.layer = LayerMask.NameToLayer("NInteragivel");
    }
}
