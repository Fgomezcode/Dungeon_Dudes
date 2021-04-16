using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticle : MonoBehaviour
{
    //this function is called when the particle system needs to play
    public void particlePlay()
    {
      gameObject.GetComponent<ParticleSystem>().Play();
    }
}
