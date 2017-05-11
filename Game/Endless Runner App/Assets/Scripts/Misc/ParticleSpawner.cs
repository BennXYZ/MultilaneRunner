using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ParticleSpawner : MonoBehaviour {

    [SerializeField]
    GameObject particle;

    public void SpawnParticle()
    {
        GameObject.Instantiate(particle, gameObject.transform.position, gameObject.transform.rotation);
    }
}
