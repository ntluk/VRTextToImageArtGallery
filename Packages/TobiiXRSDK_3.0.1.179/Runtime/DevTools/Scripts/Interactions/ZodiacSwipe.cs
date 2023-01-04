using System.Collections;
using Tobii.G2OM;
using Tobii.XR;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Switch between Zodiacs with the touchpad button on the Vive controller.
/// </summary>
public class ZodiacSwipe : MonoBehaviour, IGazeFocusable
{
    [Header("Functionality")]
    [SerializeField, Tooltip("The normalized (0 to 1) haptic strength for every step in the hologram.")]
    private float _hapticStrength = 0.1f;
    // The touchpad button on the Vive controller.
    private const ControllerButton TouchpadButton = ControllerButton.Touchpad;
    private GameObject hologramMenu;
    public GameObject arrow;
    public GameObject zodiac;
    public Transform[] centerPointArray;
    private Transform centerPoint;
    public GameObject capricornSound;
    public GameObject aquariusSound;
    public GameObject piscesSound;
    public GameObject ariesSound;
    public GameObject taurusSound;
    public GameObject geminiSound;
    public GameObject cancerSound;
    public GameObject leoSound;
    public GameObject virgoSound;
    public GameObject libraSound;
    public GameObject scorpioSound;
    public GameObject sagittariusSound;
    public GameObject backgroundSound;
    private Image zodiacImageCurrent;
    private int _imageCount = 1;
    private bool _hasFocus;    
    private bool isHologramActive = false;
    private bool isHologramInactive = true;
    private bool isHologramFirstActive = false;
    private bool isBlocked = false;
    private bool wasHologramInactiveRunOnce = false;
    private bool isSwipeDelayActivated = false;

    private void Start()
    {
        hologramMenu = GameObject.Find("GazeUtilityMenu/Offset/HologramMenu");
    }

    private void Update()
    {
        //Checks if the Zodiac is inactive/closed and the script was already run and checks if this got run once to prevent infinite update
        if (hologramMenu.GetComponent<Canvas>().enabled == false && !isHologramInactive && !wasHologramInactiveRunOnce)
        {
            StopCoroutine(nameof(HandleInputWithDelay));
            isHologramActive = false;
            DeactivateSounds();

            StopCoroutine(nameof(FadeOutBackgroundSound));
            StartCoroutine("FadeInBackgroundSound");
            wasHologramInactiveRunOnce = true;
        }
        //Checks if the Zodiac is reactivated
        else if (hologramMenu.GetComponent<Canvas>().enabled == true && !isHologramActive)
        {
            //Checks if the Zodiac is active at the beginning
            if (!isHologramFirstActive)
            {
                centerPoint = centerPointArray[_imageCount - 1];
                arrow.GetComponent<DirectionalArrow>().target = centerPoint;
                StopCoroutine(nameof(FadeInBackgroundSound));
                StartCoroutine("FadeOutBackgroundSound");
                PlaySoundWhenSwiped();
                isHologramActive = true;

                //Starts the swipe functionality with a little delay to avoid unintened swiping
                Invoke("SwipeZodiacWhenFirstActive", 0.5f);
            }
            else
            {
                StopCoroutine(nameof(FadeInBackgroundSound));
                StartCoroutine("FadeOutBackgroundSound");
                PlaySoundWhenSwiped();
                isHologramActive = true;

                //Starts the swipe functionality with a little delay to avoid unintened swiping
                Invoke("SwipeZodiacWhenActive",0.5f);
                wasHologramInactiveRunOnce = false;
            }
            isHologramFirstActive = true;
        }

        // If the zodiac is not being focused on by the user, return.
        if (!_hasFocus) return;
    }

    //Swiping isnt too fast
    IEnumerator HandleInputWithDelay()
    {
        for (; ; )
        {
            HandleInput();
            yield return new WaitForSeconds(0f);
        }
    }

    IEnumerator FadeOutBackgroundSound()
    {
        //fade audio out over 3 seconds
        float totalTime = 3; 
        float currentTime = 0;
        float currentAudioValue = backgroundSound.GetComponent<AudioSource>().volume;

        while (backgroundSound.GetComponent<AudioSource>().volume > 0)
        {
            currentTime += Time.deltaTime;
            backgroundSound.GetComponent<AudioSource>().volume = Mathf.Lerp(currentAudioValue, 0, currentTime / totalTime);
            yield return null;
        }

        StopCoroutine(nameof(FadeOutBackgroundSound));
    }

    IEnumerator FadeInBackgroundSound()
    {
        //fade audio out over 3 seconds
        float totalTime = 3; 
        float currentTime = 0;
        float currentAudioValue = backgroundSound.GetComponent<AudioSource>().volume;

        while (backgroundSound.GetComponent<AudioSource>().volume < 0.5f)
        {
            currentTime += Time.deltaTime;
            backgroundSound.GetComponent<AudioSource>().volume = Mathf.Lerp(currentAudioValue, 0.5f, currentTime / totalTime);
            yield return null;
        }

        StopCoroutine(nameof(FadeInBackgroundSound));
    }

    /// <summary>
    /// Handle the user input.
    /// </summary>
    private void HandleInput()
    {
        if (!isSwipeDelayActivated && !isBlocked)
        {
            // When the touchpad is being touched.
            if (ControllerManager.Instance.GetButtonTouch(TouchpadButton))
            {
                UpdateZodiac();
                isSwipeDelayActivated = true;
                Invoke(nameof(EnableZodiacSwipeScript), 0.4f);
            }
        }
    }

    /// <summary>
    /// Updates the different Zodiacs and swipes betweeen them.
    /// </summary>
    private void UpdateZodiac()
    {
        zodiacImageCurrent = GetComponent<Image>();
        var padXCurrentFrame = ControllerManager.Instance.GetTouchpadAxis().x;
        
        // when the swipe is right
        if (padXCurrentFrame > 0)
        {
            // if the end is reached jump back to the first zodiac
            if (_imageCount == 12)
            {
                _imageCount = 0;
            }
            
            //haptic feedback and the zodiac is updated
            ControllerManager.Instance.TriggerHapticPulse(_hapticStrength); 
            zodiacImageCurrent.sprite = Resources.Load<Sprite>($"Zodiacs/zodiac_{++_imageCount}");
            centerPoint = centerPointArray[_imageCount - 1];

            //Changes the direction of the arrow
            arrow.GetComponent<DirectionalArrow>().target = centerPoint; 
            PlaySoundWhenSwiped();
        }
        //when the swipe is left
        else
        {
            if (_imageCount == 1)
            {
                _imageCount = 13;
            }

            ControllerManager.Instance.TriggerHapticPulse(_hapticStrength);
            zodiacImageCurrent.sprite = Resources.Load<Sprite>($"Zodiacs/zodiac_{--_imageCount}");
            centerPoint = centerPointArray[_imageCount - 1];

            //Changes the direction of the arrow
            arrow.GetComponent<DirectionalArrow>().target = centerPoint;
            PlaySoundWhenSwiped();
        }
    }

    public void PlaySoundWhenSwiped()
    {
        switch (_imageCount)
        {
            case 1:
                sagittariusSound.GetComponent<AudioSource>().enabled = false;
                capricornSound.GetComponent<AudioSource>().enabled = true;
                aquariusSound.GetComponent<AudioSource>().enabled = false;
                break;
            case 2:
                capricornSound.GetComponent<AudioSource>().enabled = false;
                aquariusSound.GetComponent<AudioSource>().enabled = true;
                piscesSound.GetComponent<AudioSource>().enabled = false;
                break;
            case 3:
                aquariusSound.GetComponent<AudioSource>().enabled = false;
                piscesSound.GetComponent<AudioSource>().enabled = true;
                ariesSound.GetComponent<AudioSource>().enabled = false;
                break;
            case 4:
                piscesSound.GetComponent<AudioSource>().enabled = false;
                ariesSound.GetComponent<AudioSource>().enabled = true;
                taurusSound.GetComponent<AudioSource>().enabled = false;
                break;
            case 5:
                ariesSound.GetComponent<AudioSource>().enabled = false;
                taurusSound.GetComponent<AudioSource>().enabled = true;
                geminiSound.GetComponent<AudioSource>().enabled = false;
                break;
            case 6:
                taurusSound.GetComponent<AudioSource>().enabled = false;
                geminiSound.GetComponent<AudioSource>().enabled = true;
                cancerSound.GetComponent<AudioSource>().enabled = false;
                break;
            case 7:
                geminiSound.GetComponent<AudioSource>().enabled = false;
                cancerSound.GetComponent<AudioSource>().enabled = true;
                leoSound.GetComponent<AudioSource>().enabled = false;
                break;
            case 8:
                cancerSound.GetComponent<AudioSource>().enabled = false;
                leoSound.GetComponent<AudioSource>().enabled = true;
                virgoSound.GetComponent<AudioSource>().enabled = false;
                break;
            case 9:
                leoSound.GetComponent<AudioSource>().enabled = false;
                virgoSound.GetComponent<AudioSource>().enabled = true;
                libraSound.GetComponent<AudioSource>().enabled = false;
                break;
            case 10:
                virgoSound.GetComponent<AudioSource>().enabled = false;
                libraSound.GetComponent<AudioSource>().enabled = true;
                scorpioSound.GetComponent<AudioSource>().enabled = false;
                break;
            case 11:
                libraSound.GetComponent<AudioSource>().enabled = false;
                scorpioSound.GetComponent<AudioSource>().enabled = true;
                sagittariusSound.GetComponent<AudioSource>().enabled = false;
                break;
            case 12:
                scorpioSound.GetComponent<AudioSource>().enabled = false;
                sagittariusSound.GetComponent<AudioSource>().enabled = true;
                capricornSound.GetComponent<AudioSource>().enabled = false;
                break;
            default:
                break;
        }
    }

    public void DeactivateSounds()
    {
        capricornSound.GetComponent<AudioSource>().enabled = false;
        aquariusSound.GetComponent<AudioSource>().enabled = false;
        piscesSound.GetComponent<AudioSource>().enabled = false;
        ariesSound.GetComponent<AudioSource>().enabled = false;
        taurusSound.GetComponent<AudioSource>().enabled = false;
        geminiSound.GetComponent<AudioSource>().enabled = false;
        cancerSound.GetComponent<AudioSource>().enabled = false;
        leoSound.GetComponent<AudioSource>().enabled = false;
        virgoSound.GetComponent<AudioSource>().enabled = false;
        libraSound.GetComponent<AudioSource>().enabled = false;
        scorpioSound.GetComponent<AudioSource>().enabled = false;
        sagittariusSound.GetComponent<AudioSource>().enabled = false;
    }

    public void SwipeZodiacWhenActive()
    {
        //SetActive to avoid error (sometimes its inactiv because of gaze/eyetracking)
        zodiac.SetActive(true);
        StartCoroutine("HandleInputWithDelay");
        isHologramActive = true;
    }

    public void SwipeZodiacWhenFirstActive()
    {
        //SetActive to avoid error (sometimes its inactiv because of gaze/eyetracking)
        zodiac.SetActive(true);
        StartCoroutine("HandleInputWithDelay");
        centerPoint = centerPointArray[_imageCount - 1];
        arrow.GetComponent<DirectionalArrow>().target = centerPoint;
        isHologramActive = true;
    }

    public void GazeFocusChanged(bool hasFocus)
    {
        // Don't use this method if the component is disabled.
        if (!enabled) return;

        _hasFocus = hasFocus;
    }

    public void EnableZodiacSwipeScript()
    {
        isSwipeDelayActivated = false;
    }

    // Reference by close hologram button
    public void BlockSwipeInteraction(bool set)
    {
        isBlocked = set;
    }

    // Reference by close hologram button
    public void DeactivateHologram(bool set)
    {
        isHologramInactive = set;
    }
}