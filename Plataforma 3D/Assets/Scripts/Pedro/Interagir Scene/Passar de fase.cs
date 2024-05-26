using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Passardefase : MonoBehaviour
{
    [SerializeField] private string scenename;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Invoke("blablabla", 1f);
            SceneManager.LoadScene(scenename);
        }
    }
}