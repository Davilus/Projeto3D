using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nãodestruir : MonoBehaviour
{
    
    private void Awake()
    {
        GameObject[] musicObject = GameObject.FindGameObjectsWithTag("GameMusic");
        if (musicObject.Length > 1  )
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && SceneManager.GetActiveScene().name == "Fase 1")
        {
            Destroy(this.gameObject);
        }

        if (SceneManager.GetActiveScene().name == "Tela Final")
        {
            Destroy(this.gameObject);
        }
    }
}
