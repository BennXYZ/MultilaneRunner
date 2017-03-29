using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDisplay : MonoBehaviour {

    [SerializeField]
    GameObject healthSprite;

    List<GameObject> drawnSprites;

    HealthController healther;

    bool first;

	// Use this for initialization
	void Start () {
        healther = GameObject.FindGameObjectWithTag("Game").GetComponent<HealthController>();
        drawnSprites = new List<GameObject>();
        first = true;
    }

    // Update is called once per frame
    void Update() {
        if(first)
        {
            for (int i = drawnSprites.Count; i < healther.Health; i++)
            {
                drawnSprites.Add(Sprite.Instantiate(healthSprite, transform.position, transform.rotation, transform));
                drawnSprites[i].transform.Translate(new Vector3(i * 2, 0, 0));
            }
            first = false;
        }
    }

    public void UpdateHealth()
    {
        if (healther.Health < drawnSprites.Count)
        {
            for (int i = healther.Health; i < drawnSprites.Count; i++)
            {
                GameObject.Destroy(drawnSprites[drawnSprites.Count - 1]);
                drawnSprites.RemoveAt(drawnSprites.Count - 1);
            }
        }
        else if (healther.Health > drawnSprites.Count)
        {
            for (int i = drawnSprites.Count; i < healther.Health; i++)
            {
                drawnSprites.Add(Sprite.Instantiate(healthSprite, transform.position, transform.rotation, transform));
                drawnSprites[i].transform.Translate(new Vector3(i * 2, 0, 0));
            }
        }
    }
}
