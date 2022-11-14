using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkSound : MonoBehaviour
{
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Ground")
        {
            Debug.Log("πﬂ ∂•ø° ¥Í¿Ω");
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            
        }
    }

}
