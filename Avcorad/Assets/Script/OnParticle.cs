using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnParticle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            GetComponent<ParticleSystem>().Play();
        }
    }
}
