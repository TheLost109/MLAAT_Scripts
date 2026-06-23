using UnityEngine;

public class DontDestroyOnLoadTemplate : MonoBehaviour
{
    // 单例模式
    private static DontDestroyOnLoadTemplate Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
