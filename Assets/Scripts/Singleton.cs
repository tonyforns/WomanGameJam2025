using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; }

    internal virtual void Awake()
    {
        if (Instance == null)
        {
            Instance = this as T;
        }
        else
        {
            Debug.LogError($"Double instance of {this.name}, deleating it");
            Destroy(gameObject);
        }
    }
}