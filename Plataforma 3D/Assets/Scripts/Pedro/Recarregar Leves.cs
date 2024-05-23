using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RecarregarLeves : MonoBehaviour
{

    [SerializeField] private string fase;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        { //If you press R
            SceneManager.LoadScene(fase); //Load scene called Game
        }
    }
}
