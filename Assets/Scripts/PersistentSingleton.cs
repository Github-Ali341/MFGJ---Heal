using UnityEngine;

public class PersistentSingleton<T> : MonoBehaviour where T : class
{
    public static T Instance;

    private void Awake ()
    {
        if (Instance == null)
        {
            Instance = this as T;
        } else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }
}
