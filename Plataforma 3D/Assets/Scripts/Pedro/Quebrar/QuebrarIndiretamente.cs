using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuebrarIndiretamente : MonoBehaviour
{
    [SerializeField] GameObject cubo;    
    
    // Update is called once per frame
    void Update()
    {
        if (cubo == null)
        {
            gameObject.SetActive(false);
        }
    }
}
