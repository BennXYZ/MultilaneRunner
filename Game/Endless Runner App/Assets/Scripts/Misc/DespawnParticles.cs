using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DespawnParticles : MonoBehaviour {

    List<ParticleSystem> particles;

    ParticleSystem ownParticles;

	// Use this for initialization
	void Start () {
        particles = new List<ParticleSystem>();
        if (GetComponent<ParticleSystem>() != null)
            ownParticles = GetComponent<ParticleSystem>();
        ParticleSystem[] childParticles = GetComponentsInChildren<ParticleSystem>();
        for (int i = 0; i < childParticles.Length; i++)
            particles.Add(childParticles[i]);
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < particles.Count; i++)
        {
            if (!particles[i].isPlaying)
            {
                Destroy(particles[i]);
                particles.RemoveAt(i);
            }
        }
        if (particles.Count == 0)
        {
            if (ownParticles == null)
                Destroy(gameObject);
            else if (!ownParticles.isPlaying)
                                Destroy(gameObject);
        }
    }

    public void RemoveParticle()
    {
        for(int i = 0; i < particles.Count; i++)
        {
            if(!particles[i].isPlaying)
            {
                Destroy(particles[i]);
                particles.RemoveAt(i);
            }
        }
    }
}
