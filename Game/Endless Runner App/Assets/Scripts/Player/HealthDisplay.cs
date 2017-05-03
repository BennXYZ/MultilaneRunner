using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{

    [SerializeField]
    Sprite[] HealthSprites;

    [SerializeField]
    SpriteRenderer renderer;

    [SerializeField]
    HealthManager manager;

    [SerializeField]
    bool bossHealth = false;

    // Use this for initialization
    void Start()
    {
        if(!bossHealth)
            UpdateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        if (manager != null)
            renderer.sprite = HealthSprites[manager.Health()];
        else
            renderer.sprite = HealthSprites[0];
    }

    public void CheckForBoss()
    {
        if (GameObject.FindGameObjectWithTag("Boss") != null)
        {
            manager = GameObject.FindGameObjectWithTag("Boss").GetComponent<HealthManager>();
            UpdateHealth();
        }
    }

    public void UpdateHealth()
    {
            //if (manager.Health() >= 0)
            //    renderer.sprite = HealthSprites[manager.Health()];
    }
}
