using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    #region Enums

    /// <summary>
    /// Enum of all menu states.
    /// </summary>
    public enum MenuStates
    {
        Splashscreen,
        Main,
        Play,
        Store,
        Options
    }

    #endregion
    
    #region variables
    
    // Variable for define current state.
    public MenuStates currentState;

    // Pause menu
    GameObject[] pauseObjects;
    
    // Menu panel objects as GameObjects.
    public GameObject splashScreen;
    public GameObject mainMenu;
    public GameObject playMenu;
    public GameObject shopMenu;
    public GameObject optionsMenu;

    #endregion

    #region Sound

    // Toggles
    [HideInInspector]
    public Toggle isSoundOn;
    [HideInInspector]
    public Toggle isMusicOn;

    public bool isSoundMuted;
    public bool isMusicMuted;

    // AudioSources
    public AudioSource sourceAudio;
    public AudioSource sourceMusic;

    // Slider
    public Slider volumeSound;
    public Slider volumeMusic;

    #endregion

    /// <summary>
    /// Initialize any variables or game states before the game starts.
    /// Is called only once during the lifetime of the script instance.
    /// </summary>
    void Awake()
    {
        // Always sets first state to splashscreen
        //currentState = MenuStates.Splashscreen;
        currentState = MenuStates.Main;
    }

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start ()
    {
        // Used for pause menu
        Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        hidePaused();
	}

	// Update is called once per frame
	void Update ()
    {
        // Debug input mode only!
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(Time.timeScale == 1)
            {
                Time.timeScale = 0;
                showPaused();
            }
            else if(Time.timeScale == 0)
            {
                Time.timeScale = 1;
                hidePaused();
            }
        }

        // Checks current menu state
        switch (currentState)
        {
            case MenuStates.Splashscreen:
                splashScreen.SetActive(true);
                mainMenu.SetActive(false);
                playMenu.SetActive(false);
                shopMenu.SetActive(false);
                optionsMenu.SetActive(false);
                break;

            case MenuStates.Main:
                mainMenu.SetActive(true);
                splashScreen.SetActive(false);
                playMenu.SetActive(false);
                shopMenu.SetActive(false);
                optionsMenu.SetActive(false);
                break;

            case MenuStates.Play:
                playMenu.SetActive(true);
                splashScreen.SetActive(false);
                mainMenu.SetActive(false);
                shopMenu.SetActive(false);
                optionsMenu.SetActive(false);
                break;
                
            case MenuStates.Store:
                shopMenu.SetActive(true);
                splashScreen.SetActive(false);
                mainMenu.SetActive(false);
                playMenu.SetActive(false);
                optionsMenu.SetActive(false);
                break;

            case MenuStates.Options:
                optionsMenu.SetActive(true);
                splashScreen.SetActive(false);
                mainMenu.SetActive(false);
                playMenu.SetActive(false);
                shopMenu.SetActive(false);
                break;
        }
    }

    #region Button OnClick

    /// <summary>
    /// Interaction with play button on main menu.
    /// </summary>
    public void OnMainPlay()
    {
        // Log activity
        Debug.Log("You pressed Play!");

        currentState = MenuStates.Play;
    }

    /// <summary>
    /// Interaction with play button on play menu.
    /// </summary>
    public void OnPlayStart()
    {
        // Log activity
        Debug.Log("You pressed Start Game!");

        SceneManager.LoadScene("GameScene");
    }

    /// <summary>
    /// Interaction with options button.
    /// </summary>
    public void OnOptions()
    {
        // Log activity
        Debug.Log("You pressed options!");

        currentState = MenuStates.Options;
    }


    /// <summary>
    /// Interaction with store button.
    /// </summary>
    public void OnStore()
    {
        // Log activity
        Debug.Log("Store button clicked.");

        // Change menu state
        currentState = MenuStates.Store;
    }

    /// <summary>
    /// Interaction with back button.
    /// Changes current state to mainMenu.
    /// </summary>
    public void OnBackToMenu()
    {
        // Log activity
        Debug.Log("Go back to main menu.");

        // Change menu state
        currentState = MenuStates.Main;
    }

    /// <summary>
    /// Interaction with exit button.
    /// </summary>
    public void OnExit()
    {
        // Log activity
        Debug.Log("Exit button clicked.");

        Application.Quit();
    }

    #endregion

    #region PauseMenu

    /// <summary>
    /// Controls the pausing of the scene.
    /// </summary>
    public void pauseControl()
    {
        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
            showPaused();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            hidePaused();
        }
    }
    
    /// <summary>
    /// Shows objects with ShowOnPause tag.
    /// </summary>
    public void showPaused()
    {
        foreach(GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }

    /// <summary>
    /// Hides objects with ShowOnPause tag.
    /// </summary>
    public void hidePaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }

    /// <summary>
    /// Go back to the missions screen.
    /// </summary>
    public void missionsScreen()
    {
        currentState = MenuStates.Play;
    }

    /// <summary>
    /// Visit the store.
    /// </summary>
    public void storeScreen()
    {
        currentState = MenuStates.Store;
    }
    
    /// <summary>
    /// Show options menu.
    /// </summary>
    public void optionsScreen()
    {
        currentState = MenuStates.Options;
    }

    #endregion

    #region AudioSourceHandler

    public void ToggleAudio(bool isSoundMuted)
    {
        // Is sound muted?
        if(isSoundOn == !isSoundOn.isOn)
        {
            isSoundMuted = true;
        }
        
        // Is music muted?
        if (isMusicOn == !isMusicOn.isOn)
        {
            isMusicMuted = true;
        }
    }

    public void SoundController()
    {
        if (isSoundMuted == true)
        {
            sourceAudio.volume = 0.0f;
            volumeSound.value = sourceAudio.volume;
        }
        else
        {
            sourceAudio.volume = volumeSound.value;
        }
    }

    public void MusicController()
    {
        if (isMusicMuted == true)
        {
            sourceMusic.volume = 0.0f;
            volumeMusic.value = sourceMusic.volume;
        }
        else
        {
            sourceMusic.volume = volumeMusic.value;
        }
    }

    #endregion
}
