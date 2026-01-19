using UnityEngine;

public class PersistentObject : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        GlobalResetManager.Instance.RegisterPersistentObject(gameObject);
    }
}
