using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawning : MonoBehaviour
{

    [SerializeField]
    private GameObject[] groundTiles;

    [SerializeField]
    private int[] blockChance;

    [SerializeField]
    float offSetX;
    [SerializeField]
    float offSetY;

    bool blockSpawned = false;

    GameObject mainCamera;

    // Use this for initialization
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, mainCamera.transform.position) < 20 && !blockSpawned)
        {
            SpawnNextGround();
            blockSpawned = true;
        }
    }

    private bool SpawnNextGround()
    {
        int fullChance = 0;

        for (int i = 0; i < blockChance.Length; i++)
            fullChance += blockChance[i];

        float Chance = Random.value * fullChance;
        float currentChance = 0;

        for (int i = 0; i < groundTiles.Length; i++)
        {
            currentChance += blockChance[i];
            if (currentChance >= Chance)
            {
                GameObject nextBlock = GameObject.Instantiate(groundTiles[i],
                    new Vector3(transform.localPosition.x + offSetX, transform.localPosition.y + offSetY, transform.localPosition.z),
                    transform.rotation, transform.parent);
                nextBlock.name = groundTiles[i].name;
                return true;
            }
        }

        GameObject Catch = GameObject.Instantiate(groundTiles[groundTiles.Length - 1],
    new Vector3(transform.localPosition.x + offSetX, transform.localPosition.y + offSetY, transform.localPosition.z),
    transform.rotation, transform.parent);
        Catch.name = groundTiles[groundTiles.Length - 1].name;

        return true;
    }
}
