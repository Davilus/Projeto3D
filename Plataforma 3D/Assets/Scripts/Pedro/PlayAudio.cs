using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    [SerializeField] AudioSource audioS;
    
    public void PlaySFX()
    {
        audioS.Play();
    } 

    
}
