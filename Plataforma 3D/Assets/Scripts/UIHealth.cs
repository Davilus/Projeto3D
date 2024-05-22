using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public HealthManager health;
    public GameObject vida3;
    public GameObject vida2;
    public GameObject vida1;
    public GameObject vida0;

    void Update()
    {
        if (health.currentHealth == 3)
        {
            vida3.SetActive(true);
            vida0.SetActive(false);
        }
        else if (health.currentHealth == 2)
        {
            vida2.SetActive(true);
            vida3.SetActive(false);
        }
        else if (health.currentHealth == 1)
        {
            vida1.SetActive(true);
            vida2.SetActive(false);
        }
        else if (health.currentHealth <= 0)
        {
            vida0.SetActive(true);
            vida3.SetActive(false);
            vida2.SetActive(false);
            vida1.SetActive(false);
        }
    }
}
