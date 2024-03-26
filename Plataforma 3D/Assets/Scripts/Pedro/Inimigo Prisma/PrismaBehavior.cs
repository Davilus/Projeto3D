using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrismaBehavior : MonoBehaviour
{
     private float x;
     private float y;
     private float z;

    [SerializeField] private int amplitudeX;
    [SerializeField] private int amplitudeY;
    [SerializeField] private int amplitudeZ;

    [SerializeField] private float frequenciaX;
    [SerializeField] private float frequenciaY;
    [SerializeField] private float frequenciaZ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x = Mathf.Sin(Time.time * frequenciaX) * amplitudeX;
        y = Mathf.Sin(Time.time * frequenciaY) * amplitudeY;
        z = Mathf.Cos(Time.time * frequenciaZ) * amplitudeZ;

        transform.localPosition = new Vector3(x,y,z);
    }
}
