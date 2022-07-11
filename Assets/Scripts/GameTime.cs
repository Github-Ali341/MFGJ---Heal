public static class GameTime
{
    private static float _timeScale;

    public static float TimeScale 
    {
        get
        {
            return _timeScale;
        }
    }

    public static void SetTimeScale (float newScale) { _timeScale = newScale; }
}
