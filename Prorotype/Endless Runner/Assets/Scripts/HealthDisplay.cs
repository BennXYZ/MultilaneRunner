using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthDisplay : MonoBehaviour {

    [SerializeField]
    GameObject healthSprite;

    List<GameObject> drawnSprites;

    HealthController healther;

    [SerializeField]
    Sprite[] healthSprites;

     Image renderer;

    bool first;

	// Use this for initialization
	void Start () {
        healther = GameObject.FindGameObjectWithTag("Game").GetComponent<HealthController>();
        renderer = gameObject.GetComponent<Image>();
        renderer.sprite = healthSprites[healther.Health];
    }

    // Update is called once per frame
    void Update() {
        Debug.Log(SceneManager.GetActiveScene().name);
    }

    public void UpdateHealth()
    {
        renderer.sprite = healthSprites[healther.Health];
    }
}
