using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDead : MonoBehaviour
{

    public AudioSource morre;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            morre.Play();
        }
    }
}
