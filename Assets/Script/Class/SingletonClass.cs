using UnityEngine;

public abstract class SingletonClass<T> : MonoBehaviour where T : Component
{
    private static T _instance;
    public static T Instance => _instance;

    private void Awake()
    {
        SingletonClassCallOnAwake();
    }
    protected void SingletonClassCallOnAwake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            _instance = this as T;
        }
    }
}
