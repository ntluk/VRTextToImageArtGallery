using Tobii.G2OM;
using UnityEngine;

public class InteractionPisces : MonoBehaviour, IGazeFocusable, IZodiac
{
    private Renderer piscesRenderer;
    private GameObject[] stars = new GameObject[16];
    private GameObject currentStar = null;
    private GameObject menuStatus;
    public GameObject zodiacBackground;
    private GameObject gazeVisualizer;
    public GameObject flipPage;
    private LineRenderer lineRendererGaze;
    public GameObject line_1_2;
    public GameObject line_2_3;
    public GameObject line_3_4;
    public GameObject line_4_5;
    public GameObject line_5_6;
    public GameObject line_6_7;
    public GameObject line_7_8;
    public GameObject line_8_9;
    public GameObject line_9_10;
    public GameObject line_10_11;
    public GameObject line_11_12;
    public GameObject line_12_13;
    public GameObject line_13_14;
    public GameObject line_14_15;
    public GameObject line_15_16;
    public GameObject line_16_12;    
    private LineRenderer lineRenderer_1_2;
    private LineRenderer lineRenderer_2_3;
    private LineRenderer lineRenderer_3_4;
    private LineRenderer lineRenderer_4_5;
    private LineRenderer lineRenderer_5_6;
    private LineRenderer lineRenderer_6_7;
    private LineRenderer lineRenderer_7_8;
    private LineRenderer lineRenderer_8_9;
    private LineRenderer lineRenderer_9_10;
    private LineRenderer lineRenderer_10_11;
    private LineRenderer lineRenderer_11_12;
    private LineRenderer lineRenderer_12_13;
    private LineRenderer lineRenderer_13_14;
    private LineRenderer lineRenderer_14_15;
    private LineRenderer lineRenderer_15_16;
    private LineRenderer lineRenderer_16_12;        
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
        for (int i = 1; i <= 16; i++)
        {
            stars[i-1] = GameObject.Find($"StarBoundMesh/Pisces/Star{i}");
        }
        menuStatus = GameObject.Find("MenuStatus");
        gazeVisualizer = GameObject.Find("GazeUtilityMenu/Offset/GazeVisualizer");
    }

    public void InitRenderers()
    {
        piscesRenderer = GetComponent<Renderer>();
        lineRendererGaze = gazeVisualizer.GetComponent<LineRenderer>();
        lineRendererGaze.enabled = false;
        lineRenderer_1_2 = line_1_2.GetComponent<LineRenderer>();
        lineRenderer_2_3 = line_2_3.GetComponent<LineRenderer>();
        lineRenderer_3_4 = line_3_4.GetComponent<LineRenderer>();
        lineRenderer_4_5 = line_4_5.GetComponent<LineRenderer>();
        lineRenderer_5_6 = line_5_6.GetComponent<LineRenderer>();
        lineRenderer_6_7 = line_6_7.GetComponent<LineRenderer>();
        lineRenderer_7_8 = line_7_8.GetComponent<LineRenderer>();
        lineRenderer_8_9 = line_8_9.GetComponent<LineRenderer>();
        lineRenderer_9_10 = line_9_10.GetComponent<LineRenderer>();
        lineRenderer_10_11 = line_10_11.GetComponent<LineRenderer>();
        lineRenderer_11_12 = line_11_12.GetComponent<LineRenderer>();
        lineRenderer_12_13 = line_12_13.GetComponent<LineRenderer>();
        lineRenderer_13_14 = line_13_14.GetComponent<LineRenderer>();
        lineRenderer_14_15 = line_14_15.GetComponent<LineRenderer>();
        lineRenderer_15_16 = line_15_16.GetComponent<LineRenderer>();
        lineRenderer_16_12 = line_16_12.GetComponent<LineRenderer>();
    }

    public void InitLineRendererStarPosition()
    {
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_1_2, stars[0], stars[1]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_2_3, stars[1], stars[2]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_3_4, stars[2], stars[3]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_4_5, stars[3], stars[4]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_5_6, stars[4], stars[5]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_6_7, stars[5], stars[6]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_7_8, stars[6], stars[7]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_8_9, stars[7], stars[8]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_9_10, stars[8], stars[9]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_10_11, stars[9], stars[10]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_11_12, stars[10], stars[11]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_12_13, stars[11], stars[12]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_13_14, stars[12], stars[13]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_14_15, stars[13], stars[14]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_15_16, stars[14], stars[15]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_16_12, stars[15], stars[11]);
    }

    public void GazeFocusChanged(bool hasFocus)
    {
        if (hasFocus && gameObject.name == "Star1" && !isFinished)
        {
            stars[0].GetComponent<InteractionPisces>().isSelected = true;
            piscesRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionPisces));
            InteractionHelper.SetIsLast(stars[0], typeof(InteractionPisces));
        }
        if (hasFocus && gameObject.name == "Star2" && !isFinished)
        {
            stars[1].GetComponent<InteractionPisces>().isSelected = true;
            piscesRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionPisces));
            InteractionHelper.SetIsLast(stars[1], typeof(InteractionPisces));
        }
        if (hasFocus && gameObject.name == "Star3" && !isFinished)
        {
            stars[2].GetComponent<InteractionPisces>().isSelected = true;
            piscesRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionPisces));
            InteractionHelper.SetIsLast(stars[2], typeof(InteractionPisces));
        }
        if (hasFocus && gameObject.name == "Star4" && !isFinished)
        {
            stars[3].GetComponent<InteractionPisces>().isSelected = true;
            piscesRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionPisces));
            InteractionHelper.SetIsLast(stars[3], typeof(InteractionPisces));
        }
        if (hasFocus && gameObject.name == "Star5" && !isFinished)
        {
            stars[4].GetComponent<InteractionPisces>().isSelected = true;
            piscesRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionPisces));
            InteractionHelper.SetIsLast(stars[4], typeof(InteractionPisces));
        }
        if (hasFocus && gameObject.name == "Star6" && !isFinished)
        {
            stars[5].GetComponent<InteractionPisces>().isSelected = true;
            piscesRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionPisces));
            InteractionHelper.SetIsLast(stars[5], typeof(InteractionPisces));
        }
        if (hasFocus && gameObject.name == "Star7" && !isFinished)
        {
            stars[6].GetComponent<InteractionPisces>().isSelected = true;
            piscesRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionPisces));
            InteractionHelper.SetIsLast(stars[6], typeof(InteractionPisces));
        }
        if (hasFocus && gameObject.name == "Star8" && !isFinished)
        {
            stars[7].GetComponent<InteractionPisces>().isSelected = true;
            piscesRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionPisces));
            InteractionHelper.SetIsLast(stars[7], typeof(InteractionPisces));
        }
        if (hasFocus && gameObject.name == "Star9" && !isFinished)
        {
            stars[8].GetComponent<InteractionPisces>().isSelected = true;
            piscesRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionPisces));
            InteractionHelper.SetIsLast(stars[8], typeof(InteractionPisces));
        }
        if (hasFocus && gameObject.name == "Star10" && !isFinished)
        {
            stars[9].GetComponent<InteractionPisces>().isSelected = true;
            piscesRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionPisces));
            InteractionHelper.SetIsLast(stars[9], typeof(InteractionPisces));
        }
        if (hasFocus && gameObject.name == "Star11" && !isFinished)
        {
            stars[10].GetComponent<InteractionPisces>().isSelected = true;
            piscesRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionPisces));
            InteractionHelper.SetIsLast(stars[10], typeof(InteractionPisces));
        }
        if (hasFocus && gameObject.name == "Star12" && !isFinished)
        {
            stars[11].GetComponent<InteractionPisces>().isSelected = true;
            piscesRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionPisces));
            InteractionHelper.SetIsLast(stars[11], typeof(InteractionPisces));
        }
        if (hasFocus && gameObject.name == "Star13" && !isFinished)
        {
            stars[12].GetComponent<InteractionPisces>().isSelected = true;
            piscesRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionPisces));
            InteractionHelper.SetIsLast(stars[12], typeof(InteractionPisces));
        }
        if (hasFocus && gameObject.name == "Star14" && !isFinished)
        {
            stars[13].GetComponent<InteractionPisces>().isSelected = true;
            piscesRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionPisces));
            InteractionHelper.SetIsLast(stars[13], typeof(InteractionPisces));
        }
        if (hasFocus && gameObject.name == "Star15" && !isFinished)
        {
            stars[14].GetComponent<InteractionPisces>().isSelected = true;
            piscesRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionPisces));
            InteractionHelper.SetIsLast(stars[14], typeof(InteractionPisces));
        }
        if (hasFocus && gameObject.name == "Star16" && !isFinished)
        {
            stars[15].GetComponent<InteractionPisces>().isSelected = true;
            piscesRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionPisces));
            InteractionHelper.SetIsLast(stars[15], typeof(InteractionPisces));
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
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[0], ref stars[1], ref lineRenderer_1_2, typeof(InteractionPisces));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[1], ref stars[2], ref lineRenderer_2_3, typeof(InteractionPisces));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[2], ref stars[3], ref lineRenderer_3_4, typeof(InteractionPisces));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[3], ref stars[4], ref lineRenderer_4_5, typeof(InteractionPisces));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[4], ref stars[5], ref lineRenderer_5_6, typeof(InteractionPisces));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[5], ref stars[6], ref lineRenderer_6_7, typeof(InteractionPisces));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[6], ref stars[7], ref lineRenderer_7_8, typeof(InteractionPisces));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[7], ref stars[8], ref lineRenderer_8_9, typeof(InteractionPisces));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[8], ref stars[9], ref lineRenderer_9_10, typeof(InteractionPisces));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[9], ref stars[10], ref lineRenderer_10_11, typeof(InteractionPisces));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[10], ref stars[11], ref lineRenderer_11_12, typeof(InteractionPisces));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[11], ref stars[12], ref lineRenderer_12_13, typeof(InteractionPisces));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[12], ref stars[13], ref lineRenderer_13_14, typeof(InteractionPisces));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[13], ref stars[14], ref lineRenderer_14_15, typeof(InteractionPisces));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[14], ref stars[15], ref lineRenderer_15_16, typeof(InteractionPisces));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[15], ref stars[11], ref lineRenderer_16_12, typeof(InteractionPisces));
    }

    public void DrawGazeLine()
    {
        foreach (GameObject star in stars)
        {
            if (star.GetComponent<InteractionPisces>().isLastSelected)
            {
                InteractionHelper.SetLineRendererGazePosition(ref lineRendererGaze, star, gazeVisualizer);
                InteractionHelper.SetIsFirst(star, typeof(InteractionPisces));

                if (!isFinished)
                {
                    InteractionHelper.ChangeScriptComponentStatus(false, typeof(InteractionPisces));
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
           lineRenderer_4_5.enabled &&
           lineRenderer_5_6.enabled &&
           lineRenderer_6_7.enabled &&
           lineRenderer_7_8.enabled &&
           lineRenderer_8_9.enabled &&
           lineRenderer_9_10.enabled &&
           lineRenderer_10_11.enabled &&
           lineRenderer_11_12.enabled &&
           lineRenderer_12_13.enabled &&
           lineRenderer_13_14.enabled &&
           lineRenderer_14_15.enabled &&
           lineRenderer_15_16.enabled &&
           lineRenderer_16_12.enabled)
        {
            lineRendererGaze.enabled = false;
            currentStar = null;

            foreach (GameObject star in stars)
            {
                piscesRenderer = star.GetComponent<Renderer>();
                piscesRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.green);
            }
            
            InteractionHelper.ChangeScriptComponentStatus(true, typeof(InteractionPisces));
            InteractionHelper.ResetPreviousStars();
            if (!isFinished)
            {
                flipPage.GetComponent<FlipPage>().ChangePageContent(false, typeof(InteractionPisces));
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