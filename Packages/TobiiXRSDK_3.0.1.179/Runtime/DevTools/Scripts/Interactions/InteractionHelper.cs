using System;
using System.Collections;
using UnityEngine;

public static class InteractionHelper
{
    private static GameObject prevPrevStar = null;
    private static GameObject prevStar = null;
    private static GameObject presentStar = null;
    private static AudioSource audioSource;
    private static AudioClip fadeInSound;
    private static GameObject fadeInMusic;

    public static void ChangeStarSelection(GameObject star, Type type)
    {
        // If 3 Stars are selected 
        // Prevents jumping between two same stars
        if (prevStar != null && presentStar.name != star.name && prevStar.name != star.name)
        {
            prevPrevStar = prevStar;

            // Deselects PrevPrevStar to prevent three active stars at the same time
            DeSelectPrevprevStar(type);
        }
        // If 2 Stars are selected
        if (presentStar != null && presentStar.name != star.name)
        {
            prevStar = presentStar;            
        }
        // If 1 Star is selected        
        presentStar = star;        
    }

    public static void ResetPreviousStars()
    {
        prevStar = null;
        prevPrevStar = null;
    }

    //Set isFirst for current selected star to handle star lines
    public static void SetIsFirst(GameObject isFirstStar, Type type)
    {
        if (type == typeof(InteractionAries))
        {
            foreach (GameObject star in GameObject.FindGameObjectsWithTag("StarAries"))
            {
                star.GetComponent<InteractionAries>().isFirst = false;
                if (star.gameObject.name == isFirstStar.gameObject.name)
                {
                    star.GetComponent<InteractionAries>().isFirst = true;
                }
            }
        }
        if (type == typeof(InteractionCapricorn))
        {
            foreach (GameObject star in GameObject.FindGameObjectsWithTag("StarCapricorn"))
            {
                star.GetComponent<InteractionCapricorn>().isFirst = false;
                if (star.gameObject.name == isFirstStar.gameObject.name)
                {
                    star.GetComponent<InteractionCapricorn>().isFirst = true;
                }
            }
        }
        if (type == typeof(InteractionLeo))
        {
            foreach (GameObject star in GameObject.FindGameObjectsWithTag("StarLeo"))
            {
                star.GetComponent<InteractionLeo>().isFirst = false;
                if (star.gameObject.name == isFirstStar.gameObject.name)
                {
                    star.GetComponent<InteractionLeo>().isFirst = true;
                }
            }
        }
        if (type == typeof(InteractionLibra))
        {
            foreach (GameObject star in GameObject.FindGameObjectsWithTag("StarLibra"))
            {
                star.GetComponent<InteractionLibra>().isFirst = false;
                if (star.gameObject.name == isFirstStar.gameObject.name)
                {
                    star.GetComponent<InteractionLibra>().isFirst = true;
                }
            }
        }
        if (type == typeof(InteractionPisces))
        {
            foreach (GameObject star in GameObject.FindGameObjectsWithTag("StarPisces"))
            {
                star.GetComponent<InteractionPisces>().isFirst = false;
                if (star.gameObject.name == isFirstStar.gameObject.name)
                {
                    star.GetComponent<InteractionPisces>().isFirst = true;
                }
            }
        }
        if (type == typeof(InteractionCancer))
        {
            foreach (GameObject star in GameObject.FindGameObjectsWithTag("StarCancer"))
            {
                star.GetComponent<InteractionCancer>().isFirst = false;
                if (star.gameObject.name == isFirstStar.gameObject.name)
                {
                    star.GetComponent<InteractionCancer>().isFirst = true;
                }
            }
        }
        if (type == typeof(InteractionAquarius))
        {
            foreach (GameObject star in GameObject.FindGameObjectsWithTag("StarAquarius"))
            {
                star.GetComponent<InteractionAquarius>().isFirst = false;
                if (star.gameObject.name == isFirstStar.gameObject.name)
                {
                    star.GetComponent<InteractionAquarius>().isFirst = true;
                }
            }
        }
        if (type == typeof(InteractionVirgo))
        {
            foreach (GameObject star in GameObject.FindGameObjectsWithTag("StarVirgo"))
            {
                star.GetComponent<InteractionVirgo>().isFirst = false;
                if (star.gameObject.name == isFirstStar.gameObject.name)
                {
                    star.GetComponent<InteractionVirgo>().isFirst = true;
                }
            }
        }
        if (type == typeof(InteractionTaurus))
        {
            foreach (GameObject star in GameObject.FindGameObjectsWithTag("StarTaurus"))
            {
                star.GetComponent<InteractionTaurus>().isFirst = false;
                if (star.gameObject.name == isFirstStar.gameObject.name)
                {
                    star.GetComponent<InteractionTaurus>().isFirst = true;
                }
            }
        }
        if (type == typeof(InteractionGemini))
        {
            foreach (GameObject star in GameObject.FindGameObjectsWithTag("StarGemini"))
            {
                star.GetComponent<InteractionGemini>().isFirst = false;
                if (star.gameObject.name == isFirstStar.gameObject.name)
                {
                    star.GetComponent<InteractionGemini>().isFirst = true;
                }
            }
        }
        if (type == typeof(InteractionScorpio))
        {
            foreach (GameObject star in GameObject.FindGameObjectsWithTag("StarScorpio"))
            {
                star.GetComponent<InteractionScorpio>().isFirst = false;
                if (star.gameObject.name == isFirstStar.gameObject.name)
                {
                    star.GetComponent<InteractionScorpio>().isFirst = true;
                }
            }
        }
        if (type == typeof(InteractionSagittarius))
        {
            foreach (GameObject star in GameObject.FindGameObjectsWithTag("StarSagittarius"))
            {
                star.GetComponent<InteractionSagittarius>().isFirst = false;
                if (star.gameObject.name == isFirstStar.gameObject.name)
                {
                    star.GetComponent<InteractionSagittarius>().isFirst = true;
                }
            }
        }
    }

    //Set isLast for current selected star to handle gaze line renderer after looking at menu icons
    public static void SetIsLast(GameObject lastStar, Type type)
    {
        if (type == typeof(InteractionAries))
        {
            foreach (GameObject star in GameObject.FindGameObjectsWithTag("StarAries"))
            {
                star.GetComponent<InteractionAries>().isLastSelected = false;
                if (star.gameObject.name == lastStar.gameObject.name)
                {
                    star.GetComponent<InteractionAries>().isLastSelected = true;
                }
            }
        }
        if (type == typeof(InteractionCapricorn))
        {
            foreach (GameObject star in GameObject.FindGameObjectsWithTag("StarCapricorn"))
            {
                star.GetComponent<InteractionCapricorn>().isLastSelected = false;
                if (star.gameObject.name == lastStar.gameObject.name)
                {
                    star.GetComponent<InteractionCapricorn>().isLastSelected = true;
                }
            }
        }
        if (type == typeof(InteractionLeo))
        {
            foreach (GameObject star in GameObject.FindGameObjectsWithTag("StarLeo"))
            {
                star.GetComponent<InteractionLeo>().isLastSelected = false;
                if (star.gameObject.name == lastStar.gameObject.name)
                {
                    star.GetComponent<InteractionLeo>().isLastSelected = true;
                }
            }
        }
        if (type == typeof(InteractionLibra))
        {
            foreach (GameObject star in GameObject.FindGameObjectsWithTag("StarLibra"))
            {
                star.GetComponent<InteractionLibra>().isLastSelected = false;
                if (star.gameObject.name == lastStar.gameObject.name)
                {
                    star.GetComponent<InteractionLibra>().isLastSelected = true;
                }
            }
        }
        if (type == typeof(InteractionPisces))
        {
            foreach (GameObject star in GameObject.FindGameObjectsWithTag("StarPisces"))
            {
                star.GetComponent<InteractionPisces>().isLastSelected = false;
                if (star.gameObject.name == lastStar.gameObject.name)
                {
                    star.GetComponent<InteractionPisces>().isLastSelected = true;
                }
            }
        }
        if (type == typeof(InteractionCancer))
        {
            foreach (GameObject star in GameObject.FindGameObjectsWithTag("StarCancer"))
            {
                star.GetComponent<InteractionCancer>().isLastSelected = false;
                if (star.gameObject.name == lastStar.gameObject.name)
                {
                    star.GetComponent<InteractionCancer>().isLastSelected = true;
                }
            }
        }
        if (type == typeof(InteractionAquarius))
        {
            foreach (GameObject star in GameObject.FindGameObjectsWithTag("StarAquarius"))
            {
                star.GetComponent<InteractionAquarius>().isLastSelected = false;
                if (star.gameObject.name == lastStar.gameObject.name)
                {
                    star.GetComponent<InteractionAquarius>().isLastSelected = true;
                }
            }
        }
        if (type == typeof(InteractionVirgo))
        {
            foreach (GameObject star in GameObject.FindGameObjectsWithTag("StarVirgo"))
            {
                star.GetComponent<InteractionVirgo>().isLastSelected = false;
                if (star.gameObject.name == lastStar.gameObject.name)
                {
                    star.GetComponent<InteractionVirgo>().isLastSelected = true;
                }
            }
        }
        if (type == typeof(InteractionTaurus))
        {
            foreach (GameObject star in GameObject.FindGameObjectsWithTag("StarTaurus"))
            {
                star.GetComponent<InteractionTaurus>().isLastSelected = false;
                if (star.gameObject.name == lastStar.gameObject.name)
                {
                    star.GetComponent<InteractionTaurus>().isLastSelected = true;
                }
            }
        }
        if (type == typeof(InteractionGemini))
        {
            foreach (GameObject star in GameObject.FindGameObjectsWithTag("StarGemini"))
            {
                star.GetComponent<InteractionGemini>().isLastSelected = false;
                if (star.gameObject.name == lastStar.gameObject.name)
                {
                    star.GetComponent<InteractionGemini>().isLastSelected = true;
                }
            }
        }
        if (type == typeof(InteractionScorpio))
        {
            foreach (GameObject star in GameObject.FindGameObjectsWithTag("StarScorpio"))
            {
                star.GetComponent<InteractionScorpio>().isLastSelected = false;
                if (star.gameObject.name == lastStar.gameObject.name)
                {
                    star.GetComponent<InteractionScorpio>().isLastSelected = true;
                }
            }
        }
        if (type == typeof(InteractionSagittarius))
        {
            foreach (GameObject star in GameObject.FindGameObjectsWithTag("StarSagittarius"))
            {
                star.GetComponent<InteractionSagittarius>().isLastSelected = false;
                if (star.gameObject.name == lastStar.gameObject.name)
                {
                    star.GetComponent<InteractionSagittarius>().isLastSelected = true;
                }
            }
        }
    }

    // Fades the zodiac slowly in when the stars align
    public static IEnumerator FadeInZodiac(GameObject zodiacBackground)
    {
        Color tmp = zodiacBackground.GetComponent<SpriteRenderer>().color;
        tmp.a = 0f;
        zodiacBackground.GetComponent<SpriteRenderer>().color = tmp;
        float _progress = 0.0f;

        while (_progress < 1)
        {
            Color _tmpColor = zodiacBackground.GetComponent<SpriteRenderer>().color;
            zodiacBackground.GetComponent<SpriteRenderer>().color = new Color(_tmpColor.r, _tmpColor.g, _tmpColor.b, Mathf.Lerp(tmp.a, 255, _progress));
            _progress += Time.deltaTime * 0.0005f; // fadein speed
            yield return null;
        }        
    }

    public static void ShowFinishedZodiac(GameObject zodiacBackground)
    {
        Color tmp = zodiacBackground.GetComponent<SpriteRenderer>().color;
        tmp.a = 0f;
        zodiacBackground.GetComponent<SpriteRenderer>().color = tmp;

        Color _tmpColor = zodiacBackground.GetComponent<SpriteRenderer>().color;
        zodiacBackground.GetComponent<SpriteRenderer>().color = new Color(_tmpColor.r, _tmpColor.g, _tmpColor.b, Mathf.Lerp(tmp.a, 255, 1)); //startAlpha = 0 <-- value is in tmp.a        
    }

    public static void PlayFadeInSound()
    {
        fadeInMusic = GameObject.Find("FadeInMusic");
        audioSource = fadeInMusic.GetComponent<AudioSource>();
        fadeInSound = Resources.Load<AudioClip>("Audio/magic-chime-05");

        if ((audioSource != null) && (fadeInSound != null))
        {
            audioSource.PlayOneShot(fadeInSound);
        }
    }

    //Active or deactive interaction script components and collider for stars
    public static void ChangeScriptComponentStatus(bool status, Type type)
    {
        if (type != typeof(InteractionAries))
        {
            foreach (GameObject star in GameObject.FindGameObjectsWithTag("StarAries"))
            {
                star.GetComponent<InteractionAries>().enabled = status;
                star.GetComponent<SphereCollider>().enabled = status;
            }
        }
        if (type != typeof(InteractionCapricorn))
        {
            foreach (GameObject star in GameObject.FindGameObjectsWithTag("StarCapricorn"))
            {
                star.GetComponent<InteractionCapricorn>().enabled = status;
                star.GetComponent<SphereCollider>().enabled = status;
            }
        }
        if (type != typeof(InteractionLeo))
        {
            foreach (GameObject star in GameObject.FindGameObjectsWithTag("StarLeo"))
            {
                star.GetComponent<InteractionLeo>().enabled = status;
                star.GetComponent<SphereCollider>().enabled = status;
            }
        }
        if (type != typeof(InteractionLibra))
        {
            foreach (GameObject star in GameObject.FindGameObjectsWithTag("StarLibra"))
            {
                star.GetComponent<InteractionLibra>().enabled = status;
                star.GetComponent<SphereCollider>().enabled = status;
            }
        }
        if (type != typeof(InteractionPisces))
        {
            foreach (GameObject star in GameObject.FindGameObjectsWithTag("StarPisces"))
            {
                star.GetComponent<InteractionPisces>().enabled = status;
                star.GetComponent<SphereCollider>().enabled = status;
            }
        }
        if (type != typeof(InteractionCancer))
        {
            foreach (GameObject star in GameObject.FindGameObjectsWithTag("StarCancer"))
            {
                star.GetComponent<InteractionCancer>().enabled = status;
                star.GetComponent<SphereCollider>().enabled = status;
            }
        }
        if (type != typeof(InteractionAquarius))
        {
            foreach (GameObject star in GameObject.FindGameObjectsWithTag("StarAquarius"))
            {
                star.GetComponent<InteractionAquarius>().enabled = status;
                star.GetComponent<SphereCollider>().enabled = status;
            }
        }
        if (type != typeof(InteractionVirgo))
        {
            foreach (GameObject star in GameObject.FindGameObjectsWithTag("StarVirgo"))
            {
                star.GetComponent<InteractionVirgo>().enabled = status;
                star.GetComponent<SphereCollider>().enabled = status;
            }
        }
        if (type != typeof(InteractionTaurus))
        {
            foreach (GameObject star in GameObject.FindGameObjectsWithTag("StarTaurus"))
            {
                star.GetComponent<InteractionTaurus>().enabled = status;
                star.GetComponent<SphereCollider>().enabled = status;
            }
        }
        if (type != typeof(InteractionGemini))
        {
            foreach (GameObject star in GameObject.FindGameObjectsWithTag("StarGemini"))
            {
                star.GetComponent<InteractionGemini>().enabled = status;
                star.GetComponent<SphereCollider>().enabled = status;
            }
        }
        if (type != typeof(InteractionScorpio))
        {
            foreach (GameObject star in GameObject.FindGameObjectsWithTag("StarScorpio"))
            {
                star.GetComponent<InteractionScorpio>().enabled = status;
                star.GetComponent<SphereCollider>().enabled = status;
            }
        }
        if (type != typeof(InteractionSagittarius))
        {
            foreach (GameObject star in GameObject.FindGameObjectsWithTag("StarSagittarius"))
            {
                star.GetComponent<InteractionSagittarius>().enabled = status;
                star.GetComponent<SphereCollider>().enabled = status;
            }
        }
    }

    //Deselects PrevPrevStar to prevent three active stars at the same time
    private static void DeSelectPrevprevStar(Type type)
    {
        if (type == typeof(InteractionCancer) && prevPrevStar.CompareTag("StarCancer"))
        {
            prevPrevStar.GetComponent<InteractionCancer>().isSelected = false;
        }
        if (type == typeof(InteractionAries) && prevPrevStar.CompareTag("StarAries"))
        {
            prevPrevStar.GetComponent<InteractionAries>().isSelected = false;
        }
        if (type == typeof(InteractionCapricorn) && prevPrevStar.CompareTag("StarCapricorn"))
        {
            prevPrevStar.GetComponent<InteractionCapricorn>().isSelected = false;
        }
        if (type == typeof(InteractionLeo) && prevPrevStar.CompareTag("StarLeo"))
        {
            prevPrevStar.GetComponent<InteractionLeo>().isSelected = false;
        }
        if (type == typeof(InteractionLibra) && prevPrevStar.CompareTag("StarLibra"))
        {
            prevPrevStar.GetComponent<InteractionLibra>().isSelected = false;
        }
        if (type == typeof(InteractionPisces) && prevPrevStar.CompareTag("StarPisces"))
        {
            prevPrevStar.GetComponent<InteractionPisces>().isSelected = false;
        }
        if (type == typeof(InteractionAquarius) && prevPrevStar.CompareTag("StarAquarius"))
        {
            prevPrevStar.GetComponent<InteractionAquarius>().isSelected = false;
        }
        if (type == typeof(InteractionVirgo) && prevPrevStar.CompareTag("StarVirgo"))
        {
            prevPrevStar.GetComponent<InteractionVirgo>().isSelected = false;
        }
        if (type == typeof(InteractionTaurus) && prevPrevStar.CompareTag("StarTaurus"))
        {
            prevPrevStar.GetComponent<InteractionTaurus>().isSelected = false;
        }
        if (type == typeof(InteractionGemini) && prevPrevStar.CompareTag("StarGemini"))
        {
            prevPrevStar.GetComponent<InteractionGemini>().isSelected = false;
        }
        if (type == typeof(InteractionScorpio) && prevPrevStar.CompareTag("StarScorpio"))
        {
            prevPrevStar.GetComponent<InteractionScorpio>().isSelected = false;
        }
        if (type == typeof(InteractionSagittarius) && prevPrevStar.CompareTag("StarSagittarius"))
        {
            prevPrevStar.GetComponent<InteractionSagittarius>().isSelected = false;
        }
    }

    public static void SetLineRendererStarPosition(ref LineRenderer currentLineRenderer, GameObject firstStar, GameObject secondStar)
    {        
        currentLineRenderer.SetPosition(0, firstStar.transform.position);
        currentLineRenderer.SetPosition(1, secondStar.transform.position);
        currentLineRenderer.enabled = false;
    }

    //Draw line with lineRenderer between two stars
    public static void HandleStarLines(ref GameObject currentStar, ref GameObject firstStar, ref GameObject secondStar, ref LineRenderer currentLineRenderer, Type type)
    {
        if (type == typeof(InteractionCancer))
        {
            if (firstStar.GetComponent<InteractionCancer>().isSelected &&
               secondStar.GetComponent<InteractionCancer>().isSelected)
            {
                currentLineRenderer.SetPosition(0, firstStar.transform.position);
                currentLineRenderer.SetPosition(1, secondStar.transform.position);
                currentLineRenderer.enabled = true;

                if (firstStar.GetComponent<InteractionCancer>().isFirst)
                {
                    firstStar.GetComponent<InteractionCancer>().isSelected = false;
                    currentStar = secondStar;
                    ResetPreviousStars();
                }
                if (secondStar.GetComponent<InteractionCancer>().isFirst)
                {
                    secondStar.GetComponent<InteractionCancer>().isSelected = false;
                    currentStar = firstStar;
                    ResetPreviousStars();
                }
            }
        }
        if (type == typeof(InteractionPisces))
        {
            if (firstStar.GetComponent<InteractionPisces>().isSelected &&
               secondStar.GetComponent<InteractionPisces>().isSelected)
            {
                currentLineRenderer.SetPosition(0, firstStar.transform.position);
                currentLineRenderer.SetPosition(1, secondStar.transform.position);
                currentLineRenderer.enabled = true;

                if (firstStar.GetComponent<InteractionPisces>().isFirst)
                {
                    firstStar.GetComponent<InteractionPisces>().isSelected = false;
                    currentStar = secondStar;
                    ResetPreviousStars();
                }
                if (secondStar.GetComponent<InteractionPisces>().isFirst)
                {
                    secondStar.GetComponent<InteractionPisces>().isSelected = false;
                    currentStar = firstStar;
                    ResetPreviousStars();
                }
            }
        }
        if (type == typeof(InteractionLibra))
        {
            if (firstStar.GetComponent<InteractionLibra>().isSelected &&
               secondStar.GetComponent<InteractionLibra>().isSelected)
            {
                currentLineRenderer.SetPosition(0, firstStar.transform.position);
                currentLineRenderer.SetPosition(1, secondStar.transform.position);
                currentLineRenderer.enabled = true;

                if (firstStar.GetComponent<InteractionLibra>().isFirst)
                {
                    firstStar.GetComponent<InteractionLibra>().isSelected = false;
                    currentStar = secondStar;
                    ResetPreviousStars();
                }
                if (secondStar.GetComponent<InteractionLibra>().isFirst)
                {
                    secondStar.GetComponent<InteractionLibra>().isSelected = false;
                    currentStar = firstStar;
                    ResetPreviousStars();
                }
            }
        }
        if (type == typeof(InteractionCapricorn))
        {
            if (firstStar.GetComponent<InteractionCapricorn>().isSelected &&
               secondStar.GetComponent<InteractionCapricorn>().isSelected)
            {
                currentLineRenderer.SetPosition(0, firstStar.transform.position);
                currentLineRenderer.SetPosition(1, secondStar.transform.position);
                currentLineRenderer.enabled = true;

                if (firstStar.GetComponent<InteractionCapricorn>().isFirst)
                {
                    firstStar.GetComponent<InteractionCapricorn>().isSelected = false;
                    currentStar = secondStar;
                    ResetPreviousStars();
                }
                if (secondStar.GetComponent<InteractionCapricorn>().isFirst)
                {
                    secondStar.GetComponent<InteractionCapricorn>().isSelected = false;
                    currentStar = firstStar;
                    ResetPreviousStars();
                }
            }
        }
        if (type == typeof(InteractionLeo))
        {
            if (firstStar.GetComponent<InteractionLeo>().isSelected &&
               secondStar.GetComponent<InteractionLeo>().isSelected)
            {
                currentLineRenderer.SetPosition(0, firstStar.transform.position);
                currentLineRenderer.SetPosition(1, secondStar.transform.position);
                currentLineRenderer.enabled = true;

                if (firstStar.GetComponent<InteractionLeo>().isFirst)
                {
                    firstStar.GetComponent<InteractionLeo>().isSelected = false;
                    currentStar = secondStar;
                    ResetPreviousStars();
                }
                if (secondStar.GetComponent<InteractionLeo>().isFirst)
                {
                    secondStar.GetComponent<InteractionLeo>().isSelected = false;
                    currentStar = firstStar;
                    ResetPreviousStars();
                }
            }
        }
        if (type == typeof(InteractionAries))
        {
            if (firstStar.GetComponent<InteractionAries>().isSelected &&
               secondStar.GetComponent<InteractionAries>().isSelected)
            {
                currentLineRenderer.SetPosition(0, firstStar.transform.position);
                currentLineRenderer.SetPosition(1, secondStar.transform.position);
                currentLineRenderer.enabled = true;

                if (firstStar.GetComponent<InteractionAries>().isFirst)
                {
                    firstStar.GetComponent<InteractionAries>().isSelected = false;
                    currentStar = secondStar;
                    ResetPreviousStars();
                }
                if (secondStar.GetComponent<InteractionAries>().isFirst)
                {
                    secondStar.GetComponent<InteractionAries>().isSelected = false;
                    currentStar = firstStar;
                    ResetPreviousStars();
                }
            }
        }
        if (type == typeof(InteractionAquarius))
        {
            if (firstStar.GetComponent<InteractionAquarius>().isSelected &&
               secondStar.GetComponent<InteractionAquarius>().isSelected)
            {
                currentLineRenderer.SetPosition(0, firstStar.transform.position);
                currentLineRenderer.SetPosition(1, secondStar.transform.position);
                currentLineRenderer.enabled = true;

                if (firstStar.GetComponent<InteractionAquarius>().isFirst)
                {
                    firstStar.GetComponent<InteractionAquarius>().isSelected = false;
                    currentStar = secondStar;
                    ResetPreviousStars();
                }
                if (secondStar.GetComponent<InteractionAquarius>().isFirst)
                {
                    secondStar.GetComponent<InteractionAquarius>().isSelected = false;
                    currentStar = firstStar;
                    ResetPreviousStars();
                }
            }
        }
        if (type == typeof(InteractionVirgo))
        {
            if (firstStar.GetComponent<InteractionVirgo>().isSelected &&
               secondStar.GetComponent<InteractionVirgo>().isSelected)
            {
                currentLineRenderer.SetPosition(0, firstStar.transform.position);
                currentLineRenderer.SetPosition(1, secondStar.transform.position);
                currentLineRenderer.enabled = true;

                if (firstStar.GetComponent<InteractionVirgo>().isFirst)
                {
                    firstStar.GetComponent<InteractionVirgo>().isSelected = false;
                    currentStar = secondStar;
                    ResetPreviousStars();
                }
                if (secondStar.GetComponent<InteractionVirgo>().isFirst)
                {
                    secondStar.GetComponent<InteractionVirgo>().isSelected = false;
                    currentStar = firstStar;
                    ResetPreviousStars();
                }
            }
        }
        if (type == typeof(InteractionTaurus))
        {
            if (firstStar.GetComponent<InteractionTaurus>().isSelected &&
               secondStar.GetComponent<InteractionTaurus>().isSelected)
            {
                currentLineRenderer.SetPosition(0, firstStar.transform.position);
                currentLineRenderer.SetPosition(1, secondStar.transform.position);
                currentLineRenderer.enabled = true;

                if (firstStar.GetComponent<InteractionTaurus>().isFirst)
                {
                    firstStar.GetComponent<InteractionTaurus>().isSelected = false;
                    currentStar = secondStar;
                    ResetPreviousStars();
                }
                if (secondStar.GetComponent<InteractionTaurus>().isFirst)
                {
                    secondStar.GetComponent<InteractionTaurus>().isSelected = false;
                    currentStar = firstStar;
                    ResetPreviousStars();
                }
            }
        }
        if (type == typeof(InteractionGemini))
        {
            if (firstStar.GetComponent<InteractionGemini>().isSelected &&
               secondStar.GetComponent<InteractionGemini>().isSelected)
            {
                currentLineRenderer.SetPosition(0, firstStar.transform.position);
                currentLineRenderer.SetPosition(1, secondStar.transform.position);
                currentLineRenderer.enabled = true;

                if (firstStar.GetComponent<InteractionGemini>().isFirst)
                {
                    firstStar.GetComponent<InteractionGemini>().isSelected = false;
                    currentStar = secondStar;
                    ResetPreviousStars();
                }
                if (secondStar.GetComponent<InteractionGemini>().isFirst)
                {
                    secondStar.GetComponent<InteractionGemini>().isSelected = false;
                    currentStar = firstStar;
                    ResetPreviousStars();
                }
            }
        }
        if (type == typeof(InteractionScorpio))
        {
            if (firstStar.GetComponent<InteractionScorpio>().isSelected &&
               secondStar.GetComponent<InteractionScorpio>().isSelected)
            {
                currentLineRenderer.SetPosition(0, firstStar.transform.position);
                currentLineRenderer.SetPosition(1, secondStar.transform.position);
                currentLineRenderer.enabled = true;

                if (firstStar.GetComponent<InteractionScorpio>().isFirst)
                {
                    firstStar.GetComponent<InteractionScorpio>().isSelected = false;
                    currentStar = secondStar;
                    ResetPreviousStars();
                }
                if (secondStar.GetComponent<InteractionScorpio>().isFirst)
                {
                    secondStar.GetComponent<InteractionScorpio>().isSelected = false;
                    currentStar = firstStar;
                    ResetPreviousStars();
                }
            }
        }
        if (type == typeof(InteractionSagittarius))
        {
            if (firstStar.GetComponent<InteractionSagittarius>().isSelected &&
               secondStar.GetComponent<InteractionSagittarius>().isSelected)
            {
                currentLineRenderer.SetPosition(0, firstStar.transform.position);
                currentLineRenderer.SetPosition(1, secondStar.transform.position);
                currentLineRenderer.enabled = true;

                if (firstStar.GetComponent<InteractionSagittarius>().isFirst)
                {
                    firstStar.GetComponent<InteractionSagittarius>().isSelected = false;
                    currentStar = secondStar;
                    ResetPreviousStars();
                }
                if (secondStar.GetComponent<InteractionSagittarius>().isFirst)
                {
                    secondStar.GetComponent<InteractionSagittarius>().isSelected = false;
                    currentStar = firstStar;
                    ResetPreviousStars();
                }
            }
        }
    }

    public static void SetLineRendererGazePosition(ref LineRenderer lineRendererGaze, GameObject currentStar, GameObject gazeVisualizer)
    {
        lineRendererGaze.SetPosition(0, currentStar.transform.position);
        lineRendererGaze.SetPosition(1, gazeVisualizer.transform.position);
        lineRendererGaze.enabled = true;
    }

    //Disable gaze line renderer when looking at menu
    public static void DrawGazeLineAtMenu(ref LineRenderer lineRendererGaze, GameObject menuStatus, GameObject currentStar, GameObject gazeVisualizer)
    {
        if (!menuStatus.activeInHierarchy && lineRendererGaze.enabled == true)
        {
            lineRendererGaze.enabled = false;
        }
        else if (menuStatus.activeInHierarchy && currentStar != null)
        {
            lineRendererGaze.SetPosition(0, currentStar.transform.position);
            lineRendererGaze.SetPosition(1, gazeVisualizer.transform.position);
            lineRendererGaze.enabled = true;
        }
    }
}