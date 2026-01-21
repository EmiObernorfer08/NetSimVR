using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GlobalResetManager : MonoBehaviour
{
    public static GlobalResetManager Instance;

    private List<GameObject> persistentObjects = new List<GameObject>();

    [SerializeField] private string resetTag = "cable";

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
    }

    // Persistente Objekte registrieren
    public void Register(GameObject obj)
    {
        if (obj == gameObject) return;

        if (!persistentObjects.Contains(obj))
            persistentObjects.Add(obj);
    }

    // 🔥 Reset: NUR persistente Objekte mit Tag "cable"
    public void FullReset()
    {
        for (int i = persistentObjects.Count - 1; i >= 0; i--)
        {
            GameObject obj = persistentObjects[i];

            if (obj == null)
            {
                continue;
            }

            if (obj.CompareTag(resetTag))
            {
                Destroy(obj);
                persistentObjects.RemoveAt(i);
            }
        }

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
