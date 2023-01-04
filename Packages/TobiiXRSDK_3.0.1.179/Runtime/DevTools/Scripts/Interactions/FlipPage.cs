using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class FlipPage : MonoBehaviour
{
    [SerializeField] Button prevBtn;
    [SerializeField] Button nextBtn;
    [SerializeField] Button closeBtn;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip flipPageSound;

    [SerializeField] Text headerText1_1;
    [SerializeField] Text headerText1_2;
    [SerializeField] Text headerText2_1;
    [SerializeField] Text headerText2_2;

    [SerializeField] Text bodyText1_1;
    [SerializeField] Text bodyText1_2;
    [SerializeField] Text bodyText2_1;
    [SerializeField] Text bodyText2_2;

    [SerializeField] Text footerText1_1;
    [SerializeField] Text footerText1_2;
    [SerializeField] Text footerText2_1;
    [SerializeField] Text footerText2_2;

    [SerializeField] GameObject capricorn;
    [SerializeField] GameObject aquarius;
    [SerializeField] GameObject pisces;
    [SerializeField] GameObject aries;
    [SerializeField] GameObject taurus;
    [SerializeField] GameObject gemini;
    [SerializeField] GameObject cancer;
    [SerializeField] GameObject leo;
    [SerializeField] GameObject virgo;
    [SerializeField] GameObject libra;
    [SerializeField] GameObject scorpio;
    [SerializeField] GameObject sagittarius;

    [SerializeField] GameObject capricornImage;
    [SerializeField] GameObject capricornImageTransparent;
    [SerializeField] GameObject capricornBodyText;
    [SerializeField] GameObject aquariusImage;
    [SerializeField] GameObject aquariusImageTransparent;
    [SerializeField] GameObject aquariusBodyText;
    [SerializeField] GameObject piscesImage;
    [SerializeField] GameObject piscesImageTransparent;
    [SerializeField] GameObject piscesBodyText;
    [SerializeField] GameObject ariesImage;
    [SerializeField] GameObject ariesImageTransparent;
    [SerializeField] GameObject ariesBodyText;
    [SerializeField] GameObject taurusImage;
    [SerializeField] GameObject taurusImageTransparent;
    [SerializeField] GameObject taurusBodyText;
    [SerializeField] GameObject geminiImage;
    [SerializeField] GameObject geminiImageTransparent;
    [SerializeField] GameObject geminiBodyText;
    [SerializeField] GameObject cancerImage;
    [SerializeField] GameObject cancerImageTransparent;
    [SerializeField] GameObject cancerBodyText;
    [SerializeField] GameObject leoImage;
    [SerializeField] GameObject leoImageTransparent;
    [SerializeField] GameObject leoBodyText;
    [SerializeField] GameObject virgoImage;
    [SerializeField] GameObject virgoImageTransparent;
    [SerializeField] GameObject virgoBodyText;
    [SerializeField] GameObject libraImage;
    [SerializeField] GameObject libraImageTransparent;
    [SerializeField] GameObject libraBodyText;
    [SerializeField] GameObject scorpioImage;
    [SerializeField] GameObject scorpioImageTransparent;
    [SerializeField] GameObject scorpioBodyText;
    [SerializeField] GameObject sagittariusImage;
    [SerializeField] GameObject sagittariusImageTransparent;
    [SerializeField] GameObject sagittariusBodyText;
    [SerializeField] GameObject openBook;
    [SerializeField] GameObject openBookPrev;

    [SerializeField] GameObject sun;

    private enum ButtonType
    {
        NextButton,
        PrevButton,
        CloseButton
    }

    private Vector3 rotationVector;
    private Vector3 startPosition;
    private Quaternion startRotation;
    private Vector3 rotationVectorPrev;
    private Vector3 startPositionPrev;
    private Quaternion startRotationPrev;

    private GameObject flipPage1;
    private GameObject flipPage2;
    private GameObject flipPage3;
    private GameObject flipPage4;
    private GameObject flipPagePrev;

    private bool isClickedNext;
    private bool isClickedPrev;
    private bool isPageDelayActivated = false;
    private bool capricornBool = false;
    private bool aquariusBool = false;
    private bool piscesBool = false;
    private bool ariesBool = false;
    private bool taurusBool = false;
    private bool geminiBool = false;
    private bool cancerBool = false;
    private bool leoBool = false;
    private bool virgoBool = false;
    private bool libraBool = false;
    private bool scorpioBool = false;
    private bool sagittariusBool = false;

    private DateTime startTime;
    private DateTime endTime;

    private int pageCount = 0;
    private int imageCount = 0;

    // Checks if any buttons are getting pressed
    private void Start()
    {
        flipPage1 = GameObject.Find("Book/FlipPage/FlipPage1");
        flipPage2 = GameObject.Find("Book/FlipPage/FlipPage2");
        flipPagePrev = GameObject.Find("Book/FlipPagePrev");
        flipPage3 = GameObject.Find("Book/FlipPagePrev/FlipPage3");
        flipPage4 = GameObject.Find("Book/FlipPagePrev/FlipPage4");
        flipPage1.SetActive(false);
        flipPage2.SetActive(false);
        flipPage3.SetActive(false);
        flipPage4.SetActive(false);
        startRotation = transform.rotation;
        startPosition = transform.position;
        startRotationPrev = flipPagePrev.transform.rotation;
        startPositionPrev = flipPagePrev.transform.position;
    }

    private void Awake()
    {        
        AppEvents.OpenBook += new EventHandler(OpenBookBtn_Click);
    }

    // If a button is clicked, rotates the site for a fixed amount of time
    private void Update()
    {
        if (isClickedNext)
        {
            transform.Rotate(rotationVector * Time.deltaTime);
            endTime = DateTime.Now;
            if ((endTime - startTime).TotalSeconds >= 1)
            {
                isClickedNext = false;
                transform.rotation = openBook.transform.rotation;
                transform.position = openBook.transform.position;
                flipPage1.SetActive(false);
                flipPage2.SetActive(false);
            }
        }

        if (isClickedPrev)
        {
            flipPagePrev.transform.Rotate(rotationVectorPrev * Time.deltaTime);
            endTime = DateTime.Now;
            if ((endTime - startTime).TotalSeconds >= 1)
            {
                isClickedPrev = false;
                flipPagePrev.transform.rotation = openBookPrev.transform.rotation;
                flipPagePrev.transform.position = openBookPrev.transform.position;
                flipPage3.SetActive(false);
                flipPage4.SetActive(false);
            }
        }
    }

    // Shows the site depending on pageCount
    private void OpenBookBtn_Click(object sender, EventArgs e)
    {
        switch (pageCount)
        {
            case 0:
                capricorn.SetActive(true);
                prevBtn.gameObject.SetActive(false);
                pageCount++;
                break;
            case 1:
                capricorn.SetActive(true);
                prevBtn.gameObject.SetActive(false);
                break;
            case 2:
                aquarius.SetActive(true);
                break;
            case 3:
                pisces.SetActive(true);
                break;
            case 4:
                aries.SetActive(true);
                break;
            case 5:
                taurus.SetActive(true);
                break;
            case 6:
                gemini.SetActive(true);
                break;
            case 7:
                cancer.SetActive(true);
                break;
            case 8:
                leo.SetActive(true);
                break;
            case 9:
                virgo.SetActive(true);
                break;
            case 10:
                libra.SetActive(true);
                break;
            case 11:
                scorpio.SetActive(true);
                break;
            case 12:
                sagittarius.SetActive(true);
                nextBtn.gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }

    //Show turn page animation for forwards
    public void TurnPageNext()
    {
        if (!isPageDelayActivated)
        {            
            isClickedNext = true;
            startTime = DateTime.Now;

            flipPage1.SetActive(true);
            flipPage2.SetActive(true);
            if (!prevBtn.gameObject.activeInHierarchy)
            {
                prevBtn.gameObject.SetActive(true);
            }
            rotationVector = new Vector3(0, 180, 0);

            PlaySound();
            Invoke(nameof(NextSite), 0.8f);
            isPageDelayActivated = true;
            Invoke(nameof(PageDelay), 1.2f);
        }
    }

    //Show turn page animation for backwards
    public void TurnPagePrev()
    {
        if (!isPageDelayActivated)
        {
            isClickedPrev = true;
            startTime = DateTime.Now;

            flipPage3.SetActive(true);
            flipPage4.SetActive(true);
            rotationVectorPrev = new Vector3(0, -180, 0);

            PlaySound();
            Invoke(nameof(PreviousSite), 1.0f);
            isPageDelayActivated = true;
            Invoke(nameof(PageDelay), 1.2f);
        }
    }

    // Closes the book with an animation
    private void CloseBookBtn_Click(ButtonType type)
    {
        AppEvents.CloseBookFunction();
        capricorn.SetActive(false);
        aquarius.SetActive(false);
        pisces.SetActive(false);
        aries.SetActive(false);
        taurus.SetActive(false);
        gemini.SetActive(false);
        cancer.SetActive(false);
        leo.SetActive(false);
        virgo.SetActive(false);
        libra.SetActive(false);
        scorpio.SetActive(false);
        sagittarius.SetActive(false);
    }

    // Plays the Sound when the book opens/closes/sites
    private void PlaySound()
    {
        if ((audioSource != null) && (flipPageSound != null))
        {
            audioSource.PlayOneShot(flipPageSound);
        }
    }

    // Displays the next Site of the book
    private void NextSite()
    {
        switch (pageCount)
        {
            case 1:
                capricorn.SetActive(false);
                aquarius.SetActive(true);
                break;
            case 2:
                aquarius.SetActive(false);
                pisces.SetActive(true);
                break;
            case 3:
                pisces.SetActive(false);
                aries.SetActive(true);
                break;
            case 4:
                aries.SetActive(false);
                taurus.SetActive(true);
                break;
            case 5:
                taurus.SetActive(false);
                gemini.SetActive(true);
                break;
            case 6:
                gemini.SetActive(false);
                cancer.SetActive(true);
                break;
            case 7:
                cancer.SetActive(false);
                leo.SetActive(true);
                break;
            case 8:
                leo.SetActive(false);
                virgo.SetActive(true);
                break;
            case 9:
                virgo.SetActive(false);
                libra.SetActive(true);
                break;
            case 10:
                libra.SetActive(false);
                scorpio.SetActive(true);
                break;
            case 11:
                scorpio.SetActive(false);
                sagittarius.SetActive(true);
                nextBtn.gameObject.SetActive(false);
                break;
            default:
                break;
        }

        pageCount++;
    }

    // Displays the previous site of the book
    private void PreviousSite()
    {
        switch (pageCount)
        {
            case 2:
                capricorn.SetActive(true);
                aquarius.SetActive(false);
                prevBtn.gameObject.SetActive(false);
                break;
            case 3:
                aquarius.SetActive(true);
                pisces.SetActive(false);
                break;
            case 4:
                pisces.SetActive(true);
                aries.SetActive(false);
                break;
            case 5:
                aries.SetActive(true);
                taurus.SetActive(false);
                break;
            case 6:
                taurus.SetActive(true);
                gemini.SetActive(false);
                break;
            case 7:
                gemini.SetActive(true);
                cancer.SetActive(false);
                break;
            case 8:
                cancer.SetActive(true);
                leo.SetActive(false);
                break;
            case 9:
                leo.SetActive(true);
                virgo.SetActive(false);
                break;
            case 10:
                virgo.SetActive(true);
                libra.SetActive(false);
                break;
            case 11:
                libra.SetActive(true);
                scorpio.SetActive(false);
                break;
            case 12:
                scorpio.SetActive(true);
                sagittarius.SetActive(false);
                if (!nextBtn.gameObject.activeInHierarchy)
                {
                    nextBtn.gameObject.SetActive(true);
                }
                break;
            default:
                break;
        }

        pageCount--;
    }

    // Delay when switching sites to prevent click-spamming
    private void PageDelay()
    {
        isPageDelayActivated = false;
    }

    // Deactivates the transparent image and activates the image and the text, when the corresponding zodiac is completed
    public void ChangePageContent(bool status, Type type)
    {
        if (type == typeof(InteractionAries))
        {
            ariesImageTransparent.SetActive(status);
            ariesImage.SetActive(!status);
            ariesBodyText.SetActive(!status);
            if (!ariesBool)
            {
                imageCount++;
                ariesBool = true;
            }
        }
        if (type == typeof(InteractionCapricorn))
        {
            capricornImageTransparent.SetActive(status);
            capricornImage.SetActive(!status);
            capricornBodyText.SetActive(!status);
            if (!capricornBool)
            {
                imageCount++;
                capricornBool = true;
            }
        }
        if (type == typeof(InteractionLeo))
        {
            leoImageTransparent.SetActive(status);
            leoImage.SetActive(!status);
            leoBodyText.SetActive(!status);
            if (!leoBool)
            {
                imageCount++;
                leoBool = true;
            }
        }
        if (type == typeof(InteractionLibra))
        {
            libraImageTransparent.SetActive(status);
            libraImage.SetActive(!status);
            libraBodyText.SetActive(!status);
            if (!libraBool)
            {
                imageCount++;
                libraBool = true;
            }
        }
        if (type == typeof(InteractionPisces))
        {
            piscesImageTransparent.SetActive(status);
            piscesImage.SetActive(!status);
            piscesBodyText.SetActive(!status);
            if (!piscesBool)
            {
                imageCount++;
                piscesBool = true;
            }

        }
        if (type == typeof(InteractionCancer))
        {
            cancerImageTransparent.SetActive(status);
            cancerImage.SetActive(!status);
            cancerBodyText.SetActive(!status);
            if (!cancerBool)
            {
                imageCount++;
                cancerBool = true;
            }

        }
        if (type == typeof(InteractionAquarius))
        {
            aquariusImageTransparent.SetActive(status);
            aquariusImage.SetActive(!status);
            aquariusBodyText.SetActive(!status);
            if (!aquariusBool)
            {
                imageCount++;
                aquariusBool = true;
            }
        }
        if (type == typeof(InteractionVirgo))
        {
            virgoImageTransparent.SetActive(status);
            virgoImage.SetActive(!status);
            virgoBodyText.SetActive(!status);
            if (!virgoBool)
            {
                imageCount++;
                virgoBool = true;
            }
        }
        if (type == typeof(InteractionTaurus))
        {
            taurusImageTransparent.SetActive(status);
            taurusImage.SetActive(!status);
            taurusBodyText.SetActive(!status);
            if (!taurusBool)
            {
                imageCount++;
                taurusBool = true;
            }
        }
        if (type == typeof(InteractionGemini))
        {
            geminiImageTransparent.SetActive(status);
            geminiImage.SetActive(!status);
            geminiBodyText.SetActive(!status);
            if (!geminiBool)
            {
                imageCount++;
                geminiBool = true;
            }
        }
        if (type == typeof(InteractionScorpio))
        {
            scorpioImageTransparent.SetActive(status);
            scorpioImage.SetActive(!status);
            scorpioBodyText.SetActive(!status);
            if (!scorpioBool)
            {
                imageCount++;
                scorpioBool = true;
            }
        }
        if (type == typeof(InteractionSagittarius))
        {
            sagittariusImageTransparent.SetActive(status);
            sagittariusImage.SetActive(!status);
            sagittariusBodyText.SetActive(!status);
            if (!sagittariusBool)
            {
                imageCount++;
                sagittariusBool = true;
            }
        }

        //Activate sun if all zodiac images found
        if (imageCount == 12)
        {
            sun.SetActive(true);
        }
    }
}
