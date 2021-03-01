using UnityEngine;

public abstract class MonoSingleton<T>  :MonoBehaviour  where T :Component
{
    public static T _Instance;
    private void Awake()
    {
        if (_Instance == null)
        {
            _Instance = this as T;
        }
    }
}
