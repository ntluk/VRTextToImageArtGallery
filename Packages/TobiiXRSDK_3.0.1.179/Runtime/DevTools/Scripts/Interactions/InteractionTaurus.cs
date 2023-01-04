using Tobii.G2OM;
using UnityEngine;

public class InteractionTaurus : MonoBehaviour, IGazeFocusable, IZodiac
{
    private Renderer taurusRenderer;
    private GameObject[] stars = new GameObject[14];
    private GameObject currentStar = null;
    private GameObject menuStatus;
    public GameObject zodiacBackground;
    private GameObject gazeVisualizer;
    public GameObject flipPage;
    private LineRenderer lineRendererGaze;
    public GameObject line_1_2;
    public GameObject line_2_3;
    public GameObject line_3_4;
    public GameObject line_5_6;
    public GameObject line_6_7;
    public GameObject line_7_8;
    public GameObject line_8_4;
    public GameObject line_4_9;
    public GameObject line_9_10;
    public GameObject line_10_11;
    public GameObject line_9_12;
    public GameObject line_12_13;
    public GameObject line_13_14;
    private LineRenderer lineRenderer_1_2;
    private LineRenderer lineRenderer_2_3;
    private LineRenderer lineRenderer_3_4;
    private LineRenderer lineRenderer_5_6;
    private LineRenderer lineRenderer_6_7;
    private LineRenderer lineRenderer_7_8;
    private LineRenderer lineRenderer_8_4;
    private LineRenderer lineRenderer_4_9;
    private LineRenderer lineRenderer_9_10;
    private LineRenderer lineRenderer_10_11;
    private LineRenderer lineRenderer_9_12;
    private LineRenderer lineRenderer_12_13;
    private LineRenderer lineRenderer_13_14;
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
        for (int i = 1; i <= 14; i++)
        {
            stars[i - 1] = GameObject.Find($"StarBoundMesh/Taurus/Star{i}");
        }
        menuStatus = GameObject.Find("MenuStatus");
        gazeVisualizer = GameObject.Find("GazeUtilityMenu/Offset/GazeVisualizer");
    }

    public void InitRenderers()
    {
        taurusRenderer = GetComponent<Renderer>();
        lineRendererGaze = gazeVisualizer.GetComponent<LineRenderer>();
        lineRendererGaze.enabled = false;
        lineRenderer_1_2 = line_1_2.GetComponent<LineRenderer>();
        lineRenderer_2_3 = line_2_3.GetComponent<LineRenderer>();
        lineRenderer_3_4 = line_3_4.GetComponent<LineRenderer>();
        lineRenderer_5_6 = line_5_6.GetComponent<LineRenderer>();
        lineRenderer_6_7 = line_6_7.GetComponent<LineRenderer>();
        lineRenderer_7_8 = line_7_8.GetComponent<LineRenderer>();
        lineRenderer_8_4 = line_8_4.GetComponent<LineRenderer>();
        lineRenderer_4_9 = line_4_9.GetComponent<LineRenderer>();
        lineRenderer_9_10 = line_9_10.GetComponent<LineRenderer>();
        lineRenderer_10_11 = line_10_11.GetComponent<LineRenderer>();
        lineRenderer_9_12 = line_9_12.GetComponent<LineRenderer>();
        lineRenderer_12_13 = line_12_13.GetComponent<LineRenderer>();
        lineRenderer_13_14 = line_13_14.GetComponent<LineRenderer>();
    }

    public void InitLineRendererStarPosition()
    {
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_1_2, stars[0], stars[1]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_2_3, stars[1], stars[2]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_3_4, stars[2], stars[3]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_5_6, stars[4], stars[5]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_6_7, stars[5], stars[6]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_7_8, stars[6], stars[7]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_8_4, stars[7], stars[3]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_4_9, stars[3], stars[8]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_9_10, stars[8], stars[9]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_10_11, stars[9], stars[10]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_9_12, stars[8], stars[11]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_12_13, stars[11], stars[12]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_13_14, stars[12], stars[13]);
    }

    public void GazeFocusChanged(bool hasFocus)
    {
        if (hasFocus && gameObject.name == "Star1" && !isFinished)
        {
            stars[0].GetComponent<InteractionTaurus>().isSelected = true;
            taurusRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionTaurus));
            InteractionHelper.SetIsLast(stars[0], typeof(InteractionTaurus));
        }
        if (hasFocus && gameObject.name == "Star2" && !isFinished)
        {
            stars[1].GetComponent<InteractionTaurus>().isSelected = true;
            taurusRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionTaurus));
            InteractionHelper.SetIsLast(stars[1], typeof(InteractionTaurus));
        }
        if (hasFocus && gameObject.name == "Star3" && !isFinished)
        {
            stars[2].GetComponent<InteractionTaurus>().isSelected = true;
            taurusRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionTaurus));
            InteractionHelper.SetIsLast(stars[2], typeof(InteractionTaurus));
        }
        if (hasFocus && gameObject.name == "Star4" && !isFinished)
        {
            stars[3].GetComponent<InteractionTaurus>().isSelected = true;
            taurusRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionTaurus));
            InteractionHelper.SetIsLast(stars[3], typeof(InteractionTaurus));
        }
        if (hasFocus && gameObject.name == "Star5" && !isFinished)
        {
            stars[4].GetComponent<InteractionTaurus>().isSelected = true;
            taurusRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionTaurus));
            InteractionHelper.SetIsLast(stars[4], typeof(InteractionTaurus));
        }
        if (hasFocus && gameObject.name == "Star6" && !isFinished)
        {
            stars[5].GetComponent<InteractionTaurus>().isSelected = true;
            taurusRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionTaurus));
            InteractionHelper.SetIsLast(stars[5], typeof(InteractionTaurus));
        }
        if (hasFocus && gameObject.name == "Star7" && !isFinished)
        {
            stars[6].GetComponent<InteractionTaurus>().isSelected = true;
            taurusRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionTaurus));
            InteractionHelper.SetIsLast(stars[6], typeof(InteractionTaurus));
        }
        if (hasFocus && gameObject.name == "Star8" && !isFinished)
        {
            stars[7].GetComponent<InteractionTaurus>().isSelected = true;
            taurusRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionTaurus));
            InteractionHelper.SetIsLast(stars[7], typeof(InteractionTaurus));
        }
        if (hasFocus && gameObject.name == "Star9" && !isFinished)
        {
            stars[8].GetComponent<InteractionTaurus>().isSelected = true;
            taurusRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionTaurus));
            InteractionHelper.SetIsLast(stars[8], typeof(InteractionTaurus));
        }
        if (hasFocus && gameObject.name == "Star10" && !isFinished)
        {
            stars[9].GetComponent<InteractionTaurus>().isSelected = true;
            taurusRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionTaurus));
            InteractionHelper.SetIsLast(stars[9], typeof(InteractionTaurus));
        }
        if (hasFocus && gameObject.name == "Star11" && !isFinished)
        {
            stars[10].GetComponent<InteractionTaurus>().isSelected = true;
            taurusRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionTaurus));
            InteractionHelper.SetIsLast(stars[10], typeof(InteractionTaurus));
        }
        if (hasFocus && gameObject.name == "Star12" && !isFinished)
        {
            stars[11].GetComponent<InteractionTaurus>().isSelected = true;
            taurusRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionTaurus));
            InteractionHelper.SetIsLast(stars[11], typeof(InteractionTaurus));
        }
        if (hasFocus && gameObject.name == "Star13" && !isFinished)
        {
            stars[12].GetComponent<InteractionTaurus>().isSelected = true;
            taurusRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionTaurus));
            InteractionHelper.SetIsLast(stars[12], typeof(InteractionTaurus));
        }
        if (hasFocus && gameObject.name == "Star14" && !isFinished)
        {
            stars[13].GetComponent<InteractionTaurus>().isSelected = true;
            taurusRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionTaurus));
            InteractionHelper.SetIsLast(stars[13], typeof(InteractionTaurus));
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
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[0], ref stars[1], ref lineRenderer_1_2, typeof(InteractionTaurus));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[1], ref stars[2], ref lineRenderer_2_3, typeof(InteractionTaurus));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[2], ref stars[3], ref lineRenderer_3_4, typeof(InteractionTaurus));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[4], ref stars[5], ref lineRenderer_5_6, typeof(InteractionTaurus));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[5], ref stars[6], ref lineRenderer_6_7, typeof(InteractionTaurus));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[6], ref stars[7], ref lineRenderer_7_8, typeof(InteractionTaurus));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[7], ref stars[3], ref lineRenderer_8_4, typeof(InteractionTaurus));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[3], ref stars[8], ref lineRenderer_4_9, typeof(InteractionTaurus));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[8], ref stars[9], ref lineRenderer_9_10, typeof(InteractionTaurus));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[9], ref stars[10], ref lineRenderer_10_11, typeof(InteractionTaurus));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[8], ref stars[11], ref lineRenderer_9_12, typeof(InteractionTaurus));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[11], ref stars[12], ref lineRenderer_12_13, typeof(InteractionTaurus));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[12], ref stars[13], ref lineRenderer_13_14, typeof(InteractionTaurus));        
    }

    public void DrawGazeLine()
    {
        foreach (GameObject star in stars)
        {
            if (star.GetComponent<InteractionTaurus>().isLastSelected)
            {
                InteractionHelper.SetLineRendererGazePosition(ref lineRendererGaze, star, gazeVisualizer);
                InteractionHelper.SetIsFirst(star, typeof(InteractionTaurus));

                if (!isFinished)
                {
                    InteractionHelper.ChangeScriptComponentStatus(false, typeof(InteractionTaurus));
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
            lineRenderer_5_6.enabled &&
            lineRenderer_6_7.enabled &&
            lineRenderer_7_8.enabled &&
            lineRenderer_8_4.enabled &&
            lineRenderer_4_9.enabled &&
            lineRenderer_9_10.enabled &&
            lineRenderer_10_11.enabled &&
            lineRenderer_9_12.enabled &&
            lineRenderer_12_13.enabled &&
            lineRenderer_13_14.enabled)
        {
            lineRendererGaze.enabled = false;
            currentStar = null;

            foreach (GameObject star in stars)
            {
                taurusRenderer = star.GetComponent<Renderer>();
                taurusRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.green);
            }

            InteractionHelper.ChangeScriptComponentStatus(true, typeof(InteractionTaurus));
            InteractionHelper.ResetPreviousStars();
            if (!isFinished)
            {
                flipPage.GetComponent<FlipPage>().ChangePageContent(false, typeof(InteractionTaurus));
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
