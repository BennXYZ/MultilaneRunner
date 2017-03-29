using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

    #region Enums

    /// <summary>
    /// Enum of all menu states.
    /// </summary>
    public enum MenuStates
    {
        Splashscreen,
        Main,
        Play,
        //Missions,
        //Quests,
        //Archievments,
        Shop,
        Options,
        Pause,
        Credits
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
    //public GameObject missionsMenu;
    //public GameObject questsMenu;
    //public GameObject achievmentsMenu;
    public GameObject shopMenu;
    public GameObject optionsMenu;
    public GameObject creditsMenu;
    
    // Toggles
    public bool isOptionSelected;
    public Toggle isAudioMuted;
    public Toggle isMusicMuted;
    public bool isTutorial;
    public Toggle isTutorialSelected;
    public bool isLevel;
    public Toggle isLevelSelected;

    #endregion

    /// <summary>
    /// Initialize any variables or game states before the game starts.
    /// Is called only once during the lifetime of the script instance.
    /// </summary>
    void Awake()
    {
        // Always sets first state to splashscreen
        currentState = MenuStates.Splashscreen;
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
                //missionsMenu.SetActive(false);
                //questsMenu.SetActive(false);
                //achievmentsMenu.SetActive(false);
                shopMenu.SetActive(false);
                optionsMenu.SetActive(false);
                creditsMenu.SetActive(false);
                break;

            case MenuStates.Main:
                mainMenu.SetActive(true);
                splashScreen.SetActive(false);
                playMenu.SetActive(false);
                //missionsMenu.SetActive(false);
                //questsMenu.SetActive(false);
                //achievmentsMenu.SetActive(false);
                shopMenu.SetActive(false);
                optionsMenu.SetActive(false);
                creditsMenu.SetActive(false);
                break;

            case MenuStates.Play:
                playMenu.SetActive(true);
                splashScreen.SetActive(false);
                mainMenu.SetActive(false);
                //missionsMenu.SetActive(false);
                //questsMenu.SetActive(false);
                //achievmentsMenu.SetActive(false);
                shopMenu.SetActive(false);
                optionsMenu.SetActive(false);
                creditsMenu.SetActive(false);
                break;

            //case MenuStates.Missions:
            //    missionsMenu.SetActive(true);
            //    splashScreen.SetActive(false);
            //    mainMenu.SetActive(false);
            //    playMenu.SetActive(false);
            //    questsMenu.SetActive(false);
            //    achievmentsMenu.SetActive(false);
            //    shopMenu.SetActive(false);
            //    optionsMenu.SetActive(false);
            //    creditsMenu.SetActive(false);
            //    break;

            //case MenuStates.Quests:
            //    questsMenu.SetActive(true);
            //    splashScreen.SetActive(false);
            //    mainMenu.SetActive(false);
            //    playMenu.SetActive(false);
            //    missionsMenu.SetActive(false);
            //    achievmentsMenu.SetActive(false);
            //    shopMenu.SetActive(false);
            //    optionsMenu.SetActive(false);
            //    creditsMenu.SetActive(false);
            //    break;

            //case MenuStates.Archievments:
            //    achievmentsMenu.SetActive(true);
            //    splashScreen.SetActive(false);
            //    mainMenu.SetActive(false);
            //    playMenu.SetActive(false);
            //    missionsMenu.SetActive(false);
            //    questsMenu.SetActive(false);
            //    shopMenu.SetActive(false);
            //    optionsMenu.SetActive(false);
            //    creditsMenu.SetActive(false);
            //    break;

            case MenuStates.Shop:
                shopMenu.SetActive(true);
                splashScreen.SetActive(false);
                mainMenu.SetActive(false);
                playMenu.SetActive(false);
                //missionsMenu.SetActive(false);
                //questsMenu.SetActive(false);
                //achievmentsMenu.SetActive(false);
                optionsMenu.SetActive(false);
                creditsMenu.SetActive(false);
                break;

            case MenuStates.Options:
                optionsMenu.SetActive(true);
                splashScreen.SetActive(false);
                mainMenu.SetActive(false);
                playMenu.SetActive(false);
                //missionsMenu.SetActive(false);
                //questsMenu.SetActive(false);
                //achievmentsMenu.SetActive(false);
                shopMenu.SetActive(false);
                creditsMenu.SetActive(false);
                break;

            case MenuStates.Credits:
                creditsMenu.SetActive(true);
                splashScreen.SetActive(false);
                mainMenu.SetActive(false);
                playMenu.SetActive(false);
                //missionsMenu.SetActive(false);
                //questsMenu.SetActive(false);
                //achievmentsMenu.SetActive(false);
                shopMenu.SetActive(false);
                optionsMenu.SetActive(false);
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

        if(isTutorialSelected == true)
        {
            SceneManager.LoadScene("TutorialScene");
        }

        else if(isLevelSelected == true)
        {
            SceneManager.LoadScene("GameScene");
        }

        else
        {
            
        }
    }


    /// <summary>
    /// Interaction with back button.
    /// Changes current state to mainMenu.
    /// Back button is in every submenue except on "Start" and "Exit".
    /// </summary>
    public void OnBackToMenu()
    {
        // Log activity
        Debug.Log("Go back to main menu.");

        // Change menu state
        currentState = MenuStates.Main;
    }

    /// <summary>
    /// Interaction with help button.
    /// Changes current state to helpMenu.
    /// </summary>
    //public void OnHelp()
    //{
    //    // Log activity
    //    Debug.Log("Help button clicked.");

    //    // Change menu state
    //    currentState = MenuStates.Help;
    //}

    public void OnCredits()
    {
        // Log activity
        Debug.Log("Credits button clicked.");

        // Change menu state
        currentState = MenuStates.Credits;
    }

    public void OnExit()
    {
        // Log activity
        Debug.Log("Ext button clicked.");

        Application.Quit();

        //TODO: Menu state or just Application.Quit() ??
        // Change menu state
        //currentState = MenuStates.Exit;
    }

    #endregion

    #region Pause menu

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

    }

    /// <summary>
    /// Visit the shop.
    /// </summary>
    public void shopScreen()
    {

    }

    /// <summary>
    /// Show options menu
    /// </summary>
    public void optionScreen()
    {

    }

    #endregion

    #region EventHandler

    //NOTE: ClickHandler maybe for exit application?! -> Just mouse ...
    //public void OnPointerClick(PointerEventData eventData)
    //{
    //    if (eventData.button == PointerEventData.InputButton.Left)
    //    {
    //        Application.Quit();
    //    }
    //}

    #endregion

}
