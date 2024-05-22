using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public HealthManager health;
    public RawImage vida3;
    public RawImage vida2;
    public RawImage vida1;
    public RawImage vida0;

    private void Start()
    {
        health = GetComponent<HealthManager>();
    }
    void Update()
    {
        if (health.currentHealth == 3)
        {
            vida3.enabled = true;
            vida0.enabled = false;
        }
        else if (health.currentHealth == 2)
        {
            vida2.enabled = true;
            vida3.enabled = false;
        }
        else if (health.currentHealth == 1)
        {
            vida1.enabled = true;
            vida2.enabled = false;
        }
        else if (health.currentHealth == 0)
        {
            vida0.enabled = true;
            vida3.enabled = false;
            vida2.enabled = false;
            vida1.enabled = false;
        }
    }
}
