using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    public AudioSource music;

    private void OnTriggerEnter(Collider other)
    {
        music.Play();
    }
}
