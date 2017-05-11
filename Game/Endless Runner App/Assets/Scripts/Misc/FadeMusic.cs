using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeMusic : MonoBehaviour
{
    [SerializeField]
    private float pitch;

    [SerializeField]
    AudioSource audio;

    [Range(0,3)]
    [SerializeField]
    float speed;

    bool pitchIsTarget;

    // Use this for initialization
    void Start()
    {
        pitchIsTarget = true;
        changePitch(pitch);
    }

    // Update is called once per frame
    void Update()
    {
        if (!pitchIsTarget)
        {
            audio.pitch += (pitch - audio.pitch) * speed * 0.01f;
            if (audio.pitch >= pitch - 0.01f && audio.pitch <= pitch + 0.01f)
            {
                audio.pitch = pitch;
                pitchIsTarget = true;
            }
        }
    }

    public void changePitch(float targetPitch)
    {
        pitch = targetPitch;
        pitchIsTarget = false;
    }

}
