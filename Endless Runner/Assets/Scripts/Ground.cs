using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{

    GameObject ground;

    [Range(0,1)]
    [SerializeField]
    float spikeChance;

    [SerializeField]
    GameObject spikes;

    [SerializeField]
    GameObject rotator;

    [SerializeField]
    bool spawnSpikes;

    // Use this for initialization
    void Start()
    {
        if (Random.value < spikeChance && spawnSpikes)
        {
            GameObject spikez = GameObject.Instantiate(spikes, transform.parent);
            spikez.name = "Spikes";
            spikez.transform.rotation = transform.rotation;
            spikez.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + 1.5f, transform.localPosition.z);
        }

        if (Random.value < spikeChance && spawnSpikes)
        {
            GameObject spikez = GameObject.Instantiate(spikes, transform.parent);
            spikez.name = "Spikes";
            spikez.transform.rotation = transform.rotation;
            spikez.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - 1.5f, transform.localPosition.z);
        }

        if (Random.value < 0.3f && spawnSpikes)
        {
            GameObject ratator = GameObject.Instantiate(rotator, transform.parent);
            ratator.name = "Rotator";
            ratator.transform.rotation = transform.rotation;
            ratator.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Spawner")
        {
            ground = GameObject.Instantiate(gameObject, transform.parent);
            ground.name = "Ground";
            ground.transform.localPosition = new Vector3(transform.localPosition.x + 10, transform.localPosition.y, transform.localPosition.z);
        }
    }

}