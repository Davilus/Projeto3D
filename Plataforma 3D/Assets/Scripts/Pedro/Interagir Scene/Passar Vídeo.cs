using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassarVídeo : MonoBehaviour
{

    private void Start()
    {
        Invoke(nameof(passarVideo), 22);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        { //If you press Esq
            SceneManager.LoadScene("Fase 1"); //Load scene called Game
        }
    }

    public void passarVideo()
    {
        SceneManager.LoadScene("Fase 1");
        Debug.Log("Funcionou");
    }
}
