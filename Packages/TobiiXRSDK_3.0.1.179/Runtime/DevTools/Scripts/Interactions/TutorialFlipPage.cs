using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TutorialFlipPage : MonoBehaviour
{
    [SerializeField] Button prevBtn;
    [SerializeField] Button nextBtn;
    [SerializeField] GameObject page1;
    [SerializeField] GameObject page2;
    [SerializeField] GameObject page3;
    [SerializeField] GameObject page4;
    [SerializeField] GameObject page5;
    [SerializeField] GameObject page6;
    [SerializeField] GameObject page7;
    [SerializeField] GameObject page8;
    [SerializeField] GameObject page9;
    private int tutorialPageCount = 2;

    //Restart the tutorial and show first page
    public void RestartTutorial()
    {
        tutorialPageCount = 2;
        page2.SetActive(false);
        page3.SetActive(false);
        page4.SetActive(false);
        page5.SetActive(false);
        page6.SetActive(false);
        page7.SetActive(false);
        page8.SetActive(false);
        page9.SetActive(false);
        page1.SetActive(true);

        if (!nextBtn.gameObject.activeInHierarchy)
        {
            nextBtn.gameObject.SetActive(true);
        }
    }

    //Display the next site of the tutorial
    public void TutorialNextSite()
    {
        switch (tutorialPageCount)
        {
            case 2:
                page1.SetActive(false);
                page2.SetActive(true);
                break;
            case 3:
                page2.SetActive(false);
                page3.SetActive(true);
                break;
            case 4:
                page3.SetActive(false);
                page4.SetActive(true);
                break;
            case 5:
                page4.SetActive(false);
                page5.SetActive(true);
                break;
            case 6:
                page5.SetActive(false);
                page6.SetActive(true);
                break;
            case 7:
                page6.SetActive(false);
                page7.SetActive(true);
                break;
            case 8:
                page7.SetActive(false);
                page8.SetActive(true);
                break;
            case 9:
                page8.SetActive(false);
                page9.SetActive(true);
                nextBtn.gameObject.SetActive(false);
                break;
            default:
                break;
        }

        tutorialPageCount++;
    }

    //Display the previous site of the tutorial
    public void TutorialPreviousSite()
    {
        switch (tutorialPageCount)
        {
            case 2:
                tutorialPageCount++;
                break;
            case 3:
                page1.SetActive(true);
                page2.SetActive(false);
                break;
            case 4:
                page2.SetActive(true);
                page3.SetActive(false);
                break;
            case 5:
                page3.SetActive(true);
                page4.SetActive(false);
                break;
            case 6:
                page4.SetActive(true);
                page5.SetActive(false);
                break;
            case 7:
                page5.SetActive(true);
                page6.SetActive(false);
                break;
            case 8:
                page6.SetActive(true);
                page7.SetActive(false);
                break;
            case 9:
                page7.SetActive(true);
                page8.SetActive(false);
                break;
            case 10:
                page8.SetActive(true);
                page9.SetActive(false);
                if (!nextBtn.gameObject.activeInHierarchy)
                {
                    nextBtn.gameObject.SetActive(true);
                }
                break;
            default:
                break;
        }

        tutorialPageCount--;
    }
}
