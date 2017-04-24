using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{

    [SerializeField]
    Sprite[] HealthSprites;

    [SerializeField]
#pragma warning disable CS0108 // Element blendet vererbte Element aus; fehlendes 'new'-Schlüsselwort
    SpriteRenderer renderer;
#pragma warning restore CS0108 // Element blendet vererbte Element aus; fehlendes 'new'-Schlüsselwort

    [SerializeField]
    HealthManager manager;

    // Use this for initialization
    void Start()
    {
        UpdateHealth();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateHealth()
    {
        if (manager.Health() >= 0)
        renderer.sprite = HealthSprites[manager.Health()];
    }
}
