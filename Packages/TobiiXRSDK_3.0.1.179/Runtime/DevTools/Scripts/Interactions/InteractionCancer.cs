using UnityEngine;
using Tobii.G2OM;
using System.Collections.Generic;
using System;

public class InteractionCancer : MonoBehaviour, IGazeFocusable, IZodiac
{
    private Renderer cancerRenderer;
    private GameObject[] stars = new GameObject[5];
    private GameObject currentStar = null;
    private GameObject menuStatus;
    public GameObject zodiacBackground;
    private GameObject gazeVisualizer;
    public GameObject flipPage;
    private LineRenderer lineRendererGaze;
    public GameObject line_1_2;
    public GameObject line_2_3;
    public GameObject line_3_4;
    public GameObject line_3_5;
    private LineRenderer lineRenderer_1_2;
    private LineRenderer lineRenderer_2_3;
    private LineRenderer lineRenderer_3_4;
    private LineRenderer lineRenderer_3_5;
    public bool isSelected = false;
    public bool isFirst = false;
    public bool isFinished = false;
    public bool isLastSelected = false;

    void Start()
    {
        InitGameObjects();
        InitRenderers();
        InitLineRendererStarPosition();
    }

    public void InitGameObjects()
    {
        for (int i = 1; i <= 5; i++)
        {
            stars[i - 1] = GameObject.Find($"StarBoundMesh/Cancer/Star{i}");
        }
        menuStatus = GameObject.Find("MenuStatus");
        gazeVisualizer = GameObject.Find("GazeUtilityMenu/Offset/GazeVisualizer");
    }

    public void InitRenderers()
    {
        cancerRenderer = GetComponent<Renderer>();
        lineRendererGaze = gazeVisualizer.GetComponent<LineRenderer>();
        lineRendererGaze.enabled = false;
        lineRenderer_1_2 = line_1_2.GetComponent<LineRenderer>();
        lineRenderer_2_3 = line_2_3.GetComponent<LineRenderer>();
        lineRenderer_3_4 = line_3_4.GetComponent<LineRenderer>();
        lineRenderer_3_5 = line_3_5.GetComponent<LineRenderer>();
    }

    public void InitLineRendererStarPosition()
    {
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_1_2, stars[0], stars[1]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_2_3, stars[1], stars[2]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_3_4, stars[2], stars[3]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_3_5, stars[2], stars[4]);
    }

    public void GazeFocusChanged(bool hasFocus)
    {
        if (hasFocus && gameObject.name == "Star1" && !isFinished)
        {
            stars[0].GetComponent<InteractionCancer>().isSelected = true;
            cancerRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionCancer));
            InteractionHelper.SetIsLast(stars[0], typeof(InteractionCancer));
        }
        if (hasFocus && gameObject.name == "Star2" && !isFinished)
        {
            stars[1].GetComponent<InteractionCancer>().isSelected = true;
            cancerRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionCancer));
            InteractionHelper.SetIsLast(stars[1], typeof(InteractionCancer));
        }
        if (hasFocus && gameObject.name == "Star3" && !isFinished)
        {
            stars[2].GetComponent<InteractionCancer>().isSelected = true;
            cancerRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionCancer));
            InteractionHelper.SetIsLast(stars[2], typeof(InteractionCancer));
        }
        if (hasFocus && gameObject.name == "Star4" && !isFinished)
        {
            stars[3].GetComponent<InteractionCancer>().isSelected = true;
            cancerRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionCancer));
            InteractionHelper.SetIsLast(stars[3], typeof(InteractionCancer));
        }
        if (hasFocus && gameObject.name == "Star5" && !isFinished)
        {
            stars[4].GetComponent<InteractionCancer>().isSelected = true;
            cancerRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionCancer));
            InteractionHelper.SetIsLast(stars[4], typeof(InteractionCancer));
        }
    }

    void Update()
    {
        if (!isFinished)
        {
            DrawStarLine();
            DrawGazeLine();
            DrawGazeLineAtMenu();
        }
    }

    public void DrawStarLine()
    {
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[0], ref stars[1], ref lineRenderer_1_2, typeof(InteractionCancer));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[1], ref stars[2], ref lineRenderer_2_3, typeof(InteractionCancer));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[2], ref stars[3], ref lineRenderer_3_4, typeof(InteractionCancer));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[2], ref stars[4], ref lineRenderer_3_5, typeof(InteractionCancer));
    }

    public void DrawGazeLine()
    {
        foreach (GameObject star in stars)
        {
            if (star.GetComponent<InteractionCancer>().isLastSelected)
            {
                InteractionHelper.SetLineRendererGazePosition(ref lineRendererGaze, star, gazeVisualizer);
                InteractionHelper.SetIsFirst(star, typeof(InteractionCancer));

                if (!isFinished)
                {
                    InteractionHelper.ChangeScriptComponentStatus(false, typeof(InteractionCancer));
                }
            }
        }

        ZodiacCompleted();
    }

    public void ZodiacCompleted()
    {
        if (lineRenderer_1_2.enabled &&
           lineRenderer_2_3.enabled &&
           lineRenderer_3_4.enabled &&
           lineRenderer_3_5.enabled)
        {
            lineRendererGaze.enabled = false;
            currentStar = null;

            foreach (GameObject star in stars)
            {
                cancerRenderer = star.GetComponent<Renderer>();
                cancerRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.green);
            }
            
            InteractionHelper.ChangeScriptComponentStatus(true, typeof(InteractionCancer));
            InteractionHelper.ResetPreviousStars();
            if (!isFinished)
            {
                flipPage.GetComponent<FlipPage>().ChangePageContent(false, typeof(InteractionCancer));
                InteractionHelper.PlayFadeInSound();
                StartCoroutine(InteractionHelper.FadeInZodiac(zodiacBackground));
                Invoke(nameof(UpdateColorAfterCoroutine), 10.0f);
            }
            isFinished = true;
        }
    }

    public void UpdateColorAfterCoroutine()
    {
        StopAllCoroutines();
        Color _tmpColor = zodiacBackground.GetComponent<SpriteRenderer>().color;
        zodiacBackground.GetComponent<SpriteRenderer>().color = new Color(_tmpColor.r, _tmpColor.g, _tmpColor.b, 255);
    }

    public void DrawGazeLineAtMenu()
    {
        InteractionHelper.DrawGazeLineAtMenu(ref lineRendererGaze, menuStatus, currentStar, gazeVisualizer);
    }
}