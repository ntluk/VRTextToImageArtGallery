using Tobii.XR.GazeModifier;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Tobii.XR;
using System;

public class DevToolsMenuController : MonoBehaviour
{
    [SerializeField] private bool startWithVisualizers = true;
    [SerializeField] private GameObject gazeVisualizerObject;
    [SerializeField] private GameObject openSettingButton;
    [SerializeField] private GameObject openHologramButton;
    [SerializeField] private GameObject openBookButton;
    [SerializeField] private GameObject settingMenu;
    [SerializeField] private GameObject hologramMenu;
    [SerializeField] private GameObject bookMenu;
    [SerializeField] private GameObject zodiac;
    [SerializeField] private GameObject frontOfBook;
    [SerializeField] private GameObject flipPage;
    [SerializeField] private GameObject tutorialMenu;
    [SerializeField] private GameObject sun;
    [SerializeField] private GameObject moon;
    [SerializeField] private GameObject backgroundSound;
    [SerializeField] private GameObject starBoundMesh;
    [SerializeField] private DevToolsUITriggerGazeToggleButton gazeVisualizerToggle;
    [SerializeField] private GameObject closeButton;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip openCompassSound;
    [SerializeField] private AudioClip buttonSound;

    private G2OM_DebugVisualization _debugVisualization;
    private GazeModifierFilter _gazeModifierFilter;
    private bool _gazeVisualizerEnabled = true;
    private bool _started = false;
    private RectTransform rtZodiac;
    private GameObject[] starsCapricorn;
    private GameObject[] starsAries;
    private GameObject[] starsCancer;
    private GameObject[] starsLeo;
    private GameObject[] starsLibra;
    private GameObject[] starsPisces;
    private GameObject[] starsAquarius;
    private GameObject[] starsVirgo;
    private GameObject[] starsTaurus;
    private GameObject[] starsGemini;
    private GameObject[] starsScorpio;
    private GameObject[] starsSagittarius;
    private LineRenderer lineRendererGaze;
    private GameObject menuStatus;
    private GameObject gazeVisualizer;
    public GameObject compass;
    public GameObject compassCap;
    public GameObject arrow;
    private Vector3 rotationVector;
    private DateTime startTime;
    private DateTime endTime;
    private bool isCompassOpened = false;
    private bool wasTutorialOpenedOnce = false;

    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame(); // Wait a sec so the default G2OM instance can be instantiated

        FindGameObjects();
        rtZodiac = zodiac.GetComponent<RectTransform>();
        lineRendererGaze = gazeVisualizer.GetComponent<LineRenderer>();

        // Deactivates star interaction at the beginning
        EnableStars(false, true, false);

        // Ensure we use the dev tools filter
        if (TobiiXR.Internal.Settings.EyeTrackingFilter != null)
        {
            Debug.LogWarning("TobiiXR was initialized with a gaze filter on '"
                                + TobiiXR.Internal.Settings.EyeTrackingFilter.gameObject.name
                                + "'. Dev Tools overwrote this with its own gaze modifier filter.");
        }

        _gazeModifierFilter = gameObject.GetComponent<GazeModifierFilter>();
        TobiiXR.Internal.Settings.EyeTrackingFilter = _gazeModifierFilter;

        var cameraTransform = CameraHelper.GetCameraTransform();
        _debugVisualization = cameraTransform.gameObject.AddComponent<G2OM_DebugVisualization>();

        _gazeVisualizerEnabled = startWithVisualizers;
        SetGazeVisualizerEnabled(_gazeVisualizerEnabled);
        _started = true;
        EnsureCorrectVisualizer();
    }

    private void FindGameObjects() 
    {
        starsCapricorn = GameObject.FindGameObjectsWithTag("StarCapricorn");
        starsAries = GameObject.FindGameObjectsWithTag("StarAries");
        starsCancer = GameObject.FindGameObjectsWithTag("StarCancer");
        starsLeo = GameObject.FindGameObjectsWithTag("StarLeo");
        starsLibra = GameObject.FindGameObjectsWithTag("StarLibra");
        starsPisces = GameObject.FindGameObjectsWithTag("StarPisces");
        starsAquarius = GameObject.FindGameObjectsWithTag("StarAquarius");
        starsVirgo = GameObject.FindGameObjectsWithTag("StarVirgo");
        starsTaurus = GameObject.FindGameObjectsWithTag("StarTaurus");
        starsGemini = GameObject.FindGameObjectsWithTag("StarGemini");
        starsScorpio = GameObject.FindGameObjectsWithTag("StarScorpio");
        starsSagittarius = GameObject.FindGameObjectsWithTag("StarSagittarius");
        menuStatus = GameObject.Find("MenuStatus");
        gazeVisualizer = GameObject.Find("GazeUtilityMenu/Offset/GazeVisualizer");
    }

    private void Update()
    {
        if (isCompassOpened)
        {
            compassCap.transform.Rotate(rotationVector * Time.deltaTime);
            endTime = DateTime.Now;
            if ((endTime - startTime).TotalSeconds >= 1)
            {
                arrow.SetActive(true);
                isCompassOpened = false;
            }
        }
    }

    private void LateUpdate()
    {
        if (_started)
        {
            EnsureCorrectVisualizer();

            if (settingMenu.activeInHierarchy)
            {
                CheckMenuSettings();
            }
        }
    }

    // Shows the Setting menu
    public void ShowSetting(bool set)
    {
        settingMenu.SetActive(set);
        openSettingButton.SetActive(!set);
        openHologramButton.SetActive(!set);
        openBookButton.SetActive(!set);

        if (settingMenu.activeInHierarchy)
        {
            // Deactivates star scripts, when the menu is active
            EnableStars(false, true, false);
            EnableMoonAndSun(false);
        }
        else
        {
            // Activates star scripts, when the menu is inactive
            EnableStars(true, false, true);
            EnableMoonAndSun(true);
        }
    }

    // Shows the Book menu
    public void ShowBook(bool set)
    {
        bookMenu.SetActive(set);
        openSettingButton.SetActive(!set);
        openHologramButton.SetActive(!set);
        openBookButton.SetActive(!set);

        if (bookMenu.activeInHierarchy)
        {
            // Deactivates star scripts, when the menu is active
            EnableStars(false, true, false);
            EnableMoonAndSun(false);
        }
        else
        {
            // Activates star scripts, when the menu is inactive
            EnableStars(true, false, true);
            EnableMoonAndSun(true);
        }
    }

    // Shows the Tutorial menu, deactivates stars and restarts the tutorial to first page
    public void ShowTutorial()
    {
        tutorialMenu.GetComponent<TutorialFlipPage>().RestartTutorial();
        openSettingButton.SetActive(false);
        openHologramButton.SetActive(false);
        openBookButton.SetActive(false);
        settingMenu.SetActive(false);
        tutorialMenu.SetActive(true);

        if (tutorialMenu.activeInHierarchy)
        {
            // Deactivates star scripts, when the menu is active
            EnableStars(false, true, false);
            EnableMoonAndSun(false);
        }
    }

    //Show the hologram menu
    public void ShowHologram(bool set)
    {
        openHologramButton.SetActive(!set);
        openSettingButton.SetActive(!set);
        openBookButton.SetActive(!set);
        compass.SetActive(set);
        compassCap.transform.localRotation = Quaternion.Euler(0, -180, 0);
        arrow.SetActive(false);
        if (compass.activeInHierarchy)
        {
            if (!isCompassOpened)
            {
                isCompassOpened = true;
                startTime = DateTime.Now;
                rotationVector = new Vector3(90, 0, 0);
                PlaySound();
            }
        }

        if (hologramMenu.GetComponent<Canvas>().enabled == false)
        {
            //activates the hologram, when the the button is pressed and the hologram was inactive at that time
            hologramMenu.GetComponent<Canvas>().enabled = true;
            Invoke(nameof(ActivateCloseButtonWithADelay), 0.6f);
            var scale = rtZodiac.sizeDelta;
            scale.x = 1920f;
            scale.y = 1357f;
            rtZodiac.sizeDelta = scale;

            //deactivate star scripts
            EnableStars(false, true, false);
            EnableMoonAndSun(false);
        }
        else if (hologramMenu.GetComponent<Canvas>().enabled == true)
        {
            //deactivate the holgram
            hologramMenu.GetComponent<Canvas>().enabled = false;
            closeButton.SetActive(false);
            zodiac.SetActive(true);
            var scale = rtZodiac.sizeDelta;
            scale.x = 0f;
            scale.y = 0f;
            rtZodiac.sizeDelta = scale;

            //activate star scripts
            EnableStars(true, false, true);
            EnableMoonAndSun(true);
        }
    }

    public void EnableMoonAndSun(bool status) 
    {
        sun.GetComponent<SphereCollider>().enabled = status;
        moon.GetComponent<SphereCollider>().enabled = status;
    }

    public void ActivateCloseButtonWithADelay()
    {
        closeButton.SetActive(true);
    }

    // Close the Tutorial, show Icons and activate star script after a delay
    public void CloseTutorial()
    {
        tutorialMenu.SetActive(false);
        
        if (!wasTutorialOpenedOnce)
        {
            Invoke(nameof(ActivateStarsAndButtonsWithDelay), 1.0f);
            wasTutorialOpenedOnce = true;
        }
        else
        {
            EnableStars(true, false, true);
            EnableMoonAndSun(true);
            openHologramButton.SetActive(true);
            openSettingButton.SetActive(true);
            openBookButton.SetActive(true);
        } 
    }

    public void ActivateStarsAndButtonsWithDelay()
    {
        moon.GetComponent<SphereCollider>().enabled = true;
        EnableStars(true, false, true);
        openHologramButton.SetActive(true);
        openSettingButton.SetActive(true);
        openBookButton.SetActive(true);
    }

    public void PlaySound()
    {
        if ((audioSource != null) && (openCompassSound != null))
        {
            audioSource.PlayOneShot(openCompassSound);
        }
    }

    public void PlayButtonIconSound()
    {
        if ((audioSource != null) && (buttonSound != null))
        {
            audioSource.PlayOneShot(buttonSound);
        }
    }

    public void OpenBook()
    {
        frontOfBook.GetComponent<OpenBook>().OpenBtn_Click();
    }

    public void CloseBook()
    {
        frontOfBook.GetComponent<OpenBook>().CloseBook_Click();
    }

    public void NextSite()
    {
        flipPage.GetComponent<FlipPage>().TurnPageNext();
    }

    public void PreviousSite()
    {
        flipPage.GetComponent<FlipPage>().TurnPagePrev();
    }

    public void TutorialNextSite()
    {
        tutorialMenu.GetComponent<TutorialFlipPage>().TutorialNextSite();
    }

    public void TutorialPreviousSite()
    {
        tutorialMenu.GetComponent<TutorialFlipPage>().TutorialPreviousSite();
    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void SetGazeModifierEnabled(bool set)
    {
        _gazeModifierFilter.enabled = set;
    }

    public void SetGazeVisualizerEnabled(bool set)
    {
        _gazeVisualizerEnabled = set;
    }

    private void EnsureCorrectVisualizer()
    {
        gazeVisualizerObject.SetActive(_gazeVisualizerEnabled);
    }

    public void SetG2OMDebugView(bool set)
    {
        _debugVisualization.SetVisualization(set);
    }

    // makes sure that the settings from the Tobii Settings Unity window matches the debug window's settings
    private void CheckMenuSettings()
    {
        if (_gazeVisualizerEnabled)
        {
            gazeVisualizerToggle.ToggleOn();
        }
        else
        {
            gazeVisualizerToggle.ToggleOff();
        }
    }

    //Enable or disable all interaction scripts on stars with lineRendererGaze and menuStatus
    private void EnableStars(bool starStatus, bool lineRendererStatus, bool checkerStatus)
    {
        foreach (GameObject star in starsCapricorn)
        {
            star.GetComponent<InteractionCapricorn>().enabled = starStatus;
            star.GetComponent<SphereCollider>().enabled = starStatus;

            if(lineRendererStatus)
            {
                lineRendererGaze.enabled = !lineRendererStatus;
            }
            if(checkerStatus && menuStatus != null)
            {
                menuStatus.SetActive(checkerStatus);
            }
        }
        foreach (GameObject star in starsAries)
        {
            star.GetComponent<InteractionAries>().enabled = starStatus;
            star.GetComponent<SphereCollider>().enabled = starStatus;

            if (lineRendererStatus)
            {
                lineRendererGaze.enabled = !lineRendererStatus;
            }
            if (checkerStatus && menuStatus != null)
            {
                menuStatus.SetActive(checkerStatus);
            }
        }
        foreach (GameObject star in starsCancer)
        {
            star.GetComponent<InteractionCancer>().enabled = starStatus;
            star.GetComponent<SphereCollider>().enabled = starStatus;

            if (lineRendererStatus)
            {
                lineRendererGaze.enabled = !lineRendererStatus;
            }
            if (checkerStatus && menuStatus != null)
            {
                menuStatus.SetActive(checkerStatus);
            }
        }
        foreach (GameObject star in starsLeo)
        {
            star.GetComponent<InteractionLeo>().enabled = starStatus;
            star.GetComponent<SphereCollider>().enabled = starStatus;

            if (lineRendererStatus)
            {
                lineRendererGaze.enabled = !lineRendererStatus;
            }
            if (checkerStatus && menuStatus != null)
            {
                menuStatus.SetActive(checkerStatus);
            }
        }
        foreach (GameObject star in starsLibra)
        {
            star.GetComponent<InteractionLibra>().enabled = starStatus;
            star.GetComponent<SphereCollider>().enabled = starStatus;

            if (lineRendererStatus)
            {
                lineRendererGaze.enabled = !lineRendererStatus;
            }
            if (checkerStatus && menuStatus != null)
            {
                menuStatus.SetActive(checkerStatus);
            }
        }
        foreach (GameObject star in starsPisces)
        {
            star.GetComponent<InteractionPisces>().enabled = starStatus;
            star.GetComponent<SphereCollider>().enabled = starStatus;

            if (lineRendererStatus)
            {
                lineRendererGaze.enabled = !lineRendererStatus;
            }
            if (checkerStatus && menuStatus != null)
            {
                menuStatus.SetActive(checkerStatus);
            }
        }
        foreach (GameObject star in starsAquarius)
        {
            star.GetComponent<InteractionAquarius>().enabled = starStatus;
            star.GetComponent<SphereCollider>().enabled = starStatus;

            if (lineRendererStatus)
            {
                lineRendererGaze.enabled = !lineRendererStatus;
            }
            if (checkerStatus && menuStatus != null)
            {
                menuStatus.SetActive(checkerStatus);
            }
        }
        foreach (GameObject star in starsVirgo)
        {
            star.GetComponent<InteractionVirgo>().enabled = starStatus;
            star.GetComponent<SphereCollider>().enabled = starStatus;

            if (lineRendererStatus)
            {
                lineRendererGaze.enabled = !lineRendererStatus;
            }
            if (checkerStatus && menuStatus != null)
            {
                menuStatus.SetActive(checkerStatus);
            }
        }
        foreach (GameObject star in starsTaurus)
        {
            star.GetComponent<InteractionTaurus>().enabled = starStatus;
            star.GetComponent<SphereCollider>().enabled = starStatus;

            if (lineRendererStatus)
            {
                lineRendererGaze.enabled = !lineRendererStatus;
            }
            if (checkerStatus && menuStatus != null)
            {
                menuStatus.SetActive(checkerStatus);
            }
        }
        foreach (GameObject star in starsGemini)
        {
            star.GetComponent<InteractionGemini>().enabled = starStatus;
            star.GetComponent<SphereCollider>().enabled = starStatus;

            if (lineRendererStatus)
            {
                lineRendererGaze.enabled = !lineRendererStatus;
            }
            if (checkerStatus && menuStatus != null)
            {
                menuStatus.SetActive(checkerStatus);
            }
        }
        foreach (GameObject star in starsScorpio)
        {
            star.GetComponent<InteractionScorpio>().enabled = starStatus;
            star.GetComponent<SphereCollider>().enabled = starStatus;

            if (lineRendererStatus)
            {
                lineRendererGaze.enabled = !lineRendererStatus;
            }
            if (checkerStatus && menuStatus != null)
            {
                menuStatus.SetActive(checkerStatus);
            }
        }
        foreach (GameObject star in starsSagittarius)
        {
            star.GetComponent<InteractionSagittarius>().enabled = starStatus;
            star.GetComponent<SphereCollider>().enabled = starStatus;

            if (lineRendererStatus)
            {
                lineRendererGaze.enabled = !lineRendererStatus;
            }
            if (checkerStatus && menuStatus != null)
            {
                menuStatus.SetActive(checkerStatus);
            }
        }
    }
}
