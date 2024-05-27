using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TerminarJogo : MonoBehaviour
{
    [SerializeField] float tempo = 5;
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(terminarJogo),tempo);
    }

    public void terminarJogo()
    {
        SceneManager.LoadScene("Tela Final");
    }
}
