using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class OpenBook : MonoBehaviour
{
    [SerializeField] Button openBtn;
    [SerializeField] GameObject openedBook;
    [SerializeField] GameObject insideBackCover;
    [SerializeField] GameObject flipPage;
    [SerializeField] GameObject gazeUtilityMenu;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip openBookSound;
    private Vector3 rotationVector;
    private bool isOpenClicked;
    private bool isCloseClicked;
    private DateTime startTime;
    private DateTime endTime;

    void Start()
    {
        if (openBtn != null)
        {
            openBtn.onClick.AddListener(() => OpenBtn_Click());
        }
    }

    // When the book is openened, activate other gameobjects and deactivate book cover
    void Update()
    {
        if (isOpenClicked || isCloseClicked)
        {
            transform.Rotate(rotationVector * Time.deltaTime);
            endTime = DateTime.Now;

            if (isOpenClicked)
            {
                insideBackCover.SetActive(true);
                if ((endTime - startTime).TotalSeconds >= 1)
                {
                    isOpenClicked = false;
                    gameObject.SetActive(false);
                    insideBackCover.SetActive(false);
                    openedBook.SetActive(true);
                    flipPage.SetActive(true);

                    AppEvents.OpenBookFunction();
                }
            }

            if (isCloseClicked)
            {
                insideBackCover.SetActive(true);
                if ((endTime - startTime).TotalSeconds >= 1)
                {
                    gazeUtilityMenu.GetComponent<DevToolsMenuController>().ShowBook(false);
                    isCloseClicked = false;
                    insideBackCover.SetActive(false);
                }
            }
        }
    }

    // Opens the book, rotates the site and plays a sound
    public void OpenBtn_Click()
    {
        isOpenClicked = true;
        startTime = DateTime.Now;
        rotationVector = new Vector3(0, 180, 0);
        PlaySound();
    }

    // Deactivate/activate gameObjects when the book gets closed
    public void CloseBook_Click()
    {
        gameObject.SetActive(true);
        insideBackCover.SetActive(true);
        openedBook.SetActive(false);
        flipPage.SetActive(false);

        isCloseClicked = true;
        startTime = DateTime.Now;
        rotationVector = new Vector3(0, -180, 0);

        PlaySound();
    }

    // Plays a sound, when the book gets opened or closed
    public void PlaySound()
    {
        if ((audioSource != null) && (openBookSound != null))
        {
            audioSource.PlayOneShot(openBookSound);
        }
    }
}
