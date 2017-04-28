using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSceneByIndex : MonoBehaviour {

    [SerializeField]
    Slider progressBar;

    AsyncOperation ao;

    bool isLoading = false;

    private void Update()
    {
       if(isLoading)
        {
            progressBar.value = ao.progress;
        }
    }

    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadScene(int sceneIndex)
    {
        ao = SceneManager.LoadSceneAsync(sceneIndex);
        isLoading = true;
    }
}
