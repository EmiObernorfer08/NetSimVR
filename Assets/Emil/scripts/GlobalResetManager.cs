using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GlobalResetManager : MonoBehaviour
{
    public static GlobalResetManager Instance;

    private List<GameObject> persistentObjects = new List<GameObject>();

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

    // 🔹 Registriert Objekte, die persistent sind
    public void RegisterPersistentObject(GameObject obj)
    {
        if (!persistentObjects.Contains(obj))
            persistentObjects.Add(obj);
    }

    // 🔹 Reset Button Funktion
    public void FullReset()
    {
        // Alle DontDestroyOnLoad Objekte löschen
        foreach (GameObject obj in persistentObjects)
        {
            if (obj != null)
                Destroy(obj);
        }

        persistentObjects.Clear();

        // Wichtig: TimeScale zurücksetzen
        Time.timeScale = 1f;

        // Startscene neu laden
        SceneManager.LoadScene(0);
    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            FullReset();
        }
    }
}
