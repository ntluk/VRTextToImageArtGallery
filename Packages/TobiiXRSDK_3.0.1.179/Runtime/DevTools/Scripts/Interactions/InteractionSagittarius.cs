using Tobii.G2OM;
using UnityEngine;

public class InteractionSagittarius : MonoBehaviour, IGazeFocusable, IZodiac
{
    private Renderer sagittariusRenderer;
    private GameObject[] stars = new GameObject[22];
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
    public GameObject line_6_8;
    public GameObject line_8_9;
    public GameObject line_9_10;
    public GameObject line_8_11;
    public GameObject line_11_12;
    public GameObject line_5_13;
    public GameObject line_13_14;
    public GameObject line_14_4;
    public GameObject line_14_15;
    public GameObject line_15_16;
    public GameObject line_16_17;
    public GameObject line_17_18;
    public GameObject line_18_19;
    public GameObject line_19_20;
    public GameObject line_20_21;
    public GameObject line_20_22;
    private LineRenderer lineRenderer_1_2;
    private LineRenderer lineRenderer_2_3;
    private LineRenderer lineRenderer_3_4;
    private LineRenderer lineRenderer_4_5;
    private LineRenderer lineRenderer_5_6;
    private LineRenderer lineRenderer_6_7;
    private LineRenderer lineRenderer_6_8;
    private LineRenderer lineRenderer_8_9;
    private LineRenderer lineRenderer_9_10;
    private LineRenderer lineRenderer_8_11;
    private LineRenderer lineRenderer_11_12;
    private LineRenderer lineRenderer_5_13;
    private LineRenderer lineRenderer_13_14;
    private LineRenderer lineRenderer_14_4;
    private LineRenderer lineRenderer_14_15;
    private LineRenderer lineRenderer_15_16;
    private LineRenderer lineRenderer_16_17;
    private LineRenderer lineRenderer_17_18;
    private LineRenderer lineRenderer_18_19;
    private LineRenderer lineRenderer_19_20;
    private LineRenderer lineRenderer_20_21;
    private LineRenderer lineRenderer_20_22;    
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
        for (int i = 1; i <= 22; i++)
        {
            stars[i - 1] = GameObject.Find($"StarBoundMesh/Sagittarius/Star{i}");
        }
        menuStatus = GameObject.Find("MenuStatus");
        gazeVisualizer = GameObject.Find("GazeUtilityMenu/Offset/GazeVisualizer");
    }

    public void InitRenderers()
    {
        sagittariusRenderer = GetComponent<Renderer>();
        lineRendererGaze = gazeVisualizer.GetComponent<LineRenderer>();
        lineRendererGaze.enabled = false;
        lineRenderer_1_2 = line_1_2.GetComponent<LineRenderer>();
        lineRenderer_2_3 = line_2_3.GetComponent<LineRenderer>();
        lineRenderer_3_4 = line_3_4.GetComponent<LineRenderer>();
        lineRenderer_4_5 = line_4_5.GetComponent<LineRenderer>();
        lineRenderer_5_6 = line_5_6.GetComponent<LineRenderer>();
        lineRenderer_6_7 = line_6_7.GetComponent<LineRenderer>();
        lineRenderer_6_8 = line_6_8.GetComponent<LineRenderer>();
        lineRenderer_8_9 = line_8_9.GetComponent<LineRenderer>();
        lineRenderer_9_10 = line_9_10.GetComponent<LineRenderer>();
        lineRenderer_8_11 = line_8_11.GetComponent<LineRenderer>();
        lineRenderer_11_12 = line_11_12.GetComponent<LineRenderer>();
        lineRenderer_5_13 = line_5_13.GetComponent<LineRenderer>();
        lineRenderer_13_14 = line_13_14.GetComponent<LineRenderer>();
        lineRenderer_14_4 = line_14_4.GetComponent<LineRenderer>();
        lineRenderer_14_15 = line_14_15.GetComponent<LineRenderer>();
        lineRenderer_15_16 = line_15_16.GetComponent<LineRenderer>();
        lineRenderer_16_17 = line_16_17.GetComponent<LineRenderer>();
        lineRenderer_17_18 = line_17_18.GetComponent<LineRenderer>();
        lineRenderer_18_19 = line_18_19.GetComponent<LineRenderer>();
        lineRenderer_19_20 = line_19_20.GetComponent<LineRenderer>();
        lineRenderer_20_21 = line_20_21.GetComponent<LineRenderer>();
        lineRenderer_20_22 = line_20_22.GetComponent<LineRenderer>();
    }

    public void InitLineRendererStarPosition()
    {
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_1_2, stars[0], stars[1]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_2_3, stars[1], stars[2]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_3_4, stars[2], stars[3]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_4_5, stars[3], stars[4]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_5_6, stars[4], stars[5]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_6_7, stars[5], stars[6]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_6_8, stars[5], stars[7]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_8_9, stars[7], stars[8]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_9_10, stars[8], stars[9]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_8_11, stars[7], stars[10]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_11_12, stars[10], stars[11]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_5_13, stars[4], stars[12]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_13_14, stars[12], stars[13]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_14_4, stars[13], stars[3]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_14_15, stars[13], stars[14]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_15_16, stars[14], stars[15]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_16_17, stars[15], stars[16]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_17_18, stars[16], stars[17]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_18_19, stars[17], stars[18]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_19_20, stars[18], stars[19]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_20_21, stars[19], stars[20]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_20_22, stars[19], stars[21]);
    }

    public void GazeFocusChanged(bool hasFocus)
    {
        if (hasFocus && gameObject.name == "Star1" && !isFinished)
        {
            stars[0].GetComponent<InteractionSagittarius>().isSelected = true;
            sagittariusRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionSagittarius));
            InteractionHelper.SetIsLast(stars[0], typeof(InteractionSagittarius));
        }
        if (hasFocus && gameObject.name == "Star2" && !isFinished)
        {
            stars[1].GetComponent<InteractionSagittarius>().isSelected = true;
            sagittariusRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionSagittarius));
            InteractionHelper.SetIsLast(stars[1], typeof(InteractionSagittarius));
        }
        if (hasFocus && gameObject.name == "Star3" && !isFinished)
        {
            stars[2].GetComponent<InteractionSagittarius>().isSelected = true;
            sagittariusRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionSagittarius));
            InteractionHelper.SetIsLast(stars[2], typeof(InteractionSagittarius));
        }
        if (hasFocus && gameObject.name == "Star4" && !isFinished)
        {
            stars[3].GetComponent<InteractionSagittarius>().isSelected = true;
            sagittariusRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionSagittarius));
            InteractionHelper.SetIsLast(stars[3], typeof(InteractionSagittarius));
        }
        if (hasFocus && gameObject.name == "Star5" && !isFinished)
        {
            stars[4].GetComponent<InteractionSagittarius>().isSelected = true;
            sagittariusRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionSagittarius));
            InteractionHelper.SetIsLast(stars[4], typeof(InteractionSagittarius));
        }
        if (hasFocus && gameObject.name == "Star6" && !isFinished)
        {
            stars[5].GetComponent<InteractionSagittarius>().isSelected = true;
            sagittariusRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionSagittarius));
            InteractionHelper.SetIsLast(stars[5], typeof(InteractionSagittarius));
        }
        if (hasFocus && gameObject.name == "Star7" && !isFinished)
        {
            stars[6].GetComponent<InteractionSagittarius>().isSelected = true;
            sagittariusRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionSagittarius));
            InteractionHelper.SetIsLast(stars[6], typeof(InteractionSagittarius));
        }
        if (hasFocus && gameObject.name == "Star8" && !isFinished)
        {
            stars[7].GetComponent<InteractionSagittarius>().isSelected = true;
            sagittariusRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionSagittarius));
            InteractionHelper.SetIsLast(stars[7], typeof(InteractionSagittarius));
        }
        if (hasFocus && gameObject.name == "Star9" && !isFinished)
        {
            stars[8].GetComponent<InteractionSagittarius>().isSelected = true;
            sagittariusRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionSagittarius));
            InteractionHelper.SetIsLast(stars[8], typeof(InteractionSagittarius));
        }
        if (hasFocus && gameObject.name == "Star10" && !isFinished)
        {
            stars[9].GetComponent<InteractionSagittarius>().isSelected = true;
            sagittariusRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionSagittarius));
            InteractionHelper.SetIsLast(stars[9], typeof(InteractionSagittarius));
        }
        if (hasFocus && gameObject.name == "Star11" && !isFinished)
        {
            stars[10].GetComponent<InteractionSagittarius>().isSelected = true;
            sagittariusRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionSagittarius));
            InteractionHelper.SetIsLast(stars[10], typeof(InteractionSagittarius));
        }
        if (hasFocus && gameObject.name == "Star12" && !isFinished)
        {
            stars[11].GetComponent<InteractionSagittarius>().isSelected = true;
            sagittariusRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionSagittarius));
            InteractionHelper.SetIsLast(stars[11], typeof(InteractionSagittarius));
        }
        if (hasFocus && gameObject.name == "Star13" && !isFinished)
        {
            stars[12].GetComponent<InteractionSagittarius>().isSelected = true;
            sagittariusRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionSagittarius));
            InteractionHelper.SetIsLast(stars[12], typeof(InteractionSagittarius));
        }
        if (hasFocus && gameObject.name == "Star14" && !isFinished)
        {
            stars[13].GetComponent<InteractionSagittarius>().isSelected = true;
            sagittariusRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionSagittarius));
            InteractionHelper.SetIsLast(stars[13], typeof(InteractionSagittarius));
        }
        if (hasFocus && gameObject.name == "Star15" && !isFinished)
        {
            stars[14].GetComponent<InteractionSagittarius>().isSelected = true;
            sagittariusRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionSagittarius));
            InteractionHelper.SetIsLast(stars[14], typeof(InteractionSagittarius));
        }
        if (hasFocus && gameObject.name == "Star16" && !isFinished)
        {
            stars[15].GetComponent<InteractionSagittarius>().isSelected = true;
            sagittariusRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionSagittarius));
            InteractionHelper.SetIsLast(stars[15], typeof(InteractionSagittarius));
        }
        if (hasFocus && gameObject.name == "Star17" && !isFinished)
        {
            stars[16].GetComponent<InteractionSagittarius>().isSelected = true;
            sagittariusRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionSagittarius));
            InteractionHelper.SetIsLast(stars[16], typeof(InteractionSagittarius));
        }
        if (hasFocus && gameObject.name == "Star18" && !isFinished)
        {
            stars[17].GetComponent<InteractionSagittarius>().isSelected = true;
            sagittariusRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionSagittarius));
            InteractionHelper.SetIsLast(stars[17], typeof(InteractionSagittarius));
        }
        if (hasFocus && gameObject.name == "Star19" && !isFinished)
        {
            stars[18].GetComponent<InteractionSagittarius>().isSelected = true;
            sagittariusRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionSagittarius));
            InteractionHelper.SetIsLast(stars[18], typeof(InteractionSagittarius));
        }
        if (hasFocus && gameObject.name == "Star20" && !isFinished)
        {
            stars[19].GetComponent<InteractionSagittarius>().isSelected = true;
            sagittariusRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionSagittarius));
            InteractionHelper.SetIsLast(stars[19], typeof(InteractionSagittarius));
        }
        if (hasFocus && gameObject.name == "Star21" && !isFinished)
        {
            stars[20].GetComponent<InteractionSagittarius>().isSelected = true;
            sagittariusRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionSagittarius));
            InteractionHelper.SetIsLast(stars[20], typeof(InteractionSagittarius));
        }
        if (hasFocus && gameObject.name == "Star22" && !isFinished)
        {
            stars[21].GetComponent<InteractionSagittarius>().isSelected = true;
            sagittariusRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionSagittarius));
            InteractionHelper.SetIsLast(stars[21], typeof(InteractionSagittarius));
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
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[0], ref stars[1], ref lineRenderer_1_2, typeof(InteractionSagittarius));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[1], ref stars[2], ref lineRenderer_2_3, typeof(InteractionSagittarius));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[2], ref stars[3], ref lineRenderer_3_4, typeof(InteractionSagittarius));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[3], ref stars[4], ref lineRenderer_4_5, typeof(InteractionSagittarius));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[4], ref stars[5], ref lineRenderer_5_6, typeof(InteractionSagittarius));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[5], ref stars[6], ref lineRenderer_6_7, typeof(InteractionSagittarius));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[5], ref stars[7], ref lineRenderer_6_8, typeof(InteractionSagittarius));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[7], ref stars[8], ref lineRenderer_8_9, typeof(InteractionSagittarius));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[8], ref stars[9], ref lineRenderer_9_10, typeof(InteractionSagittarius));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[7], ref stars[10], ref lineRenderer_8_11, typeof(InteractionSagittarius));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[10], ref stars[11], ref lineRenderer_11_12, typeof(InteractionSagittarius));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[4], ref stars[12], ref lineRenderer_5_13, typeof(InteractionSagittarius));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[12], ref stars[13], ref lineRenderer_13_14, typeof(InteractionSagittarius));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[13], ref stars[3], ref lineRenderer_14_4, typeof(InteractionSagittarius));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[13], ref stars[14], ref lineRenderer_14_15, typeof(InteractionSagittarius));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[14], ref stars[15], ref lineRenderer_15_16, typeof(InteractionSagittarius));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[15], ref stars[16], ref lineRenderer_16_17, typeof(InteractionSagittarius));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[16], ref stars[17], ref lineRenderer_17_18, typeof(InteractionSagittarius));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[17], ref stars[18], ref lineRenderer_18_19, typeof(InteractionSagittarius));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[18], ref stars[19], ref lineRenderer_19_20, typeof(InteractionSagittarius));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[19], ref stars[20], ref lineRenderer_20_21, typeof(InteractionSagittarius));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[19], ref stars[21], ref lineRenderer_20_22, typeof(InteractionSagittarius));        
    }

    public void DrawGazeLine()
    {
        foreach (GameObject star in stars)
        {
            if (star.GetComponent<InteractionSagittarius>().isLastSelected)
            {
                InteractionHelper.SetLineRendererGazePosition(ref lineRendererGaze, star, gazeVisualizer);
                InteractionHelper.SetIsFirst(star, typeof(InteractionSagittarius));

                if (!isFinished)
                {
                    InteractionHelper.ChangeScriptComponentStatus(false, typeof(InteractionSagittarius));
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
           lineRenderer_6_8.enabled &&
           lineRenderer_8_9.enabled &&
           lineRenderer_9_10.enabled &&
           lineRenderer_8_11.enabled &&
           lineRenderer_11_12.enabled &&
           lineRenderer_5_13.enabled &&
           lineRenderer_13_14.enabled &&
           lineRenderer_14_4.enabled &&
           lineRenderer_14_15.enabled &&
           lineRenderer_15_16.enabled &&
           lineRenderer_16_17.enabled &&
           lineRenderer_17_18.enabled &&
           lineRenderer_18_19.enabled &&
           lineRenderer_19_20.enabled &&
           lineRenderer_20_21.enabled &&
           lineRenderer_20_22.enabled)
        {
            lineRendererGaze.enabled = false;
            currentStar = null;

            foreach (GameObject star in stars)
            {
                sagittariusRenderer = star.GetComponent<Renderer>();
                sagittariusRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.green);
            }
            
            InteractionHelper.ChangeScriptComponentStatus(true, typeof(InteractionSagittarius));
            InteractionHelper.ResetPreviousStars();
            if (!isFinished)
            {
                flipPage.GetComponent<FlipPage>().ChangePageContent(false, typeof(InteractionSagittarius));
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
