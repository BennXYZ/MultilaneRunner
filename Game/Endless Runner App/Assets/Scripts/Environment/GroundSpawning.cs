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
    Vector2 OffSet;

    [SerializeField]
    float SpawnDistance;

    [SerializeField]
    bool blockSpawned = false;
    
    bool Boss;

    GameObject mainCamera;

    MovementManager manager;

    // Use this for initialization
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        manager = GameObject.FindGameObjectWithTag("GroundParent").GetComponent<MovementManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, mainCamera.transform.position) < SpawnDistance && !blockSpawned)
        {
            SpawnNextGround();
            blockSpawned = true;
        }
    }

    public void SetBoss(bool bossState)
    {
        Boss = bossState;
    }

    private bool SpawnNextGround()
    {
        if(!Boss)
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
                        new Vector3(transform.localPosition.x + OffSet.x, transform.localPosition.y + OffSet.y, transform.localPosition.z),
                        transform.rotation, transform.parent);
                    //nextBlock.transform.Translate(manager.Direction * manager.Speed * Time.deltaTime);
                    nextBlock.name = groundTiles[i].name;
                    return true;
                }
            }

            GameObject Catch = GameObject.Instantiate(groundTiles[groundTiles.Length - 1],
        new Vector3(transform.localPosition.x + OffSet.x, transform.localPosition.y + OffSet.y, transform.localPosition.z),
        transform.rotation, transform.parent);
            Catch.name = groundTiles[groundTiles.Length - 1].name;
            //Catch.transform.Translate(manager.Direction * manager.Speed * Time.deltaTime);

            return true;
        }
        else
        {
            GameObject nextBlock = GameObject.Instantiate(groundTiles[0],
                        new Vector3(transform.localPosition.x + OffSet.x, transform.localPosition.y + OffSet.y, transform.localPosition.z),
                        transform.rotation, transform.parent);
            //nextBlock.transform.Translate(manager.Direction * manager.Speed * Time.deltaTime);
            nextBlock.name = groundTiles[0].name;
            nextBlock.GetComponent<GroundSpawning>().SetBoss(true);
            return true;
        }
    }
}
