interface IZodiac
{
    /// <summary>
    /// Find and initialize stars objects, menu status object and gaze visualizer object.
    /// </summary>
    void InitGameObjects();

    /// <summary>
    /// Initialize renderer and line renderer for stars and gaze.
    /// </summary>
    void InitRenderers();

    /// <summary>
    /// Initialize line renderer for two stars.
    /// </summary>
    void InitLineRendererStarPosition();

    /// <summary>
    /// Select gazed star and higlight star color.
    /// </summary>
    /// <param name="hasFocus"></param>
    void GazeFocusChanged(bool hasFocus);  

    /// <summary>
    /// Enable the line between two selected stars. 
    /// Deselect the isFirst star and set current star to the other star.
    /// </summary>
    void DrawStarLine();

    /// <summary>
    /// Draw line between selected star and gaze visualizer and set the star that is first looked at.
    /// Disable all other star interaction scripts except the current gazed zodiac.
    /// When zodiac is finished, disable gazeline and set current star null to prevent gazeline at menu.
    /// </summary>
    void DrawGazeLine();

    /// <summary>
    /// Enable all other star interaction scripts, play zodiac fade in sound and start coroutine to fade in the zodiac image
    /// when the current zodiac is finished.
    /// </summary>
    void ZodiacCompleted();

    /// <summary>
    /// Stop all coroutines and update zodiac background color for improved visual feedback.
    /// </summary>
    void UpdateColorAfterCoroutine();

    /// <summary>
    /// Disable gazeline when looking at menu, enable gazeline when looking at farplane
    /// </summary>
    void DrawGazeLineAtMenu();
}

