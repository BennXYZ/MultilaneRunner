using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{

    [SerializeField]
    GameObject ground;

    [SerializeField]
    GameObject cornerGround;

    GameObject mainCamera;

    GameObject grund;

    GroundMove groundMove;

    GameController.Directions direction;

    [Range(0,1)]
    [SerializeField]
    float spikeChance;

    [SerializeField]
    GameObject spikesBLU;

    [SerializeField]
    GameObject spikesRED;

    [Range(0, 1)]
    [SerializeField]
    float rotatorChance;

    [SerializeField]
    GameObject rotator;

    [SerializeField]
    bool corner;

    // Use this for initialization
    void Start()
    {
        if (Random.value < spikeChance)
        {
            GameObject spikez = GameObject.Instantiate(spikesBLU, transform);
            spikez.name = "Spikes";
            spikez.transform.rotation = transform.rotation;
            spikez.transform.localPosition = new Vector3(0, 0 + 1.2f, 0);
        }

        if (Random.value < spikeChance)
        {
            GameObject spikez = GameObject.Instantiate(spikesRED, transform);
            spikez.name = "Spikes";
            spikez.transform.rotation = transform.rotation;
            spikez.transform.localScale = new Vector3(spikez.transform.localScale.x, -spikez.transform.localScale.y, spikez.transform.localScale.z);
            spikez.transform.localPosition = new Vector3(0, 0 - 1.2f, 0);
        }

        //if (Random.value < rotatorChance && spawnSpikes)
        //{
        //    GameObject ratator = GameObject.Instantiate(rotator, transform);
        //    ratator.name = "Rotator";
        //    ratator.transform.rotation = transform.rotation;
        //    ratator.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        //}

        groundMove = transform.parent.GetComponent<GroundMove>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    public void SetDirection(GameController.Directions nextDirection)
    {
        direction = nextDirection;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position +=(new Vector3(- groundMove.direction.x * Time.deltaTime * 8,-groundMove.direction.y * Time.deltaTime * 8, 0));

        if (Vector3.Distance(transform.position, mainCamera.transform.position) < 20 && grund == null)
            SpawnNextBlock();
    }

    void SpawnNextBlock()
    {
        if(corner)
        {
            grund = GameObject.Instantiate(ground, transform.parent);
            grund.name = "Ground";
            grund.transform.rotation = transform.rotation;
            grund.transform.Rotate(new Vector3(0,0,90));
            grund.transform.localPosition = new Vector3(transform.localPosition.x + Mathf.Cos(Mathf.Deg2Rad * grund.transform.localRotation.eulerAngles.z) * 8, transform.localPosition.y + Mathf.Cos(Mathf.Deg2Rad * (grund.transform.localRotation.eulerAngles.z - 90)) * 8, transform.localPosition.z);
        }
        else if (Random.value < rotatorChance && GameObject.FindGameObjectsWithTag("Rotator").Length == 0)
        {
            grund = GameObject.Instantiate(cornerGround, transform.parent);
            grund.name = "Corner";
            grund.transform.rotation = transform.rotation;
            grund.transform.localPosition = new Vector3(transform.localPosition.x + Mathf.Cos(Mathf.Deg2Rad * transform.localRotation.eulerAngles.z) * 1.03f, transform.localPosition.y + Mathf.Cos(Mathf.Deg2Rad * (transform.localRotation.eulerAngles.z - 90)) * 1.03f, transform.localPosition.z);
        }
        else
        {
            grund = GameObject.Instantiate(ground, transform.parent);
            grund.name = "Ground";
            grund.transform.rotation = transform.rotation;
            grund.transform.localPosition = new Vector3(transform.localPosition.x + Mathf.Cos(Mathf.Deg2Rad * transform.localRotation.eulerAngles.z) * 1.03f, transform.localPosition.y + Mathf.Cos(Mathf.Deg2Rad * (transform.localRotation.eulerAngles.z - 90)) * 1.03f, transform.localPosition.z);
        }

    }
}