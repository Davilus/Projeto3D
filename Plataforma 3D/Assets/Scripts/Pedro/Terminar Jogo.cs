using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TerminarJogo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(terminarJogo),3f);
    }

    public void terminarJogo()
    {
        SceneManager.LoadScene("Tela Final");
    }
}
