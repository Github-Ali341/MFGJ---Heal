using UnityEngine;

public class StaticInstanceSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance;

    protected virtual void Awake ()
    {
        Instance = this as T;
    }
}