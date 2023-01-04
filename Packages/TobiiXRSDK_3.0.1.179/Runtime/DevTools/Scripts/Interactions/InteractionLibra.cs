using Tobii.G2OM;
using UnityEngine;

public class InteractionLibra : MonoBehaviour, IGazeFocusable, IZodiac
{
    private Renderer libraRenderer;
    private GameObject[] stars = new GameObject[8];
    private GameObject currentStar = null;
    private GameObject menuStatus;
    public GameObject zodiacBackground;
    private GameObject gazeVisualizer;
    public GameObject flipPage;
    private LineRenderer lineRendererGaze;
    public GameObject line_1_2;
    public GameObject line_1_3;
    public GameObject line_2_3;
    public GameObject line_2_4;
    public GameObject line_4_5;
    public GameObject line_5_6;
    public GameObject line_3_7;
    public GameObject line_7_8;
    private LineRenderer lineRenderer_1_2;
    private LineRenderer lineRenderer_1_3;
    private LineRenderer lineRenderer_2_3;
    private LineRenderer lineRenderer_2_4;
    private LineRenderer lineRenderer_4_5;
    private LineRenderer lineRenderer_5_6;
    private LineRenderer lineRenderer_3_7;
    private LineRenderer lineRenderer_7_8;
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
        for (int i = 1; i <= 8; i++)
        {
            stars[i - 1] = GameObject.Find($"StarBoundMesh/Libra/Star{i}");
        }
        menuStatus = GameObject.Find("MenuStatus");
        gazeVisualizer = GameObject.Find("GazeUtilityMenu/Offset/GazeVisualizer");
    }

    public void InitRenderers()
    {
        libraRenderer = GetComponent<Renderer>();
        lineRendererGaze = gazeVisualizer.GetComponent<LineRenderer>();
        lineRendererGaze.enabled = false;
        lineRenderer_1_2 = line_1_2.GetComponent<LineRenderer>();
        lineRenderer_1_3 = line_1_3.GetComponent<LineRenderer>();
        lineRenderer_2_3 = line_2_3.GetComponent<LineRenderer>();
        lineRenderer_2_4 = line_2_4.GetComponent<LineRenderer>();
        lineRenderer_4_5 = line_4_5.GetComponent<LineRenderer>();
        lineRenderer_5_6 = line_5_6.GetComponent<LineRenderer>();
        lineRenderer_3_7 = line_3_7.GetComponent<LineRenderer>();
        lineRenderer_7_8 = line_7_8.GetComponent<LineRenderer>();
    }

    public void InitLineRendererStarPosition()
    {
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_1_2, stars[0], stars[1]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_1_3, stars[0], stars[2]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_2_3, stars[1], stars[2]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_2_4, stars[1], stars[3]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_4_5, stars[3], stars[4]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_5_6, stars[4], stars[5]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_3_7, stars[2], stars[6]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_7_8, stars[6], stars[7]);
    }

    public void GazeFocusChanged(bool hasFocus)
    {
        if (hasFocus && gameObject.name == "Star1" && !isFinished)
        {
            stars[0].GetComponent<InteractionLibra>().isSelected = true;
            libraRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionLibra));
            InteractionHelper.SetIsLast(stars[0], typeof(InteractionLibra));
        }
        if (hasFocus && gameObject.name == "Star2" && !isFinished)
        {
            stars[1].GetComponent<InteractionLibra>().isSelected = true;
            libraRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionLibra));
            InteractionHelper.SetIsLast(stars[1], typeof(InteractionLibra));
        }
        if (hasFocus && gameObject.name == "Star3" && !isFinished)
        {
            stars[2].GetComponent<InteractionLibra>().isSelected = true;
            libraRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionLibra));
            InteractionHelper.SetIsLast(stars[2], typeof(InteractionLibra));
        }
        if (hasFocus && gameObject.name == "Star4" && !isFinished)
        {
            stars[3].GetComponent<InteractionLibra>().isSelected = true;
            libraRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionLibra));
            InteractionHelper.SetIsLast(stars[3], typeof(InteractionLibra));
        }
        if (hasFocus && gameObject.name == "Star5" && !isFinished)
        {
            stars[4].GetComponent<InteractionLibra>().isSelected = true;
            libraRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionLibra));
            InteractionHelper.SetIsLast(stars[4], typeof(InteractionLibra));
        }
        if (hasFocus && gameObject.name == "Star6" && !isFinished)
        {
            stars[5].GetComponent<InteractionLibra>().isSelected = true;
            libraRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionLibra));
            InteractionHelper.SetIsLast(stars[5], typeof(InteractionLibra));
        }
        if (hasFocus && gameObject.name == "Star7" && !isFinished)
        {
            stars[6].GetComponent<InteractionLibra>().isSelected = true;
            libraRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionLibra));
            InteractionHelper.SetIsLast(stars[6], typeof(InteractionLibra));
        }
        if (hasFocus && gameObject.name == "Star8" && !isFinished)
        {
            stars[7].GetComponent<InteractionLibra>().isSelected = true;
            libraRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionLibra));
            InteractionHelper.SetIsLast(stars[7], typeof(InteractionLibra));
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
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[0], ref stars[1], ref lineRenderer_1_2, typeof(InteractionLibra));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[0], ref stars[2], ref lineRenderer_1_3, typeof(InteractionLibra));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[1], ref stars[2], ref lineRenderer_2_3, typeof(InteractionLibra));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[1], ref stars[3], ref lineRenderer_2_4, typeof(InteractionLibra));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[3], ref stars[4], ref lineRenderer_4_5, typeof(InteractionLibra));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[4], ref stars[5], ref lineRenderer_5_6, typeof(InteractionLibra));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[2], ref stars[6], ref lineRenderer_3_7, typeof(InteractionLibra));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[6], ref stars[7], ref lineRenderer_7_8, typeof(InteractionLibra));
    }

    public void DrawGazeLine()
    {
        foreach (GameObject star in stars)
        {
            if (star.GetComponent<InteractionLibra>().isLastSelected)
            {
                InteractionHelper.SetLineRendererGazePosition(ref lineRendererGaze, star, gazeVisualizer);
                InteractionHelper.SetIsFirst(star, typeof(InteractionLibra));

                if (!isFinished)
                {
                    InteractionHelper.ChangeScriptComponentStatus(false, typeof(InteractionLibra));
                }
            }
        }

        ZodiacCompleted();
    }

    public void ZodiacCompleted()
    {
        if (lineRenderer_1_2.enabled &&
            lineRenderer_1_3.enabled &&
            lineRenderer_2_3.enabled &&
            lineRenderer_2_4.enabled &&
            lineRenderer_4_5.enabled &&
            lineRenderer_5_6.enabled &&
            lineRenderer_3_7.enabled &&
            lineRenderer_7_8.enabled)
        {
            lineRendererGaze.enabled = false;
            currentStar = null;

            foreach (GameObject star in stars)
            {
                libraRenderer = star.GetComponent<Renderer>();
                libraRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.green);
            }
                      
            InteractionHelper.ChangeScriptComponentStatus(true, typeof(InteractionLibra));
            InteractionHelper.ResetPreviousStars();
            if (!isFinished)
            {
                flipPage.GetComponent<FlipPage>().ChangePageContent(false, typeof(InteractionLibra));
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