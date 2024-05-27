using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quebrarrestos : MonoBehaviour
{
    private void Awake()
    {
        Invoke(nameof(Destruir), 4);
    }

    public void Destruir()
    {
        Destroy(gameObject);
    }
}
